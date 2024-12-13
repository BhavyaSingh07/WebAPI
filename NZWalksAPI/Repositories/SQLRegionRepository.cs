using Microsoft.EntityFrameworkCore;
using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class SQLRegionRepository : IRegionRepository
    {
        private readonly NZWalksDbContext _dbcontext;
        public SQLRegionRepository(NZWalksDbContext dbcontext)
        {
            this._dbcontext = dbcontext;
        }

        public async Task<List<Region>> GetAllAsync()
        {
           return await _dbcontext.Regions.ToListAsync();
        }

        public async Task<Region?> GetByIdAsync(Guid Id)
        {
            return await _dbcontext.Regions.FirstOrDefaultAsync(t => t.Id == Id);
        }
        public async Task<Region> CreateAsync(Region region)
        {
            await _dbcontext.Regions.AddAsync(region);
            await _dbcontext.SaveChangesAsync();
            return region;
        }

        public async Task<Region?> UpdateAsync(Guid id, Region region)
        {
            var existingregion = await _dbcontext.Regions.FirstOrDefaultAsync(t =>t.Id == id);
            if (existingregion == null)
            {
                return null;
            }
            existingregion.Code = region.Code;
            existingregion.Name = region.Name;
            existingregion.RegionImageUrl = region.RegionImageUrl;

            await _dbcontext.SaveChangesAsync();
            return existingregion;
        }

        public async Task<Region?> DeleteAsync(Guid id)
        {
            var existingregion = await _dbcontext.Regions.FirstOrDefaultAsync(t => t.Id == id);

            if (existingregion == null)
            {
                return null;
            }

            _dbcontext.Regions.Remove(existingregion);
            await _dbcontext.SaveChangesAsync();

            return existingregion;
        }
    }
}
