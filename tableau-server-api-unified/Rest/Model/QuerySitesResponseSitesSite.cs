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
  public class QuerySitesResponseSitesSite {
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
    /// adminMode
    /// </summary>
    /// <value>adminMode</value>
    [DataMember(Name="adminMode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "adminMode")]
    public string AdminMode { get; set; }

    /// <summary>
    /// userQuota
    /// </summary>
    /// <value>userQuota</value>
    [DataMember(Name="userQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userQuota")]
    public string UserQuota { get; set; }

    /// <summary>
    /// storageQuota
    /// </summary>
    /// <value>storageQuota</value>
    [DataMember(Name="storageQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "storageQuota")]
    public string StorageQuota { get; set; }

    /// <summary>
    /// state
    /// </summary>
    /// <value>state</value>
    [DataMember(Name="state", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }

    /// <summary>
    /// statusReason
    /// </summary>
    /// <value>statusReason</value>
    [DataMember(Name="statusReason", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "statusReason")]
    public string StatusReason { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QuerySitesResponseSitesSite {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
      sb.Append("  AdminMode: ").Append(AdminMode).Append("\n");
      sb.Append("  UserQuota: ").Append(UserQuota).Append("\n");
      sb.Append("  StorageQuota: ").Append(StorageQuota).Append("\n");
      sb.Append("  State: ").Append(State).Append("\n");
      sb.Append("  StatusReason: ").Append(StatusReason).Append("\n");
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
