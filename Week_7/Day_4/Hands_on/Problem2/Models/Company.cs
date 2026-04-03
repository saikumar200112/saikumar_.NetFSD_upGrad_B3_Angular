using System.Security.Cryptography.Pkcs;

namespace WebApplication6.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; }
        public ICollection<ContactInfo> Contacts { get; set; }
    }
       
      
}
