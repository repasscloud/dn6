using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Reference;

[Index(nameof(FileType), IsUnique = true)]
public class BaseImageFileType
{
    public int Id { get; set; }

    [Required]
    public string FileType { get; set; }  // WIM, ISO, ZIP, SWM, etc.
}