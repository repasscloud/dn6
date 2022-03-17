using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Public;

[Index(nameof(Lcid), IsUnique = true)]
public class Language
{
    public int Id { get; set; }
    [Required]
    public string Lcid { get; set; }
}