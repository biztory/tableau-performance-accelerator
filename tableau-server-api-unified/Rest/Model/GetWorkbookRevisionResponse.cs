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
  public class GetWorkbookRevisionResponse {
    /// <summary>
    /// Gets or Sets Pagination
    /// </summary>
    [DataMember(Name="pagination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pagination")]
    public GetWorkbookRevisionResponsePagination Pagination { get; set; }

    /// <summary>
    /// Gets or Sets Revisions
    /// </summary>
    [DataMember(Name="revisions", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisions")]
    public GetWorkbookRevisionResponseRevisions Revisions { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetWorkbookRevisionResponse {\n");
      sb.Append("  Pagination: ").Append(Pagination).Append("\n");
      sb.Append("  Revisions: ").Append(Revisions).Append("\n");
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
