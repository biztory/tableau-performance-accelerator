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
  public class UpdateWorkbookRequestWorkbook {
    /// <summary>
    /// (Optional) Specify true to have the published workbook show views in tabs; otherwise, false. The default is false.
    /// </summary>
    /// <value>(Optional) Specify true to have the published workbook show views in tabs; otherwise, false. The default is false.</value>
    [DataMember(Name="showTabs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "showTabs")]
    public string ShowTabs { get; set; }

    /// <summary>
    /// Gets or Sets Project
    /// </summary>
    [DataMember(Name="project", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "project")]
    public UpdateWorkbookRequestWorkbookProject Project { get; set; }

    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public UpdateWorkbookRequestWorkbookOwner Owner { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateWorkbookRequestWorkbook {\n");
      sb.Append("  ShowTabs: ").Append(ShowTabs).Append("\n");
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
