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
  public class QueryDatasourcePermissionsResponsePermissions {
    /// <summary>
    /// Gets or Sets Parent
    /// </summary>
    [DataMember(Name="parent", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "parent")]
    public QueryDatasourcePermissionsResponsePermissionsParent Parent { get; set; }

    /// <summary>
    /// Gets or Sets Datasource
    /// </summary>
    [DataMember(Name="datasource", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "datasource")]
    public QueryDatasourcePermissionsResponsePermissionsDatasource Datasource { get; set; }

    /// <summary>
    /// Gets or Sets GranteeCapabilities
    /// </summary>
    [DataMember(Name="granteeCapabilities", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "granteeCapabilities")]
    public AddProjectPermissionRequestPermissionsGranteeCapabilities GranteeCapabilities { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryDatasourcePermissionsResponsePermissions {\n");
      sb.Append("  Parent: ").Append(Parent).Append("\n");
      sb.Append("  Datasource: ").Append(Datasource).Append("\n");
      sb.Append("  GranteeCapabilities: ").Append(GranteeCapabilities).Append("\n");
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
