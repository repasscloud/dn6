using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Reference;

[Index(nameof(Method), IsUnique = true)]
public class UninstallProcess
{
    public int Id { get; set; }
    [Required]
    public string Method { get; set; }  // msi, exe, exe2, inno, script
}