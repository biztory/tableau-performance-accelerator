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
  public class QueryViewsForSiteResponseViewsView {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets ContentUrl
    /// </summary>
    [DataMember(Name="contentUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentUrl")]
    public string ContentUrl { get; set; }

    /// <summary>
    /// Gets or Sets Workbook
    /// </summary>
    [DataMember(Name="workbook", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workbook")]
    public QueryViewsForSiteResponseViewsViewWorkbook Workbook { get; set; }

        /// <summary>
        /// Gets or Sets Project
        /// </summary>
        [DataMember(Name = "project", EmitDefaultValue = false)]
        [JsonProperty(PropertyName = "project")]
        public QueryViewsForSiteResponseViewsViewProject Project { get; set; }

        /// <summary>
        /// Gets or Sets Owner
        /// </summary>
        [DataMember(Name="owner", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "owner")]
    public QueryViewsForSiteResponseViewsViewOwner Owner { get; set; }

    /// <summary>
    /// Gets or Sets Usage
    /// </summary>
    [DataMember(Name="usage", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "usage")]
    public QueryViewsForSiteResponseViewsViewUsage Usage { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryViewsForSiteResponseViewsView {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
      sb.Append("  Workbook: ").Append(Workbook).Append("\n");
      sb.Append("  Owner: ").Append(Owner).Append("\n");
      sb.Append("  Usage: ").Append(Usage).Append("\n");
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
