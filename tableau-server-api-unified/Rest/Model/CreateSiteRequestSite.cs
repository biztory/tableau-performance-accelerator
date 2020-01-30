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
  public class CreateSiteRequestSite {
    /// <summary>
    /// The name of the site.
    /// </summary>
    /// <value>The name of the site.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The site URL. This value can contain only characters that are valid in a URL.
    /// </summary>
    /// <value>The site URL. This value can contain only characters that are valid in a URL.</value>
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
    /// (Optional) The maximum number of users for the site. If you do not specify this value, the limit depends on the type of licensing configured for the server. For user-based license, the maximum number of users is set by the license. For core-based licensing, there is no limit to the number of users. If you specify a maximum value, only licensed users are counted and server administrators are excluded.
    /// </summary>
    /// <value>(Optional) The maximum number of users for the site. If you do not specify this value, the limit depends on the type of licensing configured for the server. For user-based license, the maximum number of users is set by the license. For core-based licensing, there is no limit to the number of users. If you specify a maximum value, only licensed users are counted and server administrators are excluded.</value>
    [DataMember(Name="userQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userQuota")]
    public int? UserQuota { get; set; }

    /// <summary>
    /// (Optional) The maximum amount of space for the new site, in megabytes. If you set a quota and the site exceeds it, publishers will be prevented from uploading new content until the site is under the limit again.
    /// </summary>
    /// <value>(Optional) The maximum amount of space for the new site, in megabytes. If you set a quota and the site exceeds it, publishers will be prevented from uploading new content until the site is under the limit again.</value>
    [DataMember(Name="storageQuota", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "storageQuota")]
    public int? StorageQuota { get; set; }

    /// <summary>
    /// (Optional) Specify true to prevent users from being able to subscribe to workbooks on the specified site. The default is false.
    /// </summary>
    /// <value>(Optional) Specify true to prevent users from being able to subscribe to workbooks on the specified site. The default is false.</value>
    [DataMember(Name="disableSubscriptions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "disableSubscriptions")]
    public bool? DisableSubscriptions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateSiteRequestSite {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
      sb.Append("  AdminMode: ").Append(AdminMode).Append("\n");
      sb.Append("  UserQuota: ").Append(UserQuota).Append("\n");
      sb.Append("  StorageQuota: ").Append(StorageQuota).Append("\n");
      sb.Append("  DisableSubscriptions: ").Append(DisableSubscriptions).Append("\n");
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
