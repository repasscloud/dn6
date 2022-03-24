using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Shared;

[Index(nameof(Method), IsUnique = true)]
public class TransferMethod
{
    public int Id { get; set; }
    [Required]
    public string Method { get; set; } = null!;  // 'mc','ftp','stfp','ftpes','http','https','s3'
}
