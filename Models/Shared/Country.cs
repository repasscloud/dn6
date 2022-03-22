using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Shared;

[Index(nameof(Name), IsUnique = true)]
public class Country
{
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }
}
