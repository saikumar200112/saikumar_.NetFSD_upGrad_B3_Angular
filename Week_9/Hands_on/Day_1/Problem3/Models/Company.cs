using System.Security.Cryptography.Pkcs;
using System.Text.Json.Serialization;

namespace WebApplication10.Models
{
    public class Company
    {
        public int CompanyId { get; set; }
        public string CompanyName { get; set; } = string.Empty;
        [JsonIgnore]
        public List<ContactInfo> Contacts { get; set; }
    }
}
