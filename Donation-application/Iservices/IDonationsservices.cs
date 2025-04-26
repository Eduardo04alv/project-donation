using project_donation.Models.donations;

namespace Donation_application.Iservices
{
    public interface IDonationsservices
    {
        Task<List<Donations>> GetAll();
        Task<Donations> GetById(int id);
        Task Add(Donations _Donations);
        Task Update(Donations _Donations);
        Task Delete(int id);
    }
}
