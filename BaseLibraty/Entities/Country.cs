using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class Country : BaseEntity
{
    [JsonIgnore]
    public List<City>? Cities { get; set; }
}
