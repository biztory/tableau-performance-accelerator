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
  public class PublishDatasourceRequestDatasourceConnectionCredentials {
    /// <summary>
    /// (Optional) If the data source connection requires credentials, the <connectionCredentials> element is included and this attribute specifies the connection username. If the element is included but is not required, the server ignores the element and its attributes.
    /// </summary>
    /// <value>(Optional) If the data source connection requires credentials, the <connectionCredentials> element is included and this attribute specifies the connection username. If the element is included but is not required, the server ignores the element and its attributes.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// (Optional) If the data source connection requires credentials, the <connectionCredentials> element is included and this attribute specifies the connection password. If the element is included but is not required, the server ignores the element and its attributes.
    /// </summary>
    /// <value>(Optional) If the data source connection requires credentials, the <connectionCredentials> element is included and this attribute specifies the connection password. If the element is included but is not required, the server ignores the element and its attributes.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// (Optional) If the data source connection requires credentials, the <connectionCredentials> element is included. Setting this attribute to True instructs the server to save the credentials for when the data source is used.
    /// </summary>
    /// <value>(Optional) If the data source connection requires credentials, the <connectionCredentials> element is included. Setting this attribute to True instructs the server to save the credentials for when the data source is used.</value>
    [DataMember(Name="embed", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "embed")]
    public string Embed { get; set; }

    /// <summary>
    /// (Optional) If the data source connection is configured to use OAuth, set this to True to specify that the value of the name attribute in the <connectionCredentials> element is an OAuth username. In that case, no password is required and the value of the embed attribute specifies whether to embed the OAuth credential with the data source. For more information, see OAuth Connections in the Tableau Server documentation.
    /// </summary>
    /// <value>(Optional) If the data source connection is configured to use OAuth, set this to True to specify that the value of the name attribute in the <connectionCredentials> element is an OAuth username. In that case, no password is required and the value of the embed attribute specifies whether to embed the OAuth credential with the data source. For more information, see OAuth Connections in the Tableau Server documentation.</value>
    [DataMember(Name="oAuth", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "oAuth")]
    public string OAuth { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PublishDatasourceRequestDatasourceConnectionCredentials {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  Embed: ").Append(Embed).Append("\n");
      sb.Append("  OAuth: ").Append(OAuth).Append("\n");
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
