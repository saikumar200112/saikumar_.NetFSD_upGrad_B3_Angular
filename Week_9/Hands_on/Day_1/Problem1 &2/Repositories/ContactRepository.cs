using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Repositories
{
    public class ContactRepository : IContactRepository
    {
        private readonly ApplicationDbContext _context;
        public ContactRepository(ApplicationDbContext context) => _context = context;

        public async Task<IEnumerable<ContactInfo>> GetAllAsync()
        {
            return await _context.Contacts.Include(c => c.Company).Include(c => c.Department).ToListAsync();
        }

        public async Task<ContactInfo?> GetByIdAsync(int id)
        {
            return await _context.Contacts.Include(c => c.Company).Include(c => c.Department)
                                   .FirstOrDefaultAsync(c => c.ContactId == id);
        }

        public async Task AddAsync(ContactInfo contact)
        {
            await _context.Contacts.AddAsync(contact);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(ContactInfo contact)
        {
            _context.Entry(contact).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var contact = await _context.Contacts.FindAsync(id);
            if (contact != null)
            {
                _context.Contacts.Remove(contact);
                await _context.SaveChangesAsync();
            }
        }
    }
}