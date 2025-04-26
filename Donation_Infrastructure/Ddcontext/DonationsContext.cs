using Microsoft.EntityFrameworkCore;
using project_donation.Models.donations;

namespace project_donation.context.Donation
{
    public class DonationsContext : DbContext
    {
        public DonationsContext(DbContextOptions<DonationsContext> _options)
            : base(_options)
        {

        }
        public DbSet<Donations> donations { get; set; }
    }
}

