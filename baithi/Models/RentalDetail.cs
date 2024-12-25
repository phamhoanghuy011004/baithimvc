using System.ComponentModel.DataAnnotations;

namespace baithi.Models;

public class RentalDetail
{
    [Key]
    public int RetalDetailID { get; set; }
    public int RentalID { get; set; }
    public int ComicBookID { get; set; }
    public int Quantity { get; set; }
    public decimal PricePerDay { get; set; }
}