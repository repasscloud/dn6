using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Reference;

[Index(nameof(UUID), nameof(Edition), IsUnique = true)]
public class BaseImageEdition
{
    public int Id { get; set; }

    [Required]
    public Guid UUID { get; set; }

    [Required]
    public string Edition { get; set; }  // Windows 10, Windows 11, Windows Server 2022, etc
}