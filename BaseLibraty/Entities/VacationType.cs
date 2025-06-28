using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class VacationType:BaseEntity
{
    [JsonIgnore]
    public List<Vacation>? Vacantions { get; set; }
}
