using System.ComponentModel.DataAnnotations;

namespace BaseLibraty.Entities;

public class Sanction : OtherBaseEntity
{
    [Required]
    public DateTime Date { get; set; }
    [Required]
    public string Punishment { get; set; } = string.Empty;
    [Required]
    public DateTime PunishmentDate { get; set; }
    [Required]
    public int SanctionTypeId { get; set; }
    public SanctionType? SanctionType { get; set; }
}
