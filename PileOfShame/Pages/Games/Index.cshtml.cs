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
        public SelectList Platforms { get; set; }
        [BindProperty(SupportsGet = true)]
        public string GamePlatform { get; set; }

        public async Task OnGetAsync()
        {
            IQueryable<string> genreQuery = from g in _context.GameModel
                                            orderby g.Genre
                                            select g.Genre;

            IQueryable<string> platformQuery = from g in _context.GameModel
                                            orderby g.Platform
                                            select g.Platform;

            var games = from g in _context.GameModel
                         select g;

            if (!string.IsNullOrEmpty(SearchString))
            {
                games = games.Where(s => s.Title.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(GameGenre))
            {
                games = games.Where(x => x.Genre == GameGenre);
            }

            if (!string.IsNullOrEmpty(GamePlatform))
            {
                games = games.Where(x => x.Platform == GamePlatform);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());
            Platforms = new SelectList(await platformQuery.Distinct().ToListAsync());
            GameModel = await games.ToListAsync();
        }
    }
}
