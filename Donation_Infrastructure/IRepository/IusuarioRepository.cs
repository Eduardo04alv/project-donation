using Donation_Domain.entities;

namespace Donation_Infrastructure.IRepository
{
    public interface IusuarioRepository
    {
        void Add(Usuario _usuario);
        void Delete(int id);
        Task<Usuario> GetBYId(int id);
        List<Usuario> Getall();
        void Update(Usuario _usuario);
    }
}
