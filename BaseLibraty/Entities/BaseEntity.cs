﻿using System.ComponentModel.DataAnnotations;

namespace BaseLibraty.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    [Required]
    public string? Name { get; set; } = string.Empty;

}
