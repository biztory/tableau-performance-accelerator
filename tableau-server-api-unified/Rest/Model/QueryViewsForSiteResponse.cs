﻿/* 
 * Tableau Server REST API
 *
 * AUTO GENERATED.
 *
 * OpenAPI spec version: 2.5.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.ComponentModel.DataAnnotations;

namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model
{
    /// <summary>
    /// QueryViewsForSiteResponse
    /// </summary>
    [DataContract]
    public partial class QueryViewsForSiteResponse : IEquatable<QueryViewsForSiteResponse>, IValidatableObject
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="QueryViewsForSiteResponse" /> class.
        /// </summary>
        /// <param name="Pagination">Pagination.</param>
        /// <param name="Views">Views.</param>
        public QueryViewsForSiteResponse(QueryViewsForSiteResponsePagination Pagination = default(QueryViewsForSiteResponsePagination), QueryViewsForSiteResponseViews Views = default(QueryViewsForSiteResponseViews))
        {
            this.Pagination = Pagination;
            this.Views = Views;
        }

        /// <summary>
        /// Gets or Sets Pagination
        /// </summary>
        [DataMember(Name = "pagination", EmitDefaultValue = false)]
        public QueryViewsForSiteResponsePagination Pagination { get; set; }

        /// <summary>
        /// Gets or Sets Views
        /// </summary>
        [DataMember(Name = "views", EmitDefaultValue = false)]
        public QueryViewsForSiteResponseViews Views { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class QueryViewsForSiteResponse {\n");
            sb.Append("  Pagination: ").Append(Pagination).Append("\n");
            sb.Append("  Views: ").Append(Views).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="input">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object input)
        {
            return this.Equals(input as QueryViewsForSiteResponse);
        }

        /// <summary>
        /// Returns true if QueryViewsForSiteResponse instances are equal
        /// </summary>
        /// <param name="input">Instance of QueryViewsForSiteResponse to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(QueryViewsForSiteResponse input)
        {
            if (input == null)
                return false;

            return
                (
                    this.Pagination == input.Pagination ||
                    (this.Pagination != null &&
                    this.Pagination.Equals(input.Pagination))
                ) &&
                (
                    this.Views == input.Views ||
                    (this.Views != null &&
                    this.Views.Equals(input.Views))
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                int hashCode = 41;
                if (this.Pagination != null)
                    hashCode = hashCode * 59 + this.Pagination.GetHashCode();
                if (this.Views != null)
                    hashCode = hashCode * 59 + this.Views.GetHashCode();
                return hashCode;
            }
        }

        /// <summary>
        /// To validate all properties of the instance
        /// </summary>
        /// <param name="validationContext">Validation context</param>
        /// <returns>Validation Result</returns>
        IEnumerable<System.ComponentModel.DataAnnotations.ValidationResult> IValidatableObject.Validate(ValidationContext validationContext)
        {
            yield break;
        }
    }

}

//using System;
//using System.Text;
//using System.Collections;
//using System.Collections.Generic;
//using System.Runtime.Serialization;
//using Newtonsoft.Json;

//namespace Biztory.EnterpriseToolkit.TableauServerUnifiedApi.Rest.Model {

//  /// <summary>
//  /// 
//  /// </summary>
//  [DataContract]
//  public class QueryViewsForSiteResponse {
//    /// <summary>
//    /// Gets or Sets Views
//    /// </summary>
//    [DataMember(Name="views", EmitDefaultValue=false)]
//    [JsonProperty(PropertyName = "views")]
//    public QueryViewsForSiteResponseViews Views { get; set; }


//    /// <summary>
//    /// Get the string presentation of the object
//    /// </summary>
//    /// <returns>String presentation of the object</returns>
//    public override string ToString()  {
//      var sb = new StringBuilder();
//      sb.Append("class QueryViewsForSiteResponse {\n");
//      sb.Append("  Views: ").Append(Views).Append("\n");
//      sb.Append("}\n");
//      return sb.ToString();
//    }

//    /// <summary>
//    /// Get the JSON string presentation of the object
//    /// </summary>
//    /// <returns>JSON string presentation of the object</returns>
//    public string ToJson() {
//      return JsonConvert.SerializeObject(this, Formatting.Indented);
//    }

//}
//}
