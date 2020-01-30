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
  public class AddDefaultPermissionRequestPermissionsGranteeCapabilitiesProject {
    /// <summary>
    /// The <project> element is not required, but can be included. If the <project> element is included, the project-id value must match the project ID in the URI. Any other attributes in the <project> element are ignored.
    /// </summary>
    /// <value>The <project> element is not required, but can be included. If the <project> element is included, the project-id value must match the project ID in the URI. Any other attributes in the <project> element are ignored.</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddDefaultPermissionRequestPermissionsGranteeCapabilitiesProject {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
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
