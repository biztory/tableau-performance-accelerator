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
  public class SignInRequestCredentialsSite {
    /// <summary>
    /// The URL of the site to sign in to. Note: The content URL is not the site name. Instead, the content URL is the value that in the server environment is referred to as the Site ID. The content URL used in this method is not the site ID LUID that's included in other methods. To determine the value to use for the contentUrl attribute, sign in to Tableau Server or Tableau Online and examine the value that appears after /site/ in the URL. For example, in the following URLs, the content URL is MarketingTeam: (Tableau Server) http://MyServer/#/site/MarketingTeam/projects (Tableau Online) https://online.tableau.com/#/site/MarketingTeam/workbooks The requirements for the <site> element are different depending on whether you're signing in to Tableau Server or Tableau Online. For Tableau Server, if the contentUrl attribute is an empty string, you are signed in to the default site. Note that you always sign in to a specific site, even if you don't specify a site when you sign in. For Tableau Online, you must include the <site> element and provide a value for the contentUrl attribute. If these are missing, the Sign In request will fail. 
    /// </summary>
    /// <value>The URL of the site to sign in to. Note: The content URL is not the site name. Instead, the content URL is the value that in the server environment is referred to as the Site ID. The content URL used in this method is not the site ID LUID that's included in other methods. To determine the value to use for the contentUrl attribute, sign in to Tableau Server or Tableau Online and examine the value that appears after /site/ in the URL. For example, in the following URLs, the content URL is MarketingTeam: (Tableau Server) http://MyServer/#/site/MarketingTeam/projects (Tableau Online) https://online.tableau.com/#/site/MarketingTeam/workbooks The requirements for the <site> element are different depending on whether you're signing in to Tableau Server or Tableau Online. For Tableau Server, if the contentUrl attribute is an empty string, you are signed in to the default site. Note that you always sign in to a specific site, even if you don't specify a site when you sign in. For Tableau Online, you must include the <site> element and provide a value for the contentUrl attribute. If these are missing, the Sign In request will fail. </value>
    [DataMember(Name="contentUrl", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "contentUrl")]
    public string ContentUrl { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SignInRequestCredentialsSite {\n");
      sb.Append("  ContentUrl: ").Append(ContentUrl).Append("\n");
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
