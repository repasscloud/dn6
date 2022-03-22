using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Reference;

[Index(nameof(Type), IsUnique = true)]
public class Executable
{
    public int Id { get; set; }
    [Required]
    public string Type { get; set; } = null!;  // msi, msix, exe, bat, ps1, etc
}