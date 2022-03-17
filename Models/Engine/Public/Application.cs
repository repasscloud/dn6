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
    public string UID { get; set; }

    public string LastUpdate { get; set; }

    [Required]
    public int ApplicationCategoryId { get; set; }

    [Required]
    public string Publisher { get; set; }

    [Required]
    public string Name { get; set; }

    [Required]
    public string Version { get; set; }
    public string Copyright { get; set; }
    public bool LicenseAcceptRequired { get; set; }

    [Required]
    public int CpuArchId { get; set; }

    [Required]
    public string Filename { get; set; }
    public string Sha256 { get; set; }
    public string FollowUri { get; set; }
    public string AbsoluteUri { get; set; }

    public int ExecutableId { get; set; }  // msi, exe, msix, etc.
    public string? Switches { get; set; }
    public string? DisplayName { get; set; }
    public string? DisplayPublisher { get; set; }
    public string? DisplayVersion { get; set; }
    public int PackageDetectionId { get; set; }
    public string? DetectScript { get; set; }
    public string? DetectValue { get; set; }
    public int UninstallProcessId { get; set; }
    public string? UninstallCmd { get; set; }
    public string? UninstallArgs { get; set; }
    public string Homepage { get; set; }
    public string Icon { get; set; }
    public string? Docs { get; set; }
    public string? License { get; set; }
    public string[] Tags { get; set; }
    public string Summary { get; set; }
    public bool RebootRequired { get; set; }
    public int LanguageId{ get; set; }
    public int TransferMethodId { get; set; }
    public int LocaleId { get; set; }
    public string Repo { get; set; }
    public string UriPath { get; set; }
    public bool Enabled { get; set; }
    public string[] DependsOn { get; set; }
    public int? VirusTotalScanResultsId { get; set; }
    public int? ExploitReportId { get; set; }
}


public enum CpuArch
{
    x86,
    x64,
    aarch32,
    aarch64,
    arm64
}