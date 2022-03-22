using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Shared;

[Index(nameof(Lcid), IsUnique = true)]
public class Language
{
    public int Id { get; set; }
    [Required]
    public string Lcid { get; set; } = null!;
}