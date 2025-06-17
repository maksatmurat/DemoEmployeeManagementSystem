using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class Town:BaseEntity
{
    [JsonIgnore]
    public List<Employee>? Employees { get; set; }
    public City? City { get; set; }
    public int CityId { get; set; }
}
