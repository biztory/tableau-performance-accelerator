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
  public class ServerInfoResponseServerInfo {
    /// <summary>
    /// Gets or Sets ProductVersion
    /// </summary>
    [DataMember(Name="productVersion", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "productVersion")]
    public ServerInfoResponseServerInfoProductVersion ProductVersion { get; set; }

    /// <summary>
    /// Gets or Sets RestApiVersion
    /// </summary>
    [DataMember(Name="restApiVersion", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "restApiVersion")]
    public string RestApiVersion { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class ServerInfoResponseServerInfo {\n");
      sb.Append("  ProductVersion: ").Append(ProductVersion).Append("\n");
      sb.Append("  RestApiVersion: ").Append(RestApiVersion).Append("\n");
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
