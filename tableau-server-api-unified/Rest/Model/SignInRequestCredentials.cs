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
  public class SignInRequestCredentials {
    /// <summary>
    /// The name of the user. The name and password in the <credentials> element can represent any user in the specified site. If the user is not an administrator, the user might have limited permissions to perform subsequent operations. Note: If the server is configured to use Active Directory authentication, and if the user name is not unique across domains, you must include the domain as part of the user name (for example, example\\Adam). 
    /// </summary>
    /// <value>The name of the user. The name and password in the <credentials> element can represent any user in the specified site. If the user is not an administrator, the user might have limited permissions to perform subsequent operations. Note: If the server is configured to use Active Directory authentication, and if the user name is not unique across domains, you must include the domain as part of the user name (for example, example\\Adam). </value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// The password.
    /// </summary>
    /// <value>The password.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// Gets or Sets Site
    /// </summary>
    [DataMember(Name="site", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "site")]
    public SignInRequestCredentialsSite Site { get; set; }

    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="user", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "user")]
    public SignInRequestCredentialsUser User { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class SignInRequestCredentials {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  Site: ").Append(Site).Append("\n");
      sb.Append("  User: ").Append(User).Append("\n");
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
