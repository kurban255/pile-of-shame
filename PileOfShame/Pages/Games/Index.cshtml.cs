using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using PileOfShame.Data;
using PileOfShame.Models;

namespace PileOfShame.Pages.Games
{
    public class IndexModel : PageModel
    {
        private readonly PileOfShame.Data.PileOfShameContext _context;

        public IndexModel(PileOfShame.Data.PileOfShameContext context)
        {
            _context = context;
        }

        public IList<GameModel> GameModel { get;set; }
        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList Genres { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GameGenre { get; set; }

        public async Task OnGetAsync()
        {
            var games = from m in _context.GameModel
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                games = games.Where(s => s.Title.Contains(SearchString));
            }

            GameModel = await games.ToListAsync();
        }
    }
}
