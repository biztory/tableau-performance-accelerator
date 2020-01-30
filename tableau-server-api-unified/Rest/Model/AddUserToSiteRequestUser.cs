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
  public class AddUserToSiteRequestUser {
    /// <summary>
    /// The name of the user. If the server uses local authentication, this can be any name. If you are using Active Directory authentication, or if you are using Tableau Online, there are specific requirements for the name.Tableau Server If Tableau Server uses Active Directory authentication, this must be the name of an existing user in Active Directory. If the user name is not unique across domains, you must include the domain as part of the user name (for example, example\\Adam or adam@example.com).Note: Active Directory specifies a user name using two attributes: sAMAccountName and userPrincipalName (UPN) prefix. For most Active Directory users, these attributes are the same. By default, if you are adding a user from Active Directory, the name that you provide in the user-name is matched against the Active Directory sAMAccountName attribute, which becomes the name that the user signs in to Tableau Server with. There are two exceptions: if the name that you provide is longer than 20 characters, or if the name that you provides includes an @ character, Tableau imports the user using the Active Directory UPN. For more information, see User Naming Attributes on the MSDN site.Tableau Online The user-name is the email address that the user will use to sign in to Tableau Online. When you add a user to the site, Tableau Online sends an email invitation. The user can click the link in the invitation to sign in and update their full name and password. 
    /// </summary>
    /// <value>The name of the user. If the server uses local authentication, this can be any name. If you are using Active Directory authentication, or if you are using Tableau Online, there are specific requirements for the name.Tableau Server If Tableau Server uses Active Directory authentication, this must be the name of an existing user in Active Directory. If the user name is not unique across domains, you must include the domain as part of the user name (for example, example\\Adam or adam@example.com).Note: Active Directory specifies a user name using two attributes: sAMAccountName and userPrincipalName (UPN) prefix. For most Active Directory users, these attributes are the same. By default, if you are adding a user from Active Directory, the name that you provide in the user-name is matched against the Active Directory sAMAccountName attribute, which becomes the name that the user signs in to Tableau Server with. There are two exceptions: if the name that you provide is longer than 20 characters, or if the name that you provides includes an @ character, Tableau imports the user using the Active Directory UPN. For more information, see User Naming Attributes on the MSDN site.Tableau Online The user-name is the email address that the user will use to sign in to Tableau Online. When you add a user to the site, Tableau Online sends an email invitation. The user can click the link in the invitation to sign in and update their full name and password. </value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The site role to assign to the user. You can assign the following roles: Interactor, Publisher, SiteAdministrator, Unlicensed, UnlicensedWithPublish, Viewer, or ViewerWithPublish.Note: You cannot use the REST API to set a user to be a server administrator (ServerAdministrator site role). 
    /// </summary>
    /// <value>The site role to assign to the user. You can assign the following roles: Interactor, Publisher, SiteAdministrator, Unlicensed, UnlicensedWithPublish, Viewer, or ViewerWithPublish.Note: You cannot use the REST API to set a user to be a server administrator (ServerAdministrator site role). </value>
    [DataMember(Name="siteRole", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "siteRole")]
    public string SiteRole { get; set; }

    /// <summary>
    /// (Optional) The new authentication type for the user. You can assign the following values for this attribute: SAML (the user signs in using SAML) or ServerDefault (the user signs in using the authentication method that's set for the server). These values appear in the Authentication tab on the Settings page in Tableau Online—the SAML attribute value corresponds to Single sign-on, and the ServerDefault value corresponds to TableauID.Note: The authSetting attribute is available only if you are using Tableau Online. 
    /// </summary>
    /// <value>(Optional) The new authentication type for the user. You can assign the following values for this attribute: SAML (the user signs in using SAML) or ServerDefault (the user signs in using the authentication method that's set for the server). These values appear in the Authentication tab on the Settings page in Tableau Online—the SAML attribute value corresponds to Single sign-on, and the ServerDefault value corresponds to TableauID.Note: The authSetting attribute is available only if you are using Tableau Online. </value>
    [DataMember(Name="authSetting", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "authSetting")]
    public string AuthSetting { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddUserToSiteRequestUser {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
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
