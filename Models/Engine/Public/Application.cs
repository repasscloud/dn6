using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Public;

[Index(nameof(UUID), nameof(UID), IsUnique = true)]
public class Application
{
    public int Id { get; set; }

    [Required]
    public Guid UUID { get; set; }

    [Required]
    public string UID { get; set; } = null!;
    public string LastUpdate { get; set; } = null!;  // yyyyMMdd

    [Required]
    public int ApplicationCategoryId { get; set; }

    [Required]
    public string Publisher { get; set; } = null!;

    [Required]
    public string Name { get; set; } = null!;

    [Required]
    public string Version { get; set; } = null!;
    public string Copyright { get; set; } = null!;
    public bool LicenseAcceptRequired { get; set; }
    public bool RebootRequired { get; set; }
    public int LanguageId { get; set; }

    [Required]
    public int CpuArchId { get; set; }

    [Required]
    public string Filename { get; set; } = null!;

    [Required]
    public string Sha256 { get; set; } = null!;
    public string FollowUri { get; set; } = null!;
    public string AbsoluteUri { get; set; } = null!;

    public int ExecutableId { get; set; }               // msi, exe, msix, zip, script
    public string InstallCmd { get; set; } = null!;
    public string? InstallArgs { get; set; }
    public string? InstallScript { get; set; }          // ie - adobe that requires an install script to be passed to the pre-requirements first
    public string? DisplayName { get; set; }
    public string? DisplayPublisher { get; set; }
    public string? DisplayVersion { get; set; }
    public int PackageDetectionId { get; set; }
    public string? DetectScript { get; set; }
    public string? DetectValue { get; set; }
    public int UninstallProcessId { get; set; }         // UninstallProcessId of '1' means "does not uninstall" -> drivers, for example
    public string? UninstallCmd { get; set; }
    public string? UninstallArgs { get; set; }
    public string? UninstallScript { get; set; }

    public string Homepage { get; set; } = null!;
    public string Icon { get; set; } = null!;
    public string? Docs { get; set; }
    public string? License { get; set; }
    public string[] Tags { get; set; } = null!;
    public string Summary { get; set; } = null!;

    public int TransferMethodId { get; set; }           // mc, ftp, sftp, ftpes, http, https, s3, etc
    public int LocaleId { get; set; }                   // provider and the place
    public string UriPath { get; set; } = null!;

    public bool Enabled { get; set; }
    public string[]? DependsOn { get; set; }

    public int? VirusTotalScanResultsId { get; set; }
    public int? ExploitReportId { get; set; }
}
