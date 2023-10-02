using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Bulky.Models;

public class Company
{
    [Key]
    public int Id { get; set; }
    [Required]
    [MaxLength(30)]
    public string Name { get; set; }
    [DisplayName("Street Address")]
    [MaxLength(30)]
    public string StreetAddress { get; set; }
    [MaxLength(30)]
    public string City { get; set; }
    [MaxLength(30)]
    public string State { get; set; }
    [DisplayName("Postal Code")]
    [MaxLength(30)]
    public string PostalCode { get; set; }
    [DisplayName("Phone Number")]
    [MaxLength(30)]
    public string PhoneNumber { get; set; }
    
}