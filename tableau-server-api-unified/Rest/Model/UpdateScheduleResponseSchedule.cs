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
  public class UpdateScheduleResponseSchedule {
    /// <summary>
    /// Gets or Sets Id
    /// </summary>
    [DataMember(Name="id", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "id")]
    public string Id { get; set; }

    /// <summary>
    /// Gets or Sets Name
    /// </summary>
    [DataMember(Name="name", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "name")]
    public string Name { get; set; }

    /// <summary>
    /// Gets or Sets State
    /// </summary>
    [DataMember(Name="state", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "state")]
    public string State { get; set; }

    /// <summary>
    /// Gets or Sets Priority
    /// </summary>
    [DataMember(Name="priority", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "priority")]
    public string Priority { get; set; }

    /// <summary>
    /// Gets or Sets CreatedAt
    /// </summary>
    [DataMember(Name="createdAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "createdAt")]
    public string CreatedAt { get; set; }

    /// <summary>
    /// Gets or Sets UpdatedAt
    /// </summary>
    [DataMember(Name="updatedAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "updatedAt")]
    public string UpdatedAt { get; set; }

    /// <summary>
    /// Gets or Sets Type
    /// </summary>
    [DataMember(Name="type", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "type")]
    public string Type { get; set; }

    /// <summary>
    /// Gets or Sets Frequency
    /// </summary>
    [DataMember(Name="frequency", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frequency")]
    public string Frequency { get; set; }

    /// <summary>
    /// Gets or Sets NextRunAt
    /// </summary>
    [DataMember(Name="nextRunAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "nextRunAt")]
    public string NextRunAt { get; set; }

    /// <summary>
    /// Gets or Sets EndScheduleAt
    /// </summary>
    [DataMember(Name="endScheduleAt", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "endScheduleAt")]
    public string EndScheduleAt { get; set; }

    /// <summary>
    /// Gets or Sets ExecutionOrder
    /// </summary>
    [DataMember(Name="executionOrder", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "executionOrder")]
    public string ExecutionOrder { get; set; }

    /// <summary>
    /// Gets or Sets FrequencyDetails
    /// </summary>
    [DataMember(Name="frequencyDetails", EmitDefaultValue=false)]
    [JsonProperty(PropertyName = "frequencyDetails")]
    public UpdateScheduleResponseScheduleFrequencyDetails FrequencyDetails { get; set; }


    /// <summary>
    /// Get the string presentation of the object
    /// </summary>
    /// <returns>String presentation of the object</returns>
    public override string ToString()  {
      var sb = new StringBuilder();
      sb.Append("class UpdateScheduleResponseSchedule {\n");
      sb.Append("  Id: ").Append(Id).Append("\n");
      sb.Append("  Name: ").Append(Name).Append("\n");
      sb.Append("  State: ").Append(State).Append("\n");
      sb.Append("  Priority: ").Append(Priority).Append("\n");
      sb.Append("  CreatedAt: ").Append(CreatedAt).Append("\n");
      sb.Append("  UpdatedAt: ").Append(UpdatedAt).Append("\n");
      sb.Append("  Type: ").Append(Type).Append("\n");
      sb.Append("  Frequency: ").Append(Frequency).Append("\n");
      sb.Append("  NextRunAt: ").Append(NextRunAt).Append("\n");
      sb.Append("  EndScheduleAt: ").Append(EndScheduleAt).Append("\n");
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
