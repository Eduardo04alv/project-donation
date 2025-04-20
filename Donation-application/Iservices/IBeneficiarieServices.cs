using Donation_Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Donation_application.Iservices
{
    public interface IBeneficiarieServices
    {
        Task<List<Beneficiarie>> GetAll();
        Task<Beneficiarie> GetById(int id);
        Task Add(Beneficiarie _Beneficiarie);
        Task Update(Beneficiarie _Beneficiarie);
        Task Delete(int id);
    }
}
