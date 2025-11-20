using Marvelous.Models;

namespace Marvelous.Repository.IRepository
{
    public interface IVillaRepository: IRepository<Villa>
    {
        Task<Villa> UpdateAsync(Villa entity);
    }
}
