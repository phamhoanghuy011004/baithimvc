using System.ComponentModel.DataAnnotations;

namespace baithi.Models;

public class ComicBook
{
    [Key]
    public int Id { get; set; }
    public string Title { get; set; }
    public string Author { get; set; }
    public decimal PricePerDay { get; set; }
}