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
  public class AddWorkbookPermissionRequestPermissionsWorkbook {
    /// <summary>
    /// The <workbook> element is not required, but can be included for compatibility with earlier versions of the REST API. If the <workbook> element is included, the workbook-id value must match the workbook ID in the URI. Any other attributes in the <workbook> element are ignored
    /// </summary>
    /// <value>The <workbook> element is not required, but can be included for compatibility with earlier versions of the REST API. If the <workbook> element is included, the workbook-id value must match the workbook ID in the URI. Any other attributes in the <workbook> element are ignored</value>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddWorkbookPermissionRequestPermissionsWorkbook {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
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
