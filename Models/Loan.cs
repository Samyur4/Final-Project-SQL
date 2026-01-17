using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_1.Models;

public partial class Loan
{
    [Key]
    [Column("LoanID")]
    public int LoanId { get; set; }

    [Column("BookID")]
    public int? BookId { get; set; }

    [Column("MemberID")]
    public int? MemberId { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime LoanDate { get; set; }

    [Column(TypeName = "datetime")]
    public DateTime? ReturnDate { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Loans")]
    public virtual Book? Book { get; set; }

    [InverseProperty("Loan")]
    public virtual ICollection<Fine> Fines { get; set; } = new List<Fine>();

    [ForeignKey("MemberId")]
    [InverseProperty("Loans")]
    public virtual Member? Member { get; set; }
}
