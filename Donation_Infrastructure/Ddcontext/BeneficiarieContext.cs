using Donation_Domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Infrastructure.Ddcontext
{
    public class BeneficiarieContext : DbContext
    {
        public BeneficiarieContext(DbContextOptions<BeneficiarieContext> _options)
            : base(_options)
        {

        }
        public DbSet<Beneficiarie> beneficiarie { get; set; }
    }
}
