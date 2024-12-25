using Microsoft.AspNetCore.Mvc;
using baithi.Data;
using baithi.Models;
using ApplicationDbContext = baithi.Models.ApplicationDbContext; // Assuming your Customer model is in this namespace

public class CustomersController : Controller
{
    private readonly ApplicationDbContext _context;

    public CustomersController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: Customers/Register
    public IActionResult Register()
    {
        return View();
    }

    // POST: Customers/Register
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Register([Bind("FullName, PhoneNumber, RegisterDate")] Customer customer)
    {
        if (ModelState.IsValid)
        {
            // Set default RegisterDate if not provided
            customer.CreateAt = DateTime.Now; 

            _context.Add(customer);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index", "Home"); 
        }
        return View(customer);
    }
}