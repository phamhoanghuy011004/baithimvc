using Microsoft.EntityFrameworkCore;

namespace baithi.Models;

public class ApplicationDbContext: DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options) { }

    public DbSet<Customer> Customers { get; set; }
    public DbSet<ComicBook> ComicBooks { get; set; }
    public DbSet<Rental> Rentals { get; set; }
    public DbSet<RentalDetail> RentalDetails { get; set; }
}