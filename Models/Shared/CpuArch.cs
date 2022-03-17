using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Shared;

[Index(nameof(Arch), IsUnique = true)]
public class CpuArch
{
    public int Id { get; set; }

    [Required]
    public string Arch { get; set; }  // x86, x64, arm64, aarch32, aarch64
}