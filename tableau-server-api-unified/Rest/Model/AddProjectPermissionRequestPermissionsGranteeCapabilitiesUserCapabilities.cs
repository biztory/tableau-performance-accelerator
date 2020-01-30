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
  public class AddProjectPermissionRequestPermissionsGranteeCapabilitiesUserCapabilities {
    /// <summary>
    /// Gets or Sets Capability
    /// </summary>
    [DataMember(Name="capability", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capability")]
    public AddProjectPermissionRequestPermissionsGranteeCapabilitiesUserCapabilitiesCapabilitie Capability { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddProjectPermissionRequestPermissionsGranteeCapabilitiesUserCapabilities {\n");
      sb.Append("  Capability: ").Append(Capability).Append("\n");
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
