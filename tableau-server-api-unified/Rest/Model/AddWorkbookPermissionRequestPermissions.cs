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
  public class AddWorkbookPermissionRequestPermissions {
    /// <summary>
    /// Gets or Sets Workbook
    /// </summary>
    [DataMember(Name="workbook", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workbook")]
    public AddWorkbookPermissionRequestPermissionsWorkbook Workbook { get; set; }

    /// <summary>
    /// Gets or Sets GranteeCapabilities
    /// </summary>
    [DataMember(Name="granteeCapabilities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "granteeCapabilities")]
    public AddWorkbookPermissionRequestPermissionsGranteeCapabilities GranteeCapabilities { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddWorkbookPermissionRequestPermissions {\n");
      sb.Append("  Workbook: ").Append(Workbook).Append("\n");
      sb.Append("  GranteeCapabilities: ").Append(GranteeCapabilities).Append("\n");
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
