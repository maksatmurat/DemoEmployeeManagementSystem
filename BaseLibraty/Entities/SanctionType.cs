using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class SanctionType : OtherBaseEntity
{
    [JsonIgnore]
    public List<Sanction>? Sanctions { get; set; }
}
