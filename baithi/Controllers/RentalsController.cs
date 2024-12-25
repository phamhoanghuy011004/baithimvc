using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baithi.Data;
using baithi.Models;
using ApplicationDbContext = baithi.Models.ApplicationDbContext; // Assuming your models are in this namespace

public class RentalsController : Controller
{
    private readonly ApplicationDbContext _context;

    public RentalsController(ApplicationDbContext context)
    {
        _context = context;
    }

    public IActionResult Create()
    {
        ViewBag.Customers = _context.Customers.ToList();
        ViewBag.ComicBooks = _context.ComicBooks.ToList();
        return View();
    }

    // POST: Rentals/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create(int customerId, DateTime rentalDate, DateTime returnDate, int comicBookId, int quantity)
    {
        if (ModelState.IsValid)
        {
            var rental = new Rental
            {
                CustomerID = customerId,
                RentalDate = rentalDate,
                ReturnDate = returnDate,
                Status = "Dang thue"
            };
            _context.Rentals.Add(rental);
            await _context.SaveChangesAsync();

            var comicBook = await _context.ComicBooks.FindAsync(comicBookId);

            var rentalDetail = new RentalDetail
            {
                RentalID = rental.RentalID,
                ComicBookID = comicBookId,
                Quantity = quantity,
                PricePerDay = comicBook.PricePerDay
            };
            _context.RentalDetails.Add(rentalDetail);
            await _context.SaveChangesAsync();

            return RedirectToAction("Index", "ComicBooks");
        }
        return View();
    }
}
