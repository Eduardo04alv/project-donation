using Donation_Domain.entities;

namespace Donation_application.Iservices
{
    public interface IDonorService
    {
        Task<List<Donor>> GetAll();
        Task<Donor> GetById(int id);
        Task Add(Donor donor);
        Task Update(Donor donor);
        Task Delete(int id);
    }
}
