using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace TravelBudgetContactContext
{
    public class ContactContext : DbContext
    {

        public ContactContext(DbContextOptions<ContactContext> options) : base(options)
        {

        }
        

    }
}