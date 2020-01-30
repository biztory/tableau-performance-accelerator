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
  public class QueryDatasourcesResponse {
    /// <summary>
    /// Gets or Sets Pagination
    /// </summary>
    [DataMember(Name="pagination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pagination")]
    public QueryDatasourcesResponsePagination Pagination { get; set; }

    /// <summary>
    /// Gets or Sets Datasources
    /// </summary>
    [DataMember(Name="datasources", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "datasources")]
    public QueryDatasourcesResponseDatasources Datasources { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryDatasourcesResponse {\n");
      sb.Append("  Pagination: ").Append(Pagination).Append("\n");
      sb.Append("  Datasources: ").Append(Datasources).Append("\n");
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
