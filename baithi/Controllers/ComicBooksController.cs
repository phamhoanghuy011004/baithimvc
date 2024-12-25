using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using baithi.Data;
using baithi.Models;
using ApplicationDbContext = baithi.Models.ApplicationDbContext; // Assuming your ComicBook model is in this namespace

public class ComicBooksController : Controller
{
    private readonly ApplicationDbContext _context;

    public ComicBooksController(ApplicationDbContext context)
    {
        _context = context;
    }

    // GET: ComicBooks
    public async Task<IActionResult> Index()
    {
        return View(await _context.ComicBooks.ToListAsync());
    }

    // GET: ComicBooks/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ComicBooks/Create
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([Bind("Title, Author, Publisher, ReleaseDate, Price")] ComicBook comicBook)
    {
        if (ModelState.IsValid)
        {
            _context.Add(comicBook);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    // GET: ComicBooks/Edit/5
    public async Task<IActionResult> Edit(int? id)
    {
        if (id == null || _context.ComicBooks == null)
        {
            return NotFound();
        }

        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook == null)
        {
            return NotFound();
        }
        return View(comicBook);
    }

    // POST: ComicBooks/Edit/5
    // To protect from overposting attacks, enable the specific properties you want to bind to.
    // For more details, see https://go.microsoft.com/fwlink/?LinkId=317598.
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(int id, [Bind("Id, Title, Author, Publisher, ReleaseDate, Price")] ComicBook comicBook)
    {
        if (id != comicBook.Id)
        {
            return NotFound();
        }

        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(comicBook);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ComicBookExists(comicBook.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToAction(nameof(Index));
        }
        return View(comicBook);
    }

    // GET: ComicBooks/Delete/5
    public async Task<IActionResult> Delete(int? id)
    {
        if (id == null || _context.ComicBooks == null)
        {
            return NotFound();
        }

        var comicBook = await _context.ComicBooks
            .FirstOrDefaultAsync(m => m.Id == id);
        if (comicBook == null)
        {
            return NotFound();
        }

        return View(comicBook);
    }

    // POST: ComicBooks/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(int id)
    {
        if (_context.ComicBooks == null)
        {
            return Problem("Entity set 'ApplicationDbContext.ComicBooks'  is null.");
        }
        var comicBook = await _context.ComicBooks.FindAsync(id);
        if (comicBook != null)
        {
            _context.ComicBooks.Remove(comicBook);
        }

        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }

    private bool ComicBookExists(int id)
    {
        return (_context.ComicBooks?.Any(e => e.Id == id)).GetValueOrDefault();
    }
}