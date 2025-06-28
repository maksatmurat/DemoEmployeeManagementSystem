using System.ComponentModel.DataAnnotations;

namespace BaseLibraty.Entities
{
    public class Vacation: OtherBaseEntity
    {
        [Required]
        public DateTime StartDate { get; set; }
        [Required]
        public int NumberOfDays { get; set; }

        [Required]
        public DateTime EndDate => StartDate.AddDays(NumberOfDays);
        public VacationType? VacationType { get; set; }
        public int VacationTypeId { get; set; }
    }
}