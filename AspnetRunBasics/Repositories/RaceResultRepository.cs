using Microsoft.AspNetCore.Authorization;
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
    public class RaceResultRepository : IRaceResultRepository
    {
        protected readonly RaceScoreContext _dbContext;

        public RaceResultRepository(RaceScoreContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<IEnumerable<RaceResult>> GetRaceResults(int raceId)
        {
            return await _dbContext.RaceResults.Where(x=> x.RaceRefId == raceId && x.Approved == true).OrderBy(x => x.ResultTime).ToListAsync();
        }

        public async Task<IEnumerable<RaceResult>> GetAdminRaceResults(int raceId)
        {
            return await _dbContext.RaceResults.Where(x => x.RaceRefId == raceId).OrderBy(x => x.ResultTime).ToListAsync();
        }

        public async Task<RaceResult> AddRaceResult(RaceResult raceResult)
        {
            _dbContext.RaceResults.Add(raceResult);
            await _dbContext.SaveChangesAsync();
            return raceResult;
        }

        [Authorize]
        public async Task ApproveRaceResult(int raceResultId)
        {
            _dbContext.RaceResults.Where(x => x.Id == raceResultId).FirstOrDefault().Approved = true;
            await _dbContext.SaveChangesAsync();
        }

        [Authorize]
        public async Task DeleteRaceResult(int raceResultId)
        {
            var removedResult = _dbContext.RaceResults.Where(x => x.Id == raceResultId).FirstOrDefault();
            _dbContext.Remove(removedResult);
            await _dbContext.SaveChangesAsync();
        }
    }
}
