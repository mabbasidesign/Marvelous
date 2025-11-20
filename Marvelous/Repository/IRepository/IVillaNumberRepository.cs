using Marvelous.Models;

namespace Marvelous.Repository.IRepository
{
    public interface IVillaNumberRepository:  IRepository<VillaNumber>
    {
        Task<VillaNumber> UpdateAsync(VillaNumber entity);
    }
}
