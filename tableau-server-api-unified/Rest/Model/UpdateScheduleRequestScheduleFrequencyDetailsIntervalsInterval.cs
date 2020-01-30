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
  public class UpdateScheduleRequestScheduleFrequencyDetailsIntervalsInterval {
    /// <summary>
    /// A value that specifies the interval between jobs associated with the schedule. The value you specify here depends on the value specified in schedule-frequency. Hourly: The interval expression is only one of the following:hours=\"interval\" where interval is 1, 2, 4, 6, 8, or 12, representing how many hours between jobs. minutes=\"interval\" where interval is 15 or 30, representing how many minutes between jobs. You can specify an interval in hours or minutes, but not both. Daily: If the schedule frequency is Daily, no interval is specified. Any information specified in the <intervals> element is ignored. Weekly: The interval expression is weekDay=\"weekday\", where weekday is Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, or Saturday. You can specify multiple <interval> elements to indicate that scheduled jobs should run on multiple days during the week. Monthly: The interval expression is monthDay=\"day\", where day is either the day of the month (1, 2, etc.) or LastDay. 
    /// </summary>
    /// <value>A value that specifies the interval between jobs associated with the schedule. The value you specify here depends on the value specified in schedule-frequency. Hourly: The interval expression is only one of the following:hours=\"interval\" where interval is 1, 2, 4, 6, 8, or 12, representing how many hours between jobs. minutes=\"interval\" where interval is 15 or 30, representing how many minutes between jobs. You can specify an interval in hours or minutes, but not both. Daily: If the schedule frequency is Daily, no interval is specified. Any information specified in the <intervals> element is ignored. Weekly: The interval expression is weekDay=\"weekday\", where weekday is Sunday, Monday, Tuesday, Wednesday, Thursday, Friday, or Saturday. You can specify multiple <interval> elements to indicate that scheduled jobs should run on multiple days during the week. Monthly: The interval expression is monthDay=\"day\", where day is either the day of the month (1, 2, etc.) or LastDay. </value>
    [DataMember(Name="interval-expression", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "interval-expression")]
    public string IntervalExpression { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateScheduleRequestScheduleFrequencyDetailsIntervalsInterval {\n");
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
