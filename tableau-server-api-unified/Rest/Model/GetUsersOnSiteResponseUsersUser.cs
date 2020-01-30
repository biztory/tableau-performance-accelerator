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
  public class GetUsersOnSiteResponseUsersUser {
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
    /// Gets or Sets SiteRole
    /// </summary>
    [DataMember(Name="siteRole", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "siteRole")]
    public string SiteRole { get; set; }

    /// <summary>
    /// Gets or Sets LastLogin
    /// </summary>
    [DataMember(Name="lastLogin", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "lastLogin")]
    public string LastLogin { get; set; }

    /// <summary>
    /// Gets or Sets ExternalAuthUserId
    /// </summary>
    [DataMember(Name="externalAuthUserId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "externalAuthUserId")]
    public string ExternalAuthUserId { get; set; }

    /// <summary>
    /// Gets or Sets AuthSetting
    /// </summary>
    [DataMember(Name="authSetting", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authSetting")]
    public string AuthSetting { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetUsersOnSiteResponseUsersUser {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  SiteRole: ").Append(SiteRole).Append("\n");
      sb.Append("  LastLogin: ").Append(LastLogin).Append("\n");
      sb.Append("  ExternalAuthUserId: ").Append(ExternalAuthUserId).Append("\n");
      sb.Append("  AuthSetting: ").Append(AuthSetting).Append("\n");
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
