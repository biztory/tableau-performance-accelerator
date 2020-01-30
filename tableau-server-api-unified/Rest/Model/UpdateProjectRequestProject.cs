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
  public class UpdateProjectRequestProject {
    /// <summary>
    /// (Optional) The new name for the project.
    /// </summary>
    /// <value>(Optional) The new name for the project.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// (Optional) The new description for the project.
    /// </summary>
    /// <value>(Optional) The new description for the project.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// (Optional) The new permissions setting for the project. Specify LockedToProject to lock permissions so that users cannot overwrite the default permissions set for the project, or specify ManagedByOwner to allow users to manage permissions for content that they own. For more information, see Lock Content Permissions to the Project. The default is ManagedByOwner.
    /// </summary>
    /// <value>(Optional) The new permissions setting for the project. Specify LockedToProject to lock permissions so that users cannot overwrite the default permissions set for the project, or specify ManagedByOwner to allow users to manage permissions for content that they own. For more information, see Lock Content Permissions to the Project. The default is ManagedByOwner.</value>
    [DataMember(Name="contentPermissions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentPermissions")]
    public string ContentPermissions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateProjectRequestProject {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Description: ").Append(Description).Append("\n");
      sb.Append("  ContentPermissions: ").Append(ContentPermissions).Append("\n");
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
