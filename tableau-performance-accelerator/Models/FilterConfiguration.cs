using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;


namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    public class InputConfiguration
    {
        static readonly ILogger logger = ApplicationLogging.LoggerFactory.CreateLogger<FilterConfiguration>();

        [JsonProperty("name", NullValueHandling = NullValueHandling.Ignore)]
        public string Name { get; set; }

        [JsonProperty("datatype", NullValueHandling = NullValueHandling.Ignore)]
        public string Datatype { get; set; }

        [JsonProperty("values", NullValueHandling = NullValueHandling.Ignore)]
        public List<Value> Values { get; set; }

        public virtual FilterValueType ConfigurationType { get; } = FilterValueType.Filter;

        public List<FilterValue> GetFilterValues(/* FilterValueType Type = FilterValueType.Filter */)
        {
            logger.LogTrace($"GetFilterValues() for {Values.Count()} values...");

            return Values.Select(v =>
                new FilterValue()
                {
                    Column = Name,
                    Value = (Datatype == "string" ? v.String :
                                        (v.Double == null) ? v.String : v.Double.ToString()),
                    Type = ConfigurationType
                })
                .ToList();
        }
    }

    // Not really sure if this is the best way to do this. - MMM
    public class ParameterConfiguration : InputConfiguration
    {
        public override FilterValueType ConfigurationType { get; } = FilterValueType.Parameter;
    }

    public class FilterConfiguration : InputConfiguration
    {
        public override FilterValueType ConfigurationType { get; } = FilterValueType.Filter;
    }

}
