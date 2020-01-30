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
  public class QueryWorkbooksForSiteResponseWorkbooksWorkbook {
    /// <summary>
    /// id
    /// </summary>
    /// <value>id</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// name
    /// </summary>
    /// <value>name</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// contentUrl
    /// </summary>
    /// <value>contentUrl</value>
    [DataMember(Name="contentUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentUrl")]
    public string ContentUrl { get; set; }

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
    /// updatedAt
    /// </summary>
    /// <value>updatedAt</value>
    [DataMember(Name="updatedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updatedAt")]
    public string UpdatedAt { get; set; }

    /// <summary>
    /// Gets or Sets Project
    /// </summary>
    [DataMember(Name="project", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "project")]
    public QueryWorkbooksForSiteResponseWorkbooksProject Project { get; set; }

    /// <summary>
    /// Gets or Sets Owner
    /// </summary>
    [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public QueryWorkbooksForSiteResponseWorkbooksOwner Owner { get; set; }

    /// <summary>
    /// Gets or Sets Tags
    /// </summary>
    [DataMember(Name="tags", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "tags")]
    public QueryWorkbooksForSiteResponseWorkbooksTags Tags { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryWorkbooksForSiteResponseWorkbooksWorkbook {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
      sb.Append("  ShowTabs: ").Append(ShowTabs).Append("\n");
      sb.Append("  Size: ").Append(Size).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
      sb.Append("  Project: ").Append(Project).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  Tags: ").Append(Tags).Append("\n");
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
