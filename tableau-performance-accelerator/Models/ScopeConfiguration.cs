using Newtonsoft.Json;
using System;
using System.Collections.Generic;


namespace Biztory.EnterpriseToolkit.TableauServer.Models
{
    public partial class ScopeConfiguration
    {
        [JsonProperty("regex", NullValueHandling = NullValueHandling.Ignore)]
        public string Regex { get; set; }

        [JsonProperty("include", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Include { get; set; }

        [JsonProperty("exclude", NullValueHandling = NullValueHandling.Ignore)]
        public List<object> Exclude { get; set; }

        public bool ScopeMatch(string Value)
        {
            if (Value == null)
                throw new ArgumentNullException(nameof(Value), new Exception("No scope match value supplied."));

            // If the value is not excluded, and if it matches the regex scope OR the explicit include list, then include it
            return 
            (
                (
                    // If there's a regex and it matches
                    (
                        (this.Regex ?? "").Length > 0
                            &&
                        System.Text.RegularExpressions.Regex.IsMatch(Value, this.Regex)
                    ) 
                    // Or if it's explicitly included
                        ||
                    this.Include.Contains(Value)
                )
                // And so long as it's not been explicitly excluded
                    &&
                !(this.Exclude.Contains(Value))
            );
        }

    }

}
