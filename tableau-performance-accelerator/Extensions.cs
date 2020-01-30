using Biztory.EnterpriseToolkit.TableauServer.Models;
using Combinatorics.Collections;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace Biztory.EnterpriseToolkit.TableauServer
{
    public static class Extensions
    {
        const int MAX_COMBINATIONS = 255;
        static ILogger logger = ApplicationLogging.LoggerFactory.CreateLogger<TableauPerformanceAccelerator>();

        public static FilterCollection GetFilterCombinations(this List<FilterValue> filterValues)
        {
            FilterCollection filterCombinations = new FilterCollection();
            FilterCollection parameterCombinations = new FilterCollection();

            int FilterCount = filterValues.Where(fv => fv.Type == FilterValueType.Filter).Count();
            int ParameterCount = filterValues.Where(fv => fv.Type == FilterValueType.Parameter).Count();

        #region GetParameters            var groupedParameters = filterValues
                    .Where(fv => fv.Type == FilterValueType.Parameter)
                    .GroupBy(fv => fv.Column)
                    .ToArray();

            // one of each parameter with one each of each N additional parameters
            List<IList<string>> parameterColumnCombinations = new List<System.Collections.Generic.IList<string>>();
            groupedParameters.Select((p, i) => i)
                .ToList()
                .ForEach(p =>
                {
                    parameterColumnCombinations.AddRange(new Combinations<string>(groupedParameters.Select(gp => gp.Key).ToList(), p + 1).Select(s => s));
                });

            // Using the Combinatorics library to generate the list of parameter combinations, we
            //  then take the cartesian product of the value sets of each and project the results
            //  into FilterSets, aka lists of FilterValues.
            parameterCombinations.FilterSets =
                parameterColumnCombinations
                    .Select(cc => groupedParameters
                    .Where(gp => cc.Contains(gp.Key))
                    .Select(gp => gp.Select(gp2 => gp2))
                    .CartesianProduct()
                    .Select(gp => new FilterSet { FilterValues = gp.ToList() }))
                .SelectMany(fs => fs)
                .ToList();
            #endregion GetParameters

            #region GetFilters
            // Generate the filter combinations
            // We cap this, as it gets a bit crazy a bit fast. The number of combinations is 2^(n-1), sooo...
            for (int i = 0; i < FilterCount; i++)
            {
                // In other words, let's not spam our servers to death, shall we?
                if (GetBinomialCoefficient(FilterCount, i + 1) > MAX_COMBINATIONS)
                {
                    // TODO: Fix this wording to take into account single value parameters
                    logger.LogDebug($"Combinations of {filterValues.Count()} choose {i + 1} exceed max combinations threshold of {MAX_COMBINATIONS}. Skipping.");
                    continue;
                }

                // TODO: Fix this wording to take into account single value parameters
                logger.LogDebug($"Generating combinations of {filterValues.Count} values to a depth of {i + 1}...");
                Combinations<FilterValue> combinations = new Combinations<FilterValue>(filterValues.Where(fv => fv.Type == FilterValueType.Filter).ToList(), i + 1);
                // TODO: Fix this wording to take into account single value parameters
                logger.LogDebug($"Generated {combinations.Count} combinations.");

                (filterCombinations.FilterSets as List<FilterSet>).AddRange(combinations.Select(c => new FilterSet { FilterValues = c.ToList() }));
            }
            #endregion GetFilters

            // If we have both parameters and filters, cross-join them
            if (parameterCombinations.FilterSets.Count() > 0 && filterCombinations.FilterSets.Count() > 0)
            {
                return new FilterCollection()
                {
                    FilterSets =
                    // spiffy LINQ cross-join
                    (from parameterSets in parameterCombinations.FilterSets
                        from filterSets in filterCombinations.FilterSets
                        select new FilterSet { FilterValues = filterSets.FilterValues.Union(parameterSets.FilterValues).ToList() })
                            // Include the parameter combinations without the filters as well
                            .Union(parameterCombinations.FilterSets)
                    .ToList()
                };
            }
            else if (parameterCombinations.FilterSets.Count() > 0)
            {
                return parameterCombinations;
            }
            else if (filterCombinations.FilterSets.Count() > 0)
            {
                return filterCombinations;
            }
            else return null;
        }

        // http://csharphelper.com/blog/2014/08/calculate-the-binomial-coefficient-n-choose-k-efficiently-in-c/
        public static BigInteger GetBinomialCoefficient(int N, int K)
        {
            BigInteger result = 1;
            for (int i = 1; i <= K; i++)
            {
                result *= N - (K - i);
                result /= i;
            }
            return result;
        }

        public static FilterCollection GetAllFilterCollectionCombinations(this List<FilterCollection> filterCollections)
        {
            return new FilterCollection()
            {
                FilterSets =
                filterCollections
                    // Prevents bugs where one of the FilterCollections has no FilterSets, resulting in a cartesian
                    //  with an empty set, resulting in no results. :-/ - MMM
                    .Where(fc => fc.FilterSets.Count > 0)
                    .Select(c => c.FilterSets)
                    .CartesianProduct()
                    // This presumes that there can't possibly be a case where we have both parameters and filters in one collection.
                    .Select(c => new FilterSet() { FilterValues = c.SelectMany(fs => fs.FilterValues).ToList() })
                    .ToList()
            };
        }

        // https://stackoverflow.com/a/3098381/2239885
        // Gosh, this is impressive stuff
        public static IEnumerable<IEnumerable<T>> CartesianProduct<T>(this IEnumerable<IEnumerable<T>> sequences)
        {
            IEnumerable<IEnumerable<T>> emptyProduct = new[] { Enumerable.Empty<T>() };
            return sequences.Aggregate(
                emptyProduct,
                (accumulator, sequence) =>
                    from accseq in accumulator
                    from item in sequence
                    select accseq.Concat(new[] { item })
                );
        }

        public static List<InputConfiguration> ToInputs(this List<FilterConfiguration> inputConfigurations)
        {
            if (inputConfigurations == null)
            {
                return new List<InputConfiguration>();
            } else
                return inputConfigurations.Select(ic => (InputConfiguration)ic).ToList();
        }
        // There has to be a better way.
        public static List<InputConfiguration> ToInputs(this List<ParameterConfiguration> inputConfigurations)
        {
            if (inputConfigurations == null)
            {
                return new List<InputConfiguration>();
            }
            else
                return inputConfigurations.Select(ic => (InputConfiguration)ic).ToList();
        }
    }
}
