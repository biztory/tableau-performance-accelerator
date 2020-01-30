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
  public class PublishDatasourceRequestDatasource {
    /// <summary>
    ///  The name to assign to the data source when it is saved on the server.
    /// </summary>
    /// <value> The name to assign to the data source when it is saved on the server.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets ConnectionCredentials
    /// </summary>
    [DataMember(Name="connectionCredentials", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "connectionCredentials")]
    public PublishDatasourceRequestDatasourceConnectionCredentials ConnectionCredentials { get; set; }

    /// <summary>
    /// Gets or Sets Project
    /// </summary>
    [DataMember(Name="project", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "project")]
    public PublishDatasourceRequestDatasourceProject Project { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class PublishDatasourceRequestDatasource {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  ConnectionCredentials: ").Append(ConnectionCredentials).Append("\n");
      sb.Append("  Project: ").Append(Project).Append("\n");
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
