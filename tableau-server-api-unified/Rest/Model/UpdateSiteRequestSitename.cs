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
  public class UpdateSiteRequestSitename {
    /// <summary>
    /// (Optional) The new name of the site
    /// </summary>
    /// <value>(Optional) The new name of the site</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// (Optional) The new site URL. This value can contain only characters that are valid in a URL.
    /// </summary>
    /// <value>(Optional) The new site URL. This value can contain only characters that are valid in a URL.</value>
    [DataMember(Name="contentUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentUrl")]
    public string ContentUrl { get; set; }

    /// <summary>
    /// (Optional) Specify ContentAndUsers to allow site administrators to use the server interface and tabcmd commands to add and remove users. (Specifying this option does not give site administrators permissions to manage users using the REST API.) Specify ContentOnly to prevent site administrators from adding or removing users. (Server administrators can always add or remove users.) Note: You cannot set adminMode to ContentOnly and also set userQuota.
    /// </summary>
    /// <value>(Optional) Specify ContentAndUsers to allow site administrators to use the server interface and tabcmd commands to add and remove users. (Specifying this option does not give site administrators permissions to manage users using the REST API.) Specify ContentOnly to prevent site administrators from adding or removing users. (Server administrators can always add or remove users.) Note: You cannot set adminMode to ContentOnly and also set userQuota.</value>
    [DataMember(Name="adminMode", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "adminMode")]
    public string AdminMode { get; set; }

    /// <summary>
    /// (Optional) The new maximum number of users for the site. Only licensed users are counted and server administrators are excluded. Setting this value to -1 removes any value that was set previously. In that case, the limit depends on the type of licensing configured for the server. For user-based licensing, the maximum number of users is set by the license. For core-based licensing, there is no limit to the number of users.
    /// </summary>
    /// <value>(Optional) The new maximum number of users for the site. Only licensed users are counted and server administrators are excluded. Setting this value to -1 removes any value that was set previously. In that case, the limit depends on the type of licensing configured for the server. For user-based licensing, the maximum number of users is set by the license. For core-based licensing, there is no limit to the number of users.</value>
    [DataMember(Name="userQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userQuota")]
    public int? UserQuota { get; set; }

    /// <summary>
    /// (Optional) Active to set the site to active mode, or Suspended to suspend the site.
    /// </summary>
    /// <value>(Optional) Active to set the site to active mode, or Suspended to suspend the site.</value>
    [DataMember(Name="state", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }

    /// <summary>
    /// (Optional) The new maximum amount of space for the new site, in megabytes. If you set a quota and the site exceeds it, publishers will be prevented from uploading new content until the site is under the limit again.
    /// </summary>
    /// <value>(Optional) The new maximum amount of space for the new site, in megabytes. If you set a quota and the site exceeds it, publishers will be prevented from uploading new content until the site is under the limit again.</value>
    [DataMember(Name="storageQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "storageQuota")]
    public int? StorageQuota { get; set; }

    /// <summary>
    /// (Optional) true to prevent users from being able to subscribe to workbooks on the specified site.
    /// </summary>
    /// <value>(Optional) true to prevent users from being able to subscribe to workbooks on the specified site.</value>
    [DataMember(Name="disableSubscriptions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "disableSubscriptions")]
    public bool? DisableSubscriptions { get; set; }

    /// <summary>
    /// (Optional) true if the site maintains revisions for changes to workbooks and data sources; otherwise, false. The default is false.
    /// </summary>
    /// <value>(Optional) true if the site maintains revisions for changes to workbooks and data sources; otherwise, false. The default is false.</value>
    [DataMember(Name="revisionHistoryEnabled", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionHistoryEnabled")]
    public bool? RevisionHistoryEnabled { get; set; }

    /// <summary>
    /// (Optional) An integer between 2 and 10000 to indicate a limited number of revisions for content. Setting this value to -1 removes any value that was set previously, and effectively removes any limit to the number of revisions that are maintained.
    /// </summary>
    /// <value>(Optional) An integer between 2 and 10000 to indicate a limited number of revisions for content. Setting this value to -1 removes any value that was set previously, and effectively removes any limit to the number of revisions that are maintained.</value>
    [DataMember(Name="revisionLimit", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionLimit")]
    public int? RevisionLimit { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateSiteRequestSitename {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
      sb.Append("  AdminMode: ").Append(AdminMode).Append("\n");
      sb.Append("  UserQuota: ").Append(UserQuota).Append("\n");
      sb.Append("  State: ").Append(State).Append("\n");
      sb.Append("  StorageQuota: ").Append(StorageQuota).Append("\n");
      sb.Append("  DisableSubscriptions: ").Append(DisableSubscriptions).Append("\n");
      sb.Append("  RevisionHistoryEnabled: ").Append(RevisionHistoryEnabled).Append("\n");
      sb.Append("  RevisionLimit: ").Append(RevisionLimit).Append("\n");
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
