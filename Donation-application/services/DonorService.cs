using Donation_Domain.entities;
using Donation_Domain.Repository;

namespace Donation_application.services
{
    public class DonorService
    {
        private readonly IDonorRepository _donorRepository;

        public DonorService(IDonorRepository donorRepository)
        {
            _donorRepository = donorRepository;
        }

        public async Task<List<Donor>> GetAll()
        {
            return await Task.FromResult(_donorRepository.Getall());
        }

        public async Task<Donor> GetById(int id)
        {
            return await _donorRepository.GetBYId(id);
        }

        public async Task Add(Donor donor)
        {
            _donorRepository.Add(donor);
            await Task.CompletedTask;
        }

        public async Task Update(Donor donor)
        {
            _donorRepository.Update(donor);
            await Task.CompletedTask;
        }

        public async Task Delete(int id)
        {
            _donorRepository.Delete(id); 
            await Task.CompletedTask;
        }

    }
}
