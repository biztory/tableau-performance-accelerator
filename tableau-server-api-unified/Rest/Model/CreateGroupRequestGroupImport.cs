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
  public class CreateGroupRequestGroupImport {
    /// <summary>
    /// Gets or Sets Source
    /// </summary>
    [DataMember(Name="source", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "source")]
    public string Source { get; set; }

    /// <summary>
    /// The domain of the Active Directory group to import.
    /// </summary>
    /// <value>The domain of the Active Directory group to import.</value>
    [DataMember(Name="domainName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "domainName")]
    public string DomainName { get; set; }

    /// <summary>
    /// The site role to assign to users who are imported from Active Directory. You can assign the following roles: Interactor, Publisher, SiteAdministrator, Unlicensed, UnlicensedWithPublish, Viewer, or ViewerWithPublish. Note: You cannot use the REST API to set a user to be a server administrator (ServerAdministrator site role). If you import a user from Active Directory whose name matches an existing user, the existing user might have a different site role than the one specified in the <import> element in the request body. The site role that you pass with Update Group can modify the existing user's site role, either by directly upgrading the user's site role or by combining the site role you pass with the user's exiting site role. The ordering of site roles for purposes of upgrading a role is as follows, from the role with the least capabilities to the role with the most capabilities: 1.Unlicensed  2.Viewer  3.Interactor  4.UnlicensedWithPublish  5.ViewerWithPublish  6.Publisher  7.SiteAdministrator The following list shows how roles are combined: 1. If a user's existing role is UnlicensedWithPublish and you pass Viewer, the user's new site role is ViewerWithPublish. 2. If a user's existing role is Viewer and you pass UnlicensedWithPublish, the user's new site role is ViewerWithPublish. 3. If the user's existing role is UnlicensedWithPublish or ViewerWithPublish role and you pass Interactor, the user's new site role is Publisher. 4. If the user's existing role is Interactor role and you pass UnlicensedWithPublish or ViewerWithPublish, the user's new site role is Publisher.
    /// </summary>
    /// <value>The site role to assign to users who are imported from Active Directory. You can assign the following roles: Interactor, Publisher, SiteAdministrator, Unlicensed, UnlicensedWithPublish, Viewer, or ViewerWithPublish. Note: You cannot use the REST API to set a user to be a server administrator (ServerAdministrator site role). If you import a user from Active Directory whose name matches an existing user, the existing user might have a different site role than the one specified in the <import> element in the request body. The site role that you pass with Update Group can modify the existing user's site role, either by directly upgrading the user's site role or by combining the site role you pass with the user's exiting site role. The ordering of site roles for purposes of upgrading a role is as follows, from the role with the least capabilities to the role with the most capabilities: 1.Unlicensed  2.Viewer  3.Interactor  4.UnlicensedWithPublish  5.ViewerWithPublish  6.Publisher  7.SiteAdministrator The following list shows how roles are combined: 1. If a user's existing role is UnlicensedWithPublish and you pass Viewer, the user's new site role is ViewerWithPublish. 2. If a user's existing role is Viewer and you pass UnlicensedWithPublish, the user's new site role is ViewerWithPublish. 3. If the user's existing role is UnlicensedWithPublish or ViewerWithPublish role and you pass Interactor, the user's new site role is Publisher. 4. If the user's existing role is Interactor role and you pass UnlicensedWithPublish or ViewerWithPublish, the user's new site role is Publisher.</value>
    [DataMember(Name="siteRole", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "siteRole")]
    public string SiteRole { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateGroupRequestGroupImport {\n");
      sb.Append("  Source: ").Append(Source).Append("\n");
      sb.Append("  DomainName: ").Append(DomainName).Append("\n");
      sb.Append("  SiteRole: ").Append(SiteRole).Append("\n");
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
