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
  public class GetDatasourceRevisionResponseRevision {
    /// <summary>
    /// Gets or Sets CreatedAt
    /// </summary>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets RevisionNumber
    /// </summary>
    [DataMember(Name="revisionNumber", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "revisionNumber")]
    public string RevisionNumber { get; set; }

    /// <summary>
    /// Gets or Sets IsDeleted
    /// </summary>
    [DataMember(Name="isDeleted", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "isDeleted")]
    public string IsDeleted { get; set; }

    /// <summary>
    /// Gets or Sets User
    /// </summary>
    [DataMember(Name="user", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "user")]
    public GetDatasourceRevisionResponseRevisionsRevisionUser User { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetDatasourceRevisionResponseRevision {\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  RevisionNumber: ").Append(RevisionNumber).Append("\n");
      sb.Append("  IsDeleted: ").Append(IsDeleted).Append("\n");
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
