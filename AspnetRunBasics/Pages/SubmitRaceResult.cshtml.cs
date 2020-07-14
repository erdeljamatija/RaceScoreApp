using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Routing;
using RaceScore.Entities;
using RaceScore.Repositories;
using RaceScore.Repositories.Interfaces;

namespace RaceScore.Pages
{
    public class SubmitRaceResultModel : PageModel
    {
        private readonly IRaceRepository _raceRepository;
        private readonly IRaceResultRepository _raceResultRepository;

        public SubmitRaceResultModel(IRaceRepository raceRepository, IRaceResultRepository raceResultRepository)
        {
            _raceRepository = raceRepository ?? throw new ArgumentNullException(nameof(raceRepository));
            _raceResultRepository = raceResultRepository ?? throw new ArgumentNullException(nameof(raceResultRepository));
        }
        [BindProperty]
        public Race Race { get; set; }
        [TempData]
        public string RaceName { get; set; }
        [BindProperty]
        public RaceResult RaceResult { get; set; }

        public bool ShowMessage { get; set; }
        public async Task<IActionResult> OnGetAsync(int id)
        {
            Race = await _raceRepository.GetRaceById(id);
            RaceName = Race.Name;
            return Page();
        }

        public void OnPostSubmitRaceResult(RaceResult raceResult)
        {
            int raceId = int.Parse(HttpContext.GetRouteData().Values["id"].ToString());
            raceResult.Approved = false;
            raceResult.RaceRefId = raceId;
            _raceResultRepository.AddRaceResult(raceResult);

            ShowMessage = true;
        }
    }
}