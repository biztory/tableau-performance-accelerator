using System;
using System.Collections.Generic;
using System.Linq;
using Biztory.EnterpriseToolkit.TableauServer;


namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    /// <summary>
    /// Represents a Filter set: one package of filters to be applied at one time to views.
    /// </summary>
    public class FilterSet // : IEquatable<FilterSet>
    {
        public List<FilterValue> FilterValues;
        //public FilterSetType Type = FilterSetType.Filter;
        public FilterSet()
        {
            FilterValues = new List<FilterValue>();
        }

        // Should probably use that Enum 
        public string AsFilterString(string ViewRequestMode)
        {
            switch (ViewRequestMode)
            {
                case "RestApi":
                    return this.AsTableauServerRestApiFilterString();
                case "HttpGet":
                default:
                    return this.AsTableauUrlQueryFilterString();
            }
        }

        public string AsFilterString(TableauPerformanceAccelerator.ViewRequestMode ViewRequestMode)
        {
            switch (ViewRequestMode)
            {
                case TableauPerformanceAccelerator.ViewRequestMode.RestApi:
                    return this.AsTableauServerRestApiFilterString();
                case TableauPerformanceAccelerator.ViewRequestMode.HttpGet:
                default:
                    return this.AsTableauUrlQueryFilterString();
            }
        }

        // BET-55 https://biztory.atlassian.net/jira/software/projects/BET/boards/12?selectedIssue=BET-55
        public string AsTableauUrlQueryFilterString()
        {
            // TODO: If there is a filter type FilterSet with the same column name as a parameter, the parameter
            //  must be prefixed with "Parameters." (e.g. Parameters.SomeParameter) when used in the query string. - MMM 
            return FilterValues
                // Theoretically we can have columns with the same names as parameters, so...
                .GroupBy(fv => $"{fv.Type.ToString()}|The Boy Who Stopped the World|{fv.Column}")
                .OrderBy(fv => fv.Key)
                .Select(fv =>
                    String.Format("{2}{0}={1}",
                         fv.Key.Split("|The Boy Who Stopped the World|")[1],
                         fv.OrderBy(fvv => fvv.Value)
                           .Select(f => f.Value)
                           .Aggregate((x, y) => $"{x},{y}"),
                         // Tableau allows Parameters to have the same name as a column. In these
                         //  cases, we must prefix parameters. 
                         (fv.First().Type == FilterValueType.Parameter ? "Parameters." : "")
                         ))
                .Aggregate((x, y) => $"{x}&{y}");
        }

        public string AsTableauServerRestApiFilterString()
        {
            return FilterValues
                // Theoretically we can have columns with the same names as parameters, so...
                .GroupBy(fv => $"{fv.Type.ToString()}|The Boy Who Stopped the World|{fv.Column}")
                .OrderBy(fv => fv.Key)
                .Select(fv =>
                    String.Format("vf_{2}{0}={1}",
                         fv.Key.Split("|The Boy Who Stopped the World|")[1],
                         fv.OrderBy(fvv => fvv.Value)
                           .Select(f => f.Value)
                           .Aggregate((x, y) => $"{x},{y}"),
                         // Tableau allows Parameters to have the same name as a column. In these
                         //  cases, we must prefix parameters. 
                         (fv.First().Type == FilterValueType.Parameter ? "Parameters." : "")
                         ))
                .Aggregate((x, y) => $"{x}&{y}");
        }

        public class FilterSetComparer : IEqualityComparer<FilterSet>
        {
            bool IEqualityComparer<FilterSet>.Equals(FilterSet x, FilterSet y)
            {
                // Start with easy ways to quickly identify not-equal FilterSet objects
                if (x.FilterValues.Count != y.FilterValues.Count)
                {
                    return false;
                }
                else if (x.FilterValues.Min(fv => fv.Column) != y.FilterValues.Min(fv => fv.Column))
                {
                    return false;
                }
                else if (x.FilterValues.Max(fv => fv.Column) != y.FilterValues.Max(fv => fv.Column))
                {
                    return false;
                }
                else if (x.FilterValues.Min(fv => fv.Value) != y.FilterValues.Min(fv => fv.Value))
                {
                    return false;
                }
                else if (x.FilterValues.Max(fv => fv.Value) != y.FilterValues.Max(fv => fv.Value))
                {
                    return false;
                }
                else if (x.AsTableauServerRestApiFilterString() == y.AsTableauServerRestApiFilterString())
                {
                    return true;
                }
                else { return false; }
            }

            int IEqualityComparer<FilterSet>.GetHashCode(FilterSet obj)
            {
                unchecked // Overflow is fine, just wrap
                {
                    int hashCode = 42;
                    if (obj.FilterValues != null)
                    {
                        obj.FilterValues.ForEach(fv =>
                        {
                            hashCode = hashCode * 59 + fv.Column.GetHashCode();
                            hashCode = hashCode * 59 + fv.Value.GetHashCode();
                        });
                    }
                    return hashCode;
                }
            }
        }
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 42;
                if (FilterValues != null)
                {
                    FilterValues.ForEach(fv =>
                    {
                        hashCode = hashCode * 59 + fv.Column.GetHashCode();
                        hashCode = hashCode * 59 + fv.Value.GetHashCode();
                    });
                }
                return hashCode;
            }
        }
    }

}
