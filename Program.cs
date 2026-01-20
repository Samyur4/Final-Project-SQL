using Final_Project_1.Data;
using Final_Project_1.Models;
using Microsoft.EntityFrameworkCore;

using var db = new LibraryDbContext();

if (!db.Members.Any(m => m.Email == "niko@example.com"))
{
    var newMember = new Member { FirstName = "Nikoloz", LastName = "T", Email = "niko@example.com" };
    db.Members.Add(newMember);
}

if (!db.Genres.Any(g => g.Name == "Tech"))
{
    var newGenre = new Genre { Name = "Tech" };
    db.Genres.Add(newGenre);
}

if (!db.Staff.Any(s => s.FullName == "Lasha T"))
{
    var newStaff = new Staff { FullName = "Lasha T", Position = "Security" };
    db.Staff.Add(newStaff);
}

db.SaveChanges();

var filteredBooks = db.Books
    .Where(b => b.Genre != null && b.Genre.Name == "Fiction")
    .OrderBy(b => b.Title)
    .ToList();

var updateMember = db.Members.FirstOrDefault(m => m.Email == "john@example.com");
if (updateMember != null)
{
    updateMember.LastName = "Smith-Updated";
    db.SaveChanges();
}

var deleteFine = db.Fines.FirstOrDefault();
if (deleteFine != null)
{
    db.Fines.Remove(deleteFine);
    db.SaveChanges();
}

var bookDetails = db.Books
    .Select(b => new {
        b.Title,
        GenreName = b.Genre != null ? b.Genre.Name : "No Genre",
        Authors = b.Authors.Select(a => a.FullName)
    }).ToList();

var genreStats = db.Books
    .GroupBy(b => b.Genre != null ? b.Genre.Name : "No Genre")
    .Select(g => new {
        Genre = g.Key,
        Count = g.Count()
    }).ToList();

foreach (var stat in genreStats)
{
    Console.WriteLine($"{stat.Genre}: {stat.Count}");
}