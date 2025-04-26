using Donation_Domain.entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Infrastructure.Ddcontext
{
    public class UsuarioContex : DbContext
    {
        public UsuarioContex(DbContextOptions<UsuarioContex> options)
        : base(options)
        {

        }
        public DbSet<Usuario> usuario { get; set; }
    }
}
