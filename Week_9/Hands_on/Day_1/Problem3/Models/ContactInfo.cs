
using System.ComponentModel.DataAnnotations.Schema;
namespace WebApplication10.Models
{
    public class ContactInfo
    {
        public int ContactId { get; set; }
        public string FirstName { get; set; } 
        public string LastName { get; set; } 
        public string EmailId { get; set; }
        public long MobileNo { get; set; }
        public string Designation { get; set; }
        [ForeignKey("CompanyId")]
        public int CompanyId { get; set; }
        [ForeignKey("DepartmentId")]
        public int DepartmentId { get; set; }
        public Company Company { get; set; }

       
        public Department Department { get; set; }
    }
}
