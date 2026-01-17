using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_1.Models;

public partial class Fine
{
    [Key]
    [Column("FineID")]
    public int FineId { get; set; }

    [Column("LoanID")]
    public int? LoanId { get; set; }

    [Column(TypeName = "decimal(10, 2)")]
    public decimal Amount { get; set; }

    public bool? IsPaid { get; set; }

    [ForeignKey("LoanId")]
    [InverseProperty("Fines")]
    public virtual Loan? Loan { get; set; }
}
