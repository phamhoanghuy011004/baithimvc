using System.ComponentModel.DataAnnotations;

namespace baithi.Models;

public class Customer
{
    [Key]
    public int CustomerID { get; set; }
    public string FullName { get; set; }
    public string PhoneNumber { get; set; }
    public DateTime CreateAt { get; set; }
}