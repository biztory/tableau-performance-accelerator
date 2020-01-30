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
  public class CreateProjectRequestProject {
    /// <summary>
    /// The name to assign to the project.
    /// </summary>
    /// <value>The name to assign to the project.</value>
    [DataMember(Name="project name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "project name")]
    public string ProjectName { get; set; }

    /// <summary>
    /// (Optional) A description for the project.
    /// </summary>
    /// <value>(Optional) A description for the project.</value>
    [DataMember(Name="description", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "description")]
    public string Description { get; set; }

    /// <summary>
    /// (Optional) Specify LockedToProject to lock permissions so that users cannot overwrite the default permissions set for the project, or specify ManagedByOwner to allow users to manage permissions for content that they own. For more information, see Lock Content Permissions to the Project. The default is ManagedByOwner.
    /// </summary>
    /// <value>(Optional) Specify LockedToProject to lock permissions so that users cannot overwrite the default permissions set for the project, or specify ManagedByOwner to allow users to manage permissions for content that they own. For more information, see Lock Content Permissions to the Project. The default is ManagedByOwner.</value>
    [DataMember(Name="contentPermissions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentPermissions")]
    public string ContentPermissions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateProjectRequestProject {\n");
      sb.Append("  ProjectName: ").Append(ProjectName).Append("\n");
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
