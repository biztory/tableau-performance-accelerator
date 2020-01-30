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
  public class AddWorkbookToFavoritesResponseFavoritesFavorite {
    /// <summary>
    /// Gets or Sets Label
    /// </summary>
    [DataMember(Name="label", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "label")]
    public string Label { get; set; }

    /// <summary>
    /// Gets or Sets Workbook
    /// </summary>
    [DataMember(Name="workbook", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workbook")]
    public AddWorkbookToFavoritesResponseFavoritesFavoriteWorkbook Workbook { get; set; }

    /// <summary>
    /// Gets or Sets View
    /// </summary>
    [DataMember(Name="view", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "view")]
    public AddWorkbookToFavoritesResponseFavoritesFavoriteView View { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class AddWorkbookToFavoritesResponseFavoritesFavorite {\n");
      sb.Append("  Label: ").Append(Label).Append("\n");
      sb.Append("  Workbook: ").Append(Workbook).Append("\n");
      sb.Append("  View: ").Append(View).Append("\n");
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
