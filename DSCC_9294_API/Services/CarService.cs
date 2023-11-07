using DSCC_9294_API.DataContext;
using DSCC_9294_API.IServices;
using DSCC_9294_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_9294_API.Services
{
    public class CarService : ICarService
    {
        private readonly AppDbContext _dbContext;

        public CarService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Car>> GetAllAsync()
        {
            return await _dbContext.Car.ToListAsync();
        }

        public async Task<Car> GetAsync(int id)
        {
            return await _dbContext.Car.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Car car)
        {
            _dbContext.Car.Add(car);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Car car)
        {
            _dbContext.Entry(car).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var car = await _dbContext.Car.FindAsync(id);
            if (car != null)
            {
                _dbContext.Car.Remove(car);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
