using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model {

  /// <summary>
  /// 
  /// </summary>
  [DataContract]
  public class QuerySiteResponseSiteUsage {
    /// <summary>
    /// Gets or Sets NumUsers
    /// </summary>
    [DataMember(Name="numUsers", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "numUsers")]
    public string NumUsers { get; set; }

    /// <summary>
    /// Gets or Sets Storage
    /// </summary>
    [DataMember(Name="storage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "storage")]
    public string Storage { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QuerySiteResponseSiteUsage {\n");
      sb.Append("  NumUsers: ").Append(NumUsers).Append("\n");
      sb.Append("  Storage: ").Append(Storage).Append("\n");
      sb.Append("}\n");
      return sb.ToString();
    }

    /// <summary>
    /// Get the JSON string presentation of the object
    /// </summary>
    /// <returns>JSON string presentation of the object</returns>
    public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
