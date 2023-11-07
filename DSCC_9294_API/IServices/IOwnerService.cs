using DSCC_9294_API.Models;

namespace DSCC_9294_API.IServices
{
    public interface IOwnerService
    {
        Task<IList<Owner>> GetAllAsync();
        Task<Owner> GetAsync(int id);
        Task<bool> CreateAsync(Owner owner);
        Task<bool> UpdateAsync(Owner owner);
        Task<bool> DeleteAsync(int id);
    }
}
