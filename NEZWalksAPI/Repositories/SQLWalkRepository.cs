using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using NEZWalksAPI.Data;
using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Repositories
{
    public class SQLWalkRepository : IWalkRepository
    {
        private readonly NZWalksDbContext dbContext;

        public SQLWalkRepository(NZWalksDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Walk> CreateAsync(Walk walk)
        {
            await dbContext.Walk.AddAsync(walk);
            await dbContext.SaveChangesAsync();
            return walk;

        }

        public async Task<List<Walk>> GetAllAsync()
        {
            return await dbContext.Walk.Include("Difficulty").Include("Region").ToListAsync();

        }

        public async Task<Walk> GetByIdAsync(Guid Id)
        {
           return await dbContext.Walk.Include("Difficulty").Include("Region").FirstOrDefaultAsync(x=>x.Id == Id);        
        }

        public async Task<Walk?> UpdateAsync(Guid id, Walk walk)
        {
            var existingWalk = await dbContext.Walk.FirstOrDefaultAsync(x => x.Id == id);
            if(existingWalk == null) { return null; }
            
            existingWalk.Name = walk.Name;
            existingWalk.Description = walk.Description;
            existingWalk.LengthInKm = walk.LengthInKm;
            existingWalk.WalkImageUrl = walk.WalkImageUrl;
            existingWalk.DifficultyId = walk.DifficultyId;
            existingWalk.RegionId= walk.RegionId;

            await dbContext.SaveChangesAsync();

            return existingWalk;

        }
    }
}
