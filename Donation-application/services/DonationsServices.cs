using Donation_application.Iservices;
using Donation_Domain.entities;
using Donation_Domain.Repository;
using Donation_Infrastructure.IRepository;
using Donation_Infrastructure.Repository;
using project_donation.Models.donations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_application.services 
{
   public class DonationsServices : IDonationsservices
    {
        private readonly IDonationsRepository _donationsRepository;
        
        public DonationsServices(IDonationsRepository _donationsRepository)
        {
            this._donationsRepository = _donationsRepository;    
        }
        public async Task<List<Donations>> GetAll()
        {
            return await Task.FromResult(_donationsRepository.Getall());
        }
        public async Task<Donations> GetById(int id)
        {
            return await _donationsRepository.GetBYId(id);
        }
        public async Task Add(Donations _donations)
        {
            _donationsRepository.Add(_donations);
            await Task.CompletedTask;
        }
        public async Task Update(Donations _donations)
        {
            _donationsRepository.Update(_donations);
            await Task.CompletedTask;
        }
        public async Task Delete(int id)
        {
            _donationsRepository.Delete(id);
            await Task.CompletedTask;
        }
   }
}
