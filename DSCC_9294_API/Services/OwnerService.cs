using DSCC_9294_API.DataContext;
using DSCC_9294_API.IServices;
using DSCC_9294_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DSCC_9294_API.Services
{
    public class OwnerService : IOwnerService
    {
        private readonly AppDbContext _dbContext;

        public OwnerService(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IList<Owner>> GetAllAsync()
        {
            return await _dbContext.Owner.ToListAsync();
        }

        public async Task<Owner> GetAsync(int id)
        {
            return await _dbContext.Owner.FindAsync(id);
        }

        public async Task<bool> CreateAsync(Owner owner)
        {
            _dbContext.Owner.Add(owner);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateAsync(Owner owner)
        {
            _dbContext.Entry(owner).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var owner = await _dbContext.Owner.FindAsync(id);
            if (owner != null)
            {
                _dbContext.Owner.Remove(owner);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
