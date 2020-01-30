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
  public class QueryViewsForSiteResponseViews : QueryViewsForSiteResponseViewsView {

    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class QueryViewsForSiteResponseViews {\n");
      sb.Append("}\n");
      return sb.ToString();
    }

        /// <summary>
        /// Gets or Sets Views
        /// </summary>
        [DataMember(Name = "view", EmitDefaultValue = false)]
        public List<QueryViewsForSiteResponseViewsView> Views { get; set; }


        /// <summary>
        /// Get the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson() {
      return JsonConvert.SerializeObject(this, Formatting.Indented);
    }

}
}
