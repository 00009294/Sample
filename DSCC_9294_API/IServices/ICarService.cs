using DSCC_9294_API.Models;

namespace DSCC_9294_API.IServices
{
    public interface ICarService
    {
        Task<IList<Car>> GetAllAsync();
        Task<Car> GetAsync(int id);
        Task<bool> CreateAsync(Car car);
        Task<bool> UpdateAsync(Car car);
        Task<bool> DeleteAsync(int id);
    }
}
