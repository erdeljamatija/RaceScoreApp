using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using RaceScore.Entities;
using RaceScore.Repositories.Interfaces;

namespace RaceScore.Pages
{
    public class AdminRaceResultsModel : PageModel
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IRaceResultRepository _raceResultRepository;

        public IEnumerable<RaceResult> RaceResultList { get; set; }
        public Race Race { get; set; }
        [TempData]
        public string RaceName { get; set; }

        public AdminRaceResultsModel(IRaceRepository raceRepository, IRaceResultRepository raceResultRepository)
        {
            _raceRepository = raceRepository ?? throw new ArgumentNullException(nameof(raceRepository));
            _raceResultRepository = raceResultRepository ?? throw new ArgumentNullException(nameof(raceResultRepository));
        }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Race = await _raceRepository.GetRaceById(id);
            RaceName = Race.Name;
            RaceResultList = await _raceResultRepository.GetAdminRaceResults(id);
            return Page();
        }

        public async Task<IActionResult> OnPostApproveRaceResultAsync(int raceResultId, int raceId)
        {
            await _raceResultRepository.ApproveRaceResult(raceResultId);
            return await OnGetAsync(raceId);
        }

        public async Task<IActionResult> OnPostDeleteRaceResultAsync(int raceResultId, int raceId)
        {
            await _raceResultRepository.DeleteRaceResult(raceResultId);
            return await OnGetAsync(raceId);
        }
    }
}