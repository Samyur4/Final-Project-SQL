using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_1.Models;

public partial class Branch
{
    [Key]
    [Column("BranchID")]
    public int BranchId { get; set; }

    [StringLength(100)]
    public string BranchName { get; set; } = null!;

    [StringLength(200)]
    public string? Location { get; set; }
}
