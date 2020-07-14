using RaceScore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RaceScore.Repositories.Interfaces
{
    public interface IRaceRepository
    {
        Task<IEnumerable<Race>> GetRaces();
        Task<Race> GetRaceById(int id);
    }
}
