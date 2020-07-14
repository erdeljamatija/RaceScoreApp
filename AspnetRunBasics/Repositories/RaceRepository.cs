using Microsoft.EntityFrameworkCore;
using RaceScore.Data;
using RaceScore.Entities;
using RaceScore.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceScore.Repositories
{
    public class RaceRepository : IRaceRepository
    {
        protected readonly RaceScoreContext _dbContext;

        public RaceRepository(RaceScoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<Race>> GetRaces()
        {
           return await _dbContext.Races.ToListAsync();
        }

        public async Task<Race> GetRaceById(int id)
        {
            return await _dbContext.Races.Where(x=>x.Id == id).FirstOrDefaultAsync();
        }
    }
}
