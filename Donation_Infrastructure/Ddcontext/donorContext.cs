
using Donation_Domain.entities;
using Microsoft.EntityFrameworkCore;

namespace Donation_Infrastructure.Ddcontext
{
    public class donorContext : DbContext
    {
        public donorContext(DbContextOptions<donorContext> options)
        : base(options)
        {

        }
        public DbSet<Donor> donor { get; set; }
    }
}
