using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Engine.Private;

[Index(nameof(UUID), nameof(HashScanned), IsUnique = true)]
public class VirusTotalScan
{
    public int Id { get; set; }
    
    [Required]
    public Guid UUID { get; set; }

    [Required]
    public string HashScanned { get; set; }    // SHA256

    [Required]
    public string Filename { get; set; }    // filename of object scanned
    public string Tlsh { get; set; }  // $response.data.attributes.tlsh
    public string Vhash { get; set; }  // $response.data.attributes.vhash
    public int StatsHarmless { get; set; }  // $response.data.attributes.last_analysis_stats.harmless
    public int StatsTypeUnsupported { get; set; }  // $response.data.attributes.last_analysis_stats.type-unsupported
    public int StatsSuspicious { get; set; }  // $response.data.attributes.last_analysis_stats.suspicious
    public int StatsConfirmedTimeout { get; set; }  // $response.data.attributes.last_analysis_stats.confirmed-timeout
    public int StatsTimeout { get; set; }  // $response.data.attributes.last_analysis_stats.timeout
    public int StatsFailure { get; set; }  // $response.data.attributes.last_analysis_stats.failure
    public int StatsMalicious { get; set; }  // $response.data.attributes.last_analysis_stats.malicious
    public int StatsUndetected { get; set; }  // $response.data.attributes.last_analysis_stats.undetected
    public int StatsTotalCount { get; set; }  // $total = $harmless + $type_unsupported + $suspicious + $confirmed_timeout + $timeout + $failure + $malicious + $undetected
    public int StatsSafetyPercentage { get; set; }  // $percent_safe = [int]((($harmless+$undetected)/$total) * 100)
    public bool IsSafe { get; set; }  // anything less than 51% safe is $false
}
