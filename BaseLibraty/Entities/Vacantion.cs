using System.ComponentModel.DataAnnotations;

namespace BaseLibraty.Entities
{
    public class Vacantion: OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);
        public VacantionType? VacantionType { get; set; }
        public int VacantionTypeId { get; set; }
    }
}