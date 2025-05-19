using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public string? Name { get; set; }
    //Relationship : One To Many
    [JsonIgnore]
    public List<Employee>? Employees { get; set; }

}
