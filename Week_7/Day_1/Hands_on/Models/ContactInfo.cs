using System.ComponentModel.DataAnnotations;
namespace WebApplication1.Models
{
    public class ContactInfo
    {
        [Required]
        public int ContactId { get; set; }
        [Required]
        [StringLength(20,MinimumLength =3)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required]
        public string CompanyName { get; set; }
        [Required]
        [EmailAddress]
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        [Required]
        public string Designation { get; set; }
    }
}
