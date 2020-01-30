using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    public enum FilterCombinatoricsMode { Individual, Cartesian, AllCombinations, NoFilter }

    [DataContract]
    public partial class FilterAndCubeConfiguration
    {
        static ILogger logger = ApplicationLogging.LoggerFactory.CreateLogger<FilterAndCubeConfiguration>();

        [JsonProperty("scope", NullValueHandling = NullValueHandling.Ignore)]
        public Scope Scope { get; set; }

        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public List<FilterConfiguration> Filters { get; set; }

        [JsonProperty("user-filters", NullValueHandling = NullValueHandling.Ignore)]
        public List<UserFilterConfiguration> UserFilters { get; set; }

        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public List<ParameterConfiguration> Parameters { get; set; }

        public List<FilterCollection> GetFilterCollections()
        {
            return GetFilterCollections(this.Filters.Select(f => (InputConfiguration)f).ToList());
        }

        public List<FilterCollection> GetFilterCollections(List<InputConfiguration> Filters)
        {
            return Filters
                .Select((f) => f.GetFilterValues()
                .GetFilterCombinations())
                .ToList();
        }

        public List<FilterCollection> GetParameterCollections()
        {
            return GetFilterCollections(this.Parameters.Select(f => (InputConfiguration)f).ToList());
        }

        /// <summary>
        /// Generates the filter sets: the Cartesian product of all individual FilterValues
        /// </summary>
        /// <returns>The filter sets.</returns>
        public List<FilterSet> GetFilterSets(List<InputConfiguration> FilterConfigurations, FilterCombinatoricsMode FilterMode)
        {
            logger.LogTrace($"GetFilterSets(List<FilterConfigurations>, {FilterMode.ToString()})");
            List<FilterSet> filterSets = new List<FilterSet>();

            switch (FilterMode)
            {
                case FilterCombinatoricsMode.Cartesian:
                    List<FilterSet> interimList = new List<FilterSet>();

                    // Current plan: with each pass, we cross join the list of filter sets w/ the new filter config
                    //  and output a new list of filter sets that appends the new value

                    // https://stackoverflow.com/a/43354572
                    logger.LogTrace($"Filter.Count: {FilterConfigurations.Count()}");
                    FilterConfigurations.ForEach(filter =>
                    {
                        if (interimList.Count == 0)
                        {
                            interimList.AddRange(filter.GetFilterValues().Select(f => new FilterSet() { FilterValues = new List<FilterValue>() { f } }));
                            filterSets = interimList;
                        }
                        else
                        {
                            // I have a hunch that this could be done much more efficiently. :shrug:
                            interimList = filterSets;
                            filterSets =
                                // spiffy LINQ cross-join
                                (from value in filter.GetFilterValues()
                                 from filterSet in interimList
                                 select new FilterSet { FilterValues = filterSet.FilterValues.Union(new List<FilterValue> { value }).ToList()})
                                .ToList();
                        }
                    });

                    return filterSets;
                case FilterCombinatoricsMode.Individual:
                    return FilterConfigurations
                        .Select((f) => f.GetFilterValues()
                                        .GetFilterCombinations())
                        .SelectMany(c => c.FilterSets)
                        .ToList();
                case FilterCombinatoricsMode.AllCombinations:
                    return FilterConfigurations
                        .Select((f) => f.GetFilterValues()
                                        .GetFilterCombinations())
                        .ToList()
                        .GetAllFilterCollectionCombinations()
                        .FilterSets
                        .ToList();
                case FilterCombinatoricsMode.NoFilter:
                default:
                    return filterSets;
            }
        }

        /// <summary>
        /// Generates the filter sets: the Cartesian product of all individual FilterValues
        /// </summary>
        /// <returns>The filter sets.</returns>
        public List<FilterSet> GetFilterSets(FilterCombinatoricsMode FilterMode)
        {
            logger.LogTrace($"GetFilterSets({FilterMode.ToString()})");

            // Default behavior, with no List<FilterConfiguration> specified, is to process the "global" filters list
            //  instead of the user-specific lists under UserFilters
            return GetFilterSets(
                    Filters.ToInputs()
                        .Union(Parameters.ToInputs())
                        .ToList(),
                    FilterMode)
                .ToList();
        }
    }

    /// <summary>
    /// Represents a filter value: one filter value to be applied to one column. Is packaged with other FilterValues
    ///  to form a FilterSet.
    /// </summary>
    public class FilterValue
    {
        public string Column { get; set; }
        public string Value { get; set; }
        public FilterValueType Type { get; set; } = FilterValueType.Filter;
    }

    public enum FilterValueType
    {
        Filter,
        Parameter
    }

    public partial struct Value
    {
        public double? Double;
        public string String;

        public static implicit operator Value(double Double)
        {
            return new Value { Double = Double };
        }
        public static implicit operator Value(string String)
        {
            return new Value { String = String };
        }
    }

    public partial class FilterAndCubeConfiguration
    {
        public static FilterAndCubeConfiguration FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FilterAndCubeConfiguration>(json, Models.Converter.Settings);
        }
    }




}
