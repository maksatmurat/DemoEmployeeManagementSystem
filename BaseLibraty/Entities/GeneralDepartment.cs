using System.Text.Json.Serialization;

namespace BaseLibraty.Entities;

public class GeneralDepartment:BaseEntity
{
    [JsonIgnore]
    public List<Department>? Departments { get; set; }
}
