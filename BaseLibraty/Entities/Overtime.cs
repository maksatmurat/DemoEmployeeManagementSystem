﻿using System.ComponentModel.DataAnnotations;

namespace BaseLibraty.Entities;

public class Overtime : OtherBaseEntity
{
    [Required]
    public DateTime StartDate { get; set; }
    [Required]
    public DateTime EndDate { get; set; }
    public int NumberOfDays => (EndDate - StartDate).Days;
    public OvertimeType? OvertimeType { get; set; }
    [Required]
    public int OvertimeTypeId { get; set; }


}
