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
  public class PublishWorkbookRequestWorkbook {
    /// <summary>
    /// The name to assign to the workbook when it is saved on the server.
    /// </summary>
    /// <value>The name to assign to the workbook when it is saved on the server.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// (Optional) Specify true to have the published workbook show views in tabs; otherwise, false. The default is false.
    /// </summary>
    /// <value>(Optional) Specify true to have the published workbook show views in tabs; otherwise, false. The default is false.</value>
    [DataMember(Name="showTabs", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "showTabs")]
    public string ShowTabs { get; set; }

    /// <summary>
    /// Gets or Sets ConnectionCredentials
    /// </summary>
    [DataMember(Name="connectionCredentials", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "connectionCredentials")]
    public PublishWorkbookRequestWorkbookConnectionCredentials ConnectionCredentials { get; set; }

    /// <summary>
    /// Gets or Sets Project
    /// </summary>
    [DataMember(Name="project", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "project")]
    public PublishWorkbookRequestWorkbookProject Project { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PublishWorkbookRequestWorkbook {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ShowTabs: ").Append(ShowTabs).Append("\n");
      sb.Append("  ConnectionCredentials: ").Append(ConnectionCredentials).Append("\n");
      sb.Append("  Project: ").Append(Project).Append("\n");
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
