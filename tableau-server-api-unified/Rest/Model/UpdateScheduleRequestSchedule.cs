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
  public class UpdateScheduleRequestSchedule {
    /// <summary>
    /// The new name to give to the schedule.
    /// </summary>
    /// <value>The new name to give to the schedule.</value>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// An integer value between 1 and 100 that determines the default priority of the schedule if multiple tasks are pending in the queue. Higher numbers have higher priority.
    /// </summary>
    /// <value>An integer value between 1 and 100 that determines the default priority of the schedule if multiple tasks are pending in the queue. Higher numbers have higher priority.</value>
    [DataMember(Name="priority", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priority")]
    public string Priority { get; set; }

    /// <summary>
    /// The granularity of the schedule. Valid values are: - Hourly. Jobs can be scheduled to run one or more times per day at intervals specified in minutes or hours. - Daily. Jobs can be scheduled to run once per day at a specific time. - Weekly. Jobs can be scheduled to run one or more times per week. - Monthly. Jobs can be scheduled to run once per month on a specific day. The value you provide for schedule-frequency determines whether you must include an end-time value, and what is required in the contents of the <intervals> element.
    /// </summary>
    /// <value>The granularity of the schedule. Valid values are: - Hourly. Jobs can be scheduled to run one or more times per day at intervals specified in minutes or hours. - Daily. Jobs can be scheduled to run once per day at a specific time. - Weekly. Jobs can be scheduled to run one or more times per week. - Monthly. Jobs can be scheduled to run once per month on a specific day. The value you provide for schedule-frequency determines whether you must include an end-time value, and what is required in the contents of the <intervals> element.</value>
    [DataMember(Name="frequency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frequency")]
    public string Frequency { get; set; }

    /// <summary>
    /// Parallel to allow jobs associated with this schedule to run at the same time, or Serial to require the jobs to run one after the other.
    /// </summary>
    /// <value>Parallel to allow jobs associated with this schedule to run at the same time, or Serial to require the jobs to run one after the other.</value>
    [DataMember(Name="executionOrder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "executionOrder")]
    public string ExecutionOrder { get; set; }

    /// <summary>
    /// Gets or Sets FrequencyDetails
    /// </summary>
    [DataMember(Name="frequencyDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frequencyDetails")]
    public UpdateScheduleRequestScheduleFrequencyDetails FrequencyDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateScheduleRequestSchedule {\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  Priority: ").Append(Priority).Append("\n");
      sb.Append("  Frequency: ").Append(Frequency).Append("\n");
      sb.Append("  ExecutionOrder: ").Append(ExecutionOrder).Append("\n");
      sb.Append("  FrequencyDetails: ").Append(FrequencyDetails).Append("\n");
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
