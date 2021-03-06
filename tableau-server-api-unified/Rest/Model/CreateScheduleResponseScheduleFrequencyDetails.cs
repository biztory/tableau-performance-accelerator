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
  public class CreateScheduleResponseScheduleFrequencyDetails {
    /// <summary>
    /// Gets or Sets FrequencyExpression
    /// </summary>
    [DataMember(Name="frequency-expression", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frequency-expression")]
    public string FrequencyExpression { get; set; }

    /// <summary>
    /// Gets or Sets Intervals
    /// </summary>
    [DataMember(Name="intervals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "intervals")]
    public CreateScheduleResponseScheduleFrequencyDetailsIntervals Intervals { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateScheduleResponseScheduleFrequencyDetails {\n");
      sb.Append("  FrequencyExpression: ").Append(FrequencyExpression).Append("\n");
      sb.Append("  Intervals: ").Append(Intervals).Append("\n");
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
