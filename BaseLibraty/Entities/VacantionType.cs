using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class VacantionType:BaseEntity
{
    [JsonIgnore]
    public List<Vacantion>? Vacantions { get; set; }
}
