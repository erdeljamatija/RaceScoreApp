using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using RaceScore.Entities;
using RaceScore.Repositories.Interfaces;

namespace RaceScore.Pages
{
    public class RaceResultsModel : PageModel
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IRaceResultRepository _raceResultRepository;
        public IEnumerable<RaceResult> RaceResultList { get; set; }
        public Race Race { get; set; }

        public RaceResultsModel(IRaceRepository raceRepository, IRaceResultRepository raceResultRepository)
        {
            _raceRepository = raceRepository ?? throw new ArgumentNullException(nameof(raceRepository));
            _raceResultRepository = raceResultRepository ?? throw new ArgumentNullException(nameof(raceResultRepository));
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Race = await _raceRepository.GetRaceById(id);
            RaceResultList = await _raceResultRepository.GetRaceResults(id);
            return Page();
        }
    }
}