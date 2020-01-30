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
  public class UpdateScheduleRequestScheduleFrequencyDetails {
    /// <summary>
    /// The time of day on which scheduled jobs should run (or if the frequency is hourly, on which they should start being run), in the format HH:MM:SS (for example, 18:30:00). This value is required for all schedule frequencies.
    /// </summary>
    /// <value>The time of day on which scheduled jobs should run (or if the frequency is hourly, on which they should start being run), in the format HH:MM:SS (for example, 18:30:00). This value is required for all schedule frequencies.</value>
    [DataMember(Name="start", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "start")]
    public string Start { get; set; }

    /// <summary>
    /// If the schedule frequency is Hourly, the time of day on which scheduled jobs should stop being run, in the format HH:MM:SS (for example, 23:30:00). Hourly jobs will occur at the specified intervals between the start time and the end time. For other schedule frequencies, this value is not required; if the attribute is included, it is ignored.
    /// </summary>
    /// <value>If the schedule frequency is Hourly, the time of day on which scheduled jobs should stop being run, in the format HH:MM:SS (for example, 23:30:00). Hourly jobs will occur at the specified intervals between the start time and the end time. For other schedule frequencies, this value is not required; if the attribute is included, it is ignored.</value>
    [DataMember(Name="end", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "end")]
    public string End { get; set; }

    /// <summary>
    /// Gets or Sets Intervals
    /// </summary>
    [DataMember(Name="intervals", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "intervals")]
    public UpdateScheduleRequestScheduleFrequencyDetailsIntervals Intervals { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateScheduleRequestScheduleFrequencyDetails {\n");
      sb.Append("  Start: ").Append(Start).Append("\n");
      sb.Append("  End: ").Append(End).Append("\n");
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
