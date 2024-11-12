﻿using NEZWalksAPI.Models.Domain;

namespace NEZWalksAPI.Repositories
{
    public interface IWalkRepository
    {
        Task<Walk>CreateAsync(Walk walk);
        Task<List<Walk>> GetAllAsync();
        Task<Walk> GetByIdAsync(Guid Id);
    }
}
