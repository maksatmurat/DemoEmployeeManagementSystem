using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class OvertimeType:BaseEntity
{
    [JsonIgnore]
    public List<Overtime>? Overtimes { get; set; }

}
