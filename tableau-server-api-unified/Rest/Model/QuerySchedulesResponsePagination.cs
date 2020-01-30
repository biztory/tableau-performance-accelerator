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
  public class QuerySchedulesResponsePagination {
    /// <summary>
    /// pageNumber
    /// </summary>
    /// <value>pageNumber</value>
    [DataMember(Name="pageNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pageNumber")]
    public string PageNumber { get; set; }

    /// <summary>
    /// pageSize
    /// </summary>
    /// <value>pageSize</value>
    [DataMember(Name="pageSize", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pageSize")]
    public string PageSize { get; set; }

    /// <summary>
    /// totalAvailable
    /// </summary>
    /// <value>totalAvailable</value>
    [DataMember(Name="totalAvailable", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "totalAvailable")]
    public string TotalAvailable { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QuerySchedulesResponsePagination {\n");
      sb.Append("  PageNumber: ").Append(PageNumber).Append("\n");
      sb.Append("  PageSize: ").Append(PageSize).Append("\n");
      sb.Append("  TotalAvailable: ").Append(TotalAvailable).Append("\n");
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
