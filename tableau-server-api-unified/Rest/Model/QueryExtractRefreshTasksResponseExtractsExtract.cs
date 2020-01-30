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
  public class QueryExtractRefreshTasksResponseExtractsExtract {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Priority
    /// </summary>
    [DataMember(Name="priority", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priority")]
    public string Priority { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets Workbook
    /// </summary>
    [DataMember(Name="workbook", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workbook")]
    public QueryExtractRefreshTasksResponseExtractsExtractWorkbook Workbook { get; set; }

    /// <summary>
    /// Gets or Sets Datasource
    /// </summary>
    [DataMember(Name="datasource", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "datasource")]
    public QueryExtractRefreshTasksResponseExtractsExtractDatasource Datasource { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryExtractRefreshTasksResponseExtractsExtract {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Priority: ").Append(Priority).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Workbook: ").Append(Workbook).Append("\n");
      sb.Append("  Datasource: ").Append(Datasource).Append("\n");
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
