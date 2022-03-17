using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Shared;

[Index(nameof(Method), IsUnique = true)]
public class PackageDetection
{
    public int Id { get; set; }
    [Required]
    public string Method { get; set; }  // registry, fileversion, file, script
}