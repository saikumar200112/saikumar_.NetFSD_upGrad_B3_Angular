using System.Security.Cryptography.Pkcs;

namespace WebApplication6.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public ICollection<ContactInfo> Contacts { get; set; }
    }
}
