using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Public;

[Index(nameof(ProviderCode), IsUnique = true)]
public class Locale
{
    public int Id { get; set; }
    [Required]
    public string Provider { get; set; }
    public string ProviderCode { get; set; }
}