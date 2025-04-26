using Donation_Domain.entities;
using project_donation.Models.donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_Infrastructure.IRepository
{
    public interface IDonationsRepository
    {
        void Add(Donations _Donations);
        void Delete(int id);
        Task<Donations> GetBYId(int id);
        List<Donations> Getall();
        void Update(Donations _Donations);
    }
}

