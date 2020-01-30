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
  public class AddWorkbookPermissionRequestPermissionsGranteeCapabilitiesUserCapabilitiesCapabilitie {
    /// <summary>
    /// The capability to assign. If any capability has already been granted or denied for a specified user or group, that capability is ignored. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write.
    /// </summary>
    /// <value>The capability to assign. If any capability has already been granted or denied for a specified user or group, that capability is ignored. Valid capabilities for a workbook are AddComment, ChangeHierarchy, ChangePermissions, Delete, ExportData, ExportImage, ExportXml, Filter, Read (view), ShareView, ViewComments, ViewUnderlyingData, WebAuthoring, and Write.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Allow to allow the capability, or Deny to deny it. This value is case sensitive.
    /// </summary>
    /// <value>Allow to allow the capability, or Deny to deny it. This value is case sensitive.</value>
    [DataMember(Name="mode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "mode")]
    public string Mode { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddWorkbookPermissionRequestPermissionsGranteeCapabilitiesUserCapabilitiesCapabilitie {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Mode: ").Append(Mode).Append("\n");
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
