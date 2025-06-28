using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class SanctionType : BaseEntity
{
    [JsonIgnore]
    public List<Sanction>? Sanctions { get; set; }
}
