using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Reference;

[Index(nameof(UUID), IsUnique = true)]
public class BaseImage
{
    public int Id { get; set; }

    [Required]
    public Guid UUID { get; set; }
    public string ImageName { get; set; } = null!;
    public int SizeMB { get; set; }

    public string Edition{ get; set; } = null!;          // Windows 10, Windows 11, Windows Server 2022, etc
    public int BaseImageEditionId { get; set; }

    public string Version { get; set; } = null!;         // 1903, 1909, 2004, 20H2, etc
    public string Build { get; set; } = null!;           // 19042 ,19043, 19044, etc
    public string Release { get; set; } = null!;         // Home, Pro, Pro Education, Pro for Workstations, Education, Enterprise, IoT Enterprise, etc
    public string SupportedUntil { get; set; } = null!;  // date the product is supported until, ie - GAC

    public int CpuArchId { get; set; }

    public int BaseImageFileTypeId { get; set;}  // tba

    public int LanguageId { get; set; }
    public int LocaleId { get; set; }
    public int TransferMethodId { get; set; }
}