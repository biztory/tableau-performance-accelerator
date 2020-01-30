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
  public class AddProjectPermissionRequestPermissionsGranteeCapabilities {
    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="user", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "user")]
    public AddProjectPermissionRequestPermissionsGranteeCapabilitiesUser User { get; set; }

    /// <summary>
    /// Gets or Sets Group
    /// </summary>
    [DataMember(Name="group", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "group")]
    public AddProjectPermissionRequestPermissionsGranteeCapabilitiesGroup Group { get; set; }

    /// <summary>
    /// Gets or Sets Capabilities
    /// </summary>
    [DataMember(Name="capabilities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "capabilities")]
    public AddProjectPermissionRequestPermissionsGranteeCapabilitiesUserCapabilities Capabilities { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddProjectPermissionRequestPermissionsGranteeCapabilities {\n");
      sb.Append("  User: ").Append(User).Append("\n");
      sb.Append("  Group: ").Append(Group).Append("\n");
      sb.Append("  Capabilities: ").Append(Capabilities).Append("\n");
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
