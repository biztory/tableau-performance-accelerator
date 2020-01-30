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
  public class UpdateWorkbookResponseWorkbook {
    /// <summary>
    /// id
    /// </summary>
    /// <value>id</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// showTabs
    /// </summary>
    /// <value>showTabs</value>
    [DataMember(Name="showTabs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "showTabs")]
    public string ShowTabs { get; set; }

    /// <summary>
    /// size
    /// </summary>
    /// <value>size</value>
    [DataMember(Name="size", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "size")]
    public string Size { get; set; }

    /// <summary>
    /// createdAt
    /// </summary>
    /// <value>createdAt</value>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// updated
    /// </summary>
    /// <value>updated</value>
    [DataMember(Name="updated", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updated")]
    public string Updated { get; set; }

    /// <summary>
    /// Gets or Sets Project
    /// </summary>
    [DataMember(Name="project", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "project")]
    public UpdateWorkbookResponseWorkbookProject Project { get; set; }

    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public UpdateWorkbookResponseWorkbookOwner Owner { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateWorkbookResponseWorkbook {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  ShowTabs: ").Append(ShowTabs).Append("\n");
      sb.Append("  Size: ").Append(Size).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  Updated: ").Append(Updated).Append("\n");
      sb.Append("  Project: ").Append(Project).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
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
