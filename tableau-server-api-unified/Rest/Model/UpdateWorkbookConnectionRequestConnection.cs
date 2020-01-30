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
  public class UpdateWorkbookConnectionRequestConnection {
    /// <summary>
    /// The new server for the connection.
    /// </summary>
    /// <value>The new server for the connection.</value>
    [DataMember(Name="serverAddress", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serverAddress")]
    public string ServerAddress { get; set; }

    /// <summary>
    /// The new port for the connection.
    /// </summary>
    /// <value>The new port for the connection.</value>
    [DataMember(Name="serverPort", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "serverPort")]
    public string ServerPort { get; set; }

    /// <summary>
    /// The new username for the connection.
    /// </summary>
    /// <value>The new username for the connection.</value>
    [DataMember(Name="userName", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "userName")]
    public string UserName { get; set; }

    /// <summary>
    /// The new password for the connection.
    /// </summary>
    /// <value>The new password for the connection.</value>
    [DataMember(Name="password", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }

    /// <summary>
    /// True to embed the password; otherwise, False.
    /// </summary>
    /// <value>True to embed the password; otherwise, False.</value>
    [DataMember(Name="embedPassword", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "embedPassword")]
    public string EmbedPassword { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateWorkbookConnectionRequestConnection {\n");
      sb.Append("  ServerAddress: ").Append(ServerAddress).Append("\n");
      sb.Append("  ServerPort: ").Append(ServerPort).Append("\n");
      sb.Append("  UserName: ").Append(UserName).Append("\n");
      sb.Append("  Password: ").Append(Password).Append("\n");
      sb.Append("  EmbedPassword: ").Append(EmbedPassword).Append("\n");
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
