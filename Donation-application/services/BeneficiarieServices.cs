using Donation_application.Iservices;
using Donation_Domain.entities;
using Donation_Domain.Repository;
using Donation_Infrastructure.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_application.services
{
    internal class BeneficiarieServices : IBeneficiarieServices
    {
        private readonly IBeneficiarieRepository _beneficiarieRepository;

        public BeneficiarieServices(IBeneficiarieRepository beneficiarieRepository)
        {
            _beneficiarieRepository = beneficiarieRepository;
        }

        public async Task<List<Beneficiarie>> GetAll()
        {
            return await Task.FromResult(_beneficiarieRepository.Getall());
        }

        public async Task<Beneficiarie> GetById(int id)
        {
            return await _beneficiarieRepository.GetBYId(id);
        }

        public async Task Add(Beneficiarie _beneficiarie)
        {
            _beneficiarieRepository.Add(_beneficiarie);
            await Task.CompletedTask;
        }

        public async Task Update(Beneficiarie _beneficiarie)
        {
            _beneficiarieRepository.Update(_beneficiarie);
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            _beneficiarieRepository.Delete(id);
            await Task.CompletedTask;
        }
    }
}
