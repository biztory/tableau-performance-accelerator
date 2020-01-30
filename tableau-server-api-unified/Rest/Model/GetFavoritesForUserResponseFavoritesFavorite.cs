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
  public class GetFavoritesForUserResponseFavoritesFavorite {
    /// <summary>
    /// Gets or Sets Workbook
    /// </summary>
    [DataMember(Name="workbook", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "workbook")]
    public GetFavoritesForUserResponseFavoritesFavoriteWorkbook Workbook { get; set; }

    /// <summary>
    /// Gets or Sets View
    /// </summary>
    [DataMember(Name="view", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "view")]
    public GetFavoritesForUserResponseFavoritesFavoriteView View { get; set; }

    /// <summary>
    /// Gets or Sets Datasource
    /// </summary>
    [DataMember(Name="datasource", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "datasource")]
    public GetFavoritesForUserResponseFavoritesFavoriteDatasource Datasource { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class GetFavoritesForUserResponseFavoritesFavorite {\n");
      sb.Append("  Workbook: ").Append(Workbook).Append("\n");
      sb.Append("  View: ").Append(View).Append("\n");
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
