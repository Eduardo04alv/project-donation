using Donation_Domain.entities;

namespace Donation_Infrastructure.IRepository
{
    public interface IBeneficiarieRepository
    {
        void Add(Beneficiarie _Beneficiarie);
        void Delete(int id);
        Task<Beneficiarie> GetBYId(int id);
        List<Beneficiarie> Getall();
        void Update(Beneficiarie _Beneficiarie);
    }
}

