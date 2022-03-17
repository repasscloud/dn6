using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Models.Engine.Reference;

namespace Models.Engine.Public;

[Index(nameof(UUID), nameof(UID), IsUnique = true)]
public class Application
{
    public int Id { get; set; }
    public Guid UUID { get; set; }

    public string UID { get; set; }

    public string LastUpdate { get; set; }
    public ApplicationCategory ApplicationCategory { get; set; }
    public string Publisher { get; set; }
    public string Name { get; set; }
    public string Version { get; set; }
    public string Copyright { get; set; }
    public bool LicenseAcceptRequired { get; set; }
    public CpuArch CpuArch { get; set; }
    public string Filename { get; set; }
    public string Sha256 { get; set; }
    public string FollowUri { get; set; }
    public string AbsoluteUri { get; set; }
    public string Switches { get; set; }
    public string DisplayName { get; set; }
    public string DisplayPublisher { get; set; }
    public string DisplayVersion { get; set; }
    public DetectMethod DetectMethod { get; set; }
    public string DetectScript { get; set; }
    public string DetectValue { get; set; }
    public UninstallMethod UninstallMethod { get; set; }
    public string UninstallCmd { get; set; }
    public string UninstallArgs { get; set; }
    public string Homepage { get; set; }
    public string Icon { get; set; }
    public string Docs { get; set; }
    public string License { get; set; }
    public string[] Tags { get; set; }
    public string Summary { get; set; }
    public bool RebootRequired { get; set; }
    
    public Lcid Lcid { get; set; }
    public XftCode XftCode { get; set; }
    public Locale Locale { get; set; }
    public string Repo { get; set; }
    public string UriPath { get; set; }
    public bool Enabled { get; set; }
    public string[] DependsOn { get; set; }
    public int? VirusTotalScanResultsId { get; set; }
    public int? ExploitReportId { get; set; }
}
