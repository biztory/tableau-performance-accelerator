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
  public class UpdateSiteResponseSite {
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
    /// Gets or Sets AdminMode
    /// </summary>
    [DataMember(Name="adminMode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "adminMode")]
    public string AdminMode { get; set; }

    /// <summary>
    /// Gets or Sets UserQuota
    /// </summary>
    [DataMember(Name="userQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userQuota")]
    public string UserQuota { get; set; }

    /// <summary>
    /// Gets or Sets StorageQuota
    /// </summary>
    [DataMember(Name="storageQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "storageQuota")]
    public string StorageQuota { get; set; }

    /// <summary>
    /// Gets or Sets DisableSubscriptions
    /// </summary>
    [DataMember(Name="disableSubscriptions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "disableSubscriptions")]
    public string DisableSubscriptions { get; set; }

    /// <summary>
    /// Gets or Sets RevisionHistoryEnabled
    /// </summary>
    [DataMember(Name="revisionHistoryEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionHistoryEnabled")]
    public string RevisionHistoryEnabled { get; set; }

    /// <summary>
    /// Gets or Sets RevisionLimit
    /// </summary>
    [DataMember(Name="revisionLimit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionLimit")]
    public string RevisionLimit { get; set; }

    /// <summary>
    /// Gets or Sets State
    /// </summary>
    [DataMember(Name="state", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateSiteResponseSite {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
      sb.Append("  AdminMode: ").Append(AdminMode).Append("\n");
      sb.Append("  UserQuota: ").Append(UserQuota).Append("\n");
      sb.Append("  StorageQuota: ").Append(StorageQuota).Append("\n");
      sb.Append("  DisableSubscriptions: ").Append(DisableSubscriptions).Append("\n");
      sb.Append("  RevisionHistoryEnabled: ").Append(RevisionHistoryEnabled).Append("\n");
      sb.Append("  RevisionLimit: ").Append(RevisionLimit).Append("\n");
      sb.Append("  State: ").Append(State).Append("\n");
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
