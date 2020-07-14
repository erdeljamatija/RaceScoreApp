using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using RaceScore.Repositories;
using RaceScore.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Formatters;

namespace RaceScore.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IRaceRepository _raceRepository;

        public IndexModel(IRaceRepository raceRepository)
        {
            _raceRepository = raceRepository ?? throw new ArgumentNullException(nameof(raceRepository));
        }

        public IEnumerable<Entities.Race> RaceList { get; set; } = new List<Entities.Race>();

        public async Task<IActionResult> OnGetAsync()
        {
            RaceList = await _raceRepository.GetRaces();
            return Page();
        }
    }
}
