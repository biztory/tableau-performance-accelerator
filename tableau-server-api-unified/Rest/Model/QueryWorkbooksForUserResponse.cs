﻿using System;
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
  public class QueryWorkbooksForUserResponse {
    /// <summary>
    /// Gets or Sets Pagination
    /// </summary>
    [DataMember(Name="pagination", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "pagination")]
    public QueryWorkbooksForUserResponsePagination Pagination { get; set; }

    /// <summary>
    /// Gets or Sets Workbooks
    /// </summary>
    [DataMember(Name="workbooks", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workbooks")]
    public QueryWorkbooksForUserResponseWorkbooks Workbooks { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryWorkbooksForUserResponse {\n");
      sb.Append("  Pagination: ").Append(Pagination).Append("\n");
      sb.Append("  Workbooks: ").Append(Workbooks).Append("\n");
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
