using Newtonsoft.Json;
using System.Collections.Generic;


namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    public partial class UserFilterConfiguration
    {
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Users { get; set; }
        [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Groups { get; set; }
        [JsonProperty("filters", NullValueHandling = NullValueHandling.Ignore)]
        public List<FilterConfiguration> Filters { get; set; }
        [JsonProperty("parameters", NullValueHandling = NullValueHandling.Ignore)]
        public List<FilterConfiguration> Parameters { get; set; }
    }

}
