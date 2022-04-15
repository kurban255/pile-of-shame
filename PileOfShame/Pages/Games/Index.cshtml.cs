using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
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

        public async Task OnGetAsync()
        {
            GameModel = await _context.GameModel.ToListAsync();
        }
    }
}
