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
  public class InitiateFileUploadResponsefileUpload {
    /// <summary>
    /// Gets or Sets UploadSessionId
    /// </summary>
    [DataMember(Name="uploadSessionId", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "uploadSessionId")]
    public string UploadSessionId { get; set; }

    /// <summary>
    /// Gets or Sets FileSize
    /// </summary>
    [DataMember(Name="fileSize", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "fileSize")]
    public string FileSize { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class InitiateFileUploadResponsefileUpload {\n");
      sb.Append("  UploadSessionId: ").Append(UploadSessionId).Append("\n");
      sb.Append("  FileSize: ").Append(FileSize).Append("\n");
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
