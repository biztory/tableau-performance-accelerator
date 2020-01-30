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
  public class CreateScheduleRequestScheduleFrequencyDetailsIntervalsInterval {
    /// <summary>
    /// Gets or Sets IntervalExpression
    /// </summary>
    [DataMember(Name="interval-expression", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "interval-expression")]
    public string IntervalExpression { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class CreateScheduleRequestScheduleFrequencyDetailsIntervalsInterval {\n");
      sb.Append("  IntervalExpression: ").Append(IntervalExpression).Append("\n");
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
