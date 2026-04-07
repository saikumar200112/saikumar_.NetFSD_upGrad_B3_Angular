using Microsoft.Data.SqlClient;
using WebApplication7.Models;
using Dapper;
namespace WebApplication7.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly string _connectionString;

        public ContactRepository(IConfiguration config)
        {
            _connectionString = config.GetConnectionString("DefaultConnection");
        }

        private SqlConnection GetConnection() => new SqlConnection(_connectionString);

        public IEnumerable<ContactInfo> GetAllContacts()
        {
            string sql = @"SELECT c.*, co.CompanyName, d.DepartmentName 
                       FROM ContactInfo c
                       JOIN Company co ON c.CompanyId = co.CompanyId
                       JOIN Department d ON c.DepartmentId = d.DepartmentId";
            using var db = GetConnection();
            return db.Query<ContactInfo>(sql);
        }

        public ContactInfo GetContactById(int id)
        {
            string sql = "SELECT * FROM ContactInfo WHERE ContactId = @Id";
            using var db = GetConnection();
            return db.QueryFirstOrDefault<ContactInfo>(sql, new { Id = id });
        }

        public void AddContact(ContactInfo contact)
        {
            string sql = @"INSERT INTO ContactInfo (FirstName, LastName, EmailId, MobileNo, Designation, CompanyId, DepartmentId) 
                       VALUES (@FirstName, @LastName, @EmailId, @MobileNo, @Designation, @CompanyId, @DepartmentId)";
            using var db = GetConnection();
            db.Execute(sql, contact);
        }

        public void UpdateContact(ContactInfo contact)
        {
            string sql = @"UPDATE ContactInfo SET FirstName=@FirstName, LastName=@LastName, EmailId=@EmailId, 
                       MobileNo=@MobileNo, Designation=@Designation, CompanyId=@CompanyId, DepartmentId=@DepartmentId 
                       WHERE ContactId=@ContactId";
            using var db = GetConnection();
            db.Execute(sql, contact);
        }

        public void DeleteContact(int id)
        {
            string sql = "DELETE FROM ContactInfo WHERE ContactId = @Id";
            using var db = GetConnection();
            db.Execute(sql, new { Id = id });
        }

        public IEnumerable<Company> GetCompanies()
        {
            using var db = GetConnection();
            return db.Query<Company>("SELECT * FROM Company");
        }

        public IEnumerable<Department> GetDepartments()
        {
            using var db = GetConnection();
            return db.Query<Department>("SELECT * FROM Department");
        }
    }    
}
