using Microsoft.EntityFrameworkCore;
using TesteBackendEnContact.Core.Domain.ContactBook;
using TesteBackendEnContact.Core.Domain.ContactBook.Company;

namespace TesteBackendEnContact.Database.Context
{
    public class ContactContext : DbContext
    {
        public ContactContext(DbContextOptions<ContactContext> options) : base(options){

        }
        public DbSet<Company> Companys { get; set; }
        public DbSet<ContactBook> ContactBooks { get; set; }
    }
}
