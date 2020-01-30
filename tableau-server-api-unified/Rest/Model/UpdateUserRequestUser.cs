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
  public class UpdateUserRequestUser {
    /// <summary>
    /// (Optional) The new name for the user. Users can change names without affecting the groups they belong to. Tableau Server only. Not available in Tableau Online.
    /// </summary>
    /// <value>(Optional) The new name for the user. Users can change names without affecting the groups they belong to. Tableau Server only. Not available in Tableau Online.</value>
    [DataMember(Name="fullName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fullName")]
    public string FullName { get; set; }

    /// <summary>
    /// (Optional) The new email address for the user. Tableau Server only. Not available in Tableau Online.
    /// </summary>
    /// <value>(Optional) The new email address for the user. Tableau Server only. Not available in Tableau Online.</value>
    [DataMember(Name="email", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }

    /// <summary>
    /// (Optional) The new password for the user. Tableau Server only. Not available in Tableau Online.
    /// </summary>
    /// <value>(Optional) The new password for the user. Tableau Server only. Not available in Tableau Online.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// (Optional) The new site role. Valid role names are Interactor, Publisher, SiteAdministrator, Unlicensed, UnlicensedWithPublish, Viewer, and ViewerWithPublish. Note: You cannot use the REST API to set a user to be a server administrator (ServerAdministrator site role).
    /// </summary>
    /// <value>(Optional) The new site role. Valid role names are Interactor, Publisher, SiteAdministrator, Unlicensed, UnlicensedWithPublish, Viewer, and ViewerWithPublish. Note: You cannot use the REST API to set a user to be a server administrator (ServerAdministrator site role).</value>
    [DataMember(Name="siteRole", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "siteRole")]
    public string SiteRole { get; set; }

    /// <summary>
    /// (Optional) The new authentication type for the user. You can assign the following values for this attribute: SAML (the user signs in using SAML) or ServerDefault (the user signs in using the authentication method that's set for the server). These values appear on the Authenticationtab on the Settings page in Tableau Online—the SAML attribute value corresponds to Single sign-on, and the ServerDefault value corresponds to TableauID. Note: The new-auth-setting setting is available only if you are using Tableau Online.
    /// </summary>
    /// <value>(Optional) The new authentication type for the user. You can assign the following values for this attribute: SAML (the user signs in using SAML) or ServerDefault (the user signs in using the authentication method that's set for the server). These values appear on the Authenticationtab on the Settings page in Tableau Online—the SAML attribute value corresponds to Single sign-on, and the ServerDefault value corresponds to TableauID. Note: The new-auth-setting setting is available only if you are using Tableau Online.</value>
    [DataMember(Name="authSetting", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authSetting")]
    public string AuthSetting { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateUserRequestUser {\n");
      sb.Append("  FullName: ").Append(FullName).Append("\n");
      sb.Append("  Email: ").Append(Email).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  SiteRole: ").Append(SiteRole).Append("\n");
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
