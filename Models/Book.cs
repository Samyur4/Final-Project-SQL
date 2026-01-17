using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Final_Project_1.Models;

[Index("Isbn", Name = "UQ__Books__447D36EAB65B40A7", IsUnique = true)]
public partial class Book
{
    [Key]
    [Column("BookID")]
    public int BookId { get; set; }

    [StringLength(200)]
    public string Title { get; set; } = null!;

    [Column("ISBN")]
    [StringLength(20)]
    public string? Isbn { get; set; }

    [Column("GenreID")]
    public int? GenreId { get; set; }

    [Column("PublisherID")]
    public int? PublisherId { get; set; }

    [ForeignKey("GenreId")]
    [InverseProperty("Books")]
    public virtual Genre? Genre { get; set; }

    [InverseProperty("Book")]
    public virtual ICollection<Loan> Loans { get; set; } = new List<Loan>();

    [ForeignKey("PublisherId")]
    [InverseProperty("Books")]
    public virtual Publisher? Publisher { get; set; }

    [ForeignKey("BookId")]
    [InverseProperty("Books")]
    public virtual ICollection<Author> Authors { get; set; } = new List<Author>();
}
