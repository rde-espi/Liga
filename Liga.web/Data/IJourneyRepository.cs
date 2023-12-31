﻿using Liga.web.Data.Entity;
using Liga.web.Models;
using System.Linq;
using System.Threading.Tasks;

namespace Liga.web.Data
{
    public interface IJourneyRepository : IGenericRepository<Journey>
    {
        Task<IQueryable<Journey>>GetJourneyAsync(string userName);
        Task<IQueryable<GameDetailTemp>> GetJourneyDetailTempsAsync(string userName);
        Task AddGameToJourneyAsync(AddItemsViewModel model, string userName);
        Task ModifyGameAsync(int id, bool isConcluded);
        Task DeleteGameAsync(int id);
        Task<bool> StartJourneyAsync(string userName);
    }
}
