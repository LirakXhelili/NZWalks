﻿using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk>CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync(string? filterOn = null, string? filterQuery=null);
        Task<Walk> GetByIdAsync(Guid Id);
        Task<Walk?> UpdateAsync(Guid id, Walk walk);
        Task<Walk?> DeleteAsync(Guid id);

    }
}
