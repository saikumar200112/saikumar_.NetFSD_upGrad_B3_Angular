using System.Security.Cryptography.Pkcs;
using System.Text.Json.Serialization;

namespace WebApplication10.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; } = string.Empty;
        [JsonIgnore]
        public List<ContactInfo> Contacts { get; set; }
    }
}
