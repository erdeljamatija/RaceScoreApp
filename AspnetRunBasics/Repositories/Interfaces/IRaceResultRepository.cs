using RaceScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceScore.Repositories.Interfaces
{
    public interface IRaceResultRepository
    {
        Task<IEnumerable<RaceResult>> GetRaceResults(int raceId);
        Task<IEnumerable<RaceResult>> GetAdminRaceResults(int raceId);
        Task<RaceResult> AddRaceResult(RaceResult raceResult);
        Task ApproveRaceResult(int raceResultId);
        Task DeleteRaceResult(int raceResultId);
    }
}
