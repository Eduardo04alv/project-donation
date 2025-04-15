
using Donation_Domain.entities;

namespace Donation_Domain.Repository
{
    public interface IDonorRepository
    { 
        void Add(Donor _donor);
        void Delete(int id);
        Task<Donor> GetBYId(int id);
        List<Donor> Getall();
        void Update(Donor _donor);
    }
}
