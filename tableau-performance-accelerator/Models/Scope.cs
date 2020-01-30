using Newtonsoft.Json;


namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    public class Scope
    {
        [JsonProperty("projects", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Projects { get; set; }

        [JsonProperty("workbooks", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Workbooks { get; set; }

        [JsonProperty("views", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Views { get; set; }

        [JsonProperty("users", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Users { get; set; }

        [JsonProperty("groups", NullValueHandling = NullValueHandling.Ignore)]
        public ScopeConfiguration Groups { get; set; }
    }

}
