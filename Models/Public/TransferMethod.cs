using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Public;

[Index(nameof(Method), IsUnique = true)]
public class TransferMethod
{
    public int Id { get; set; }
    [Required]
    public string Method { get; set; }
}

// public enum XftCode
// {
//     mc,
//     ftp,
//     sftp,
//     ftpes,
//     http,
//     https,
//     s3
// }
