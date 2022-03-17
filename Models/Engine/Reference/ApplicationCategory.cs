using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Reference;

[Index(nameof(Category), IsUnique = true)]
public class ApplicationCategory
{
    public int Id { get; set; }
    [Required]
    public string Category { get; set; }
}