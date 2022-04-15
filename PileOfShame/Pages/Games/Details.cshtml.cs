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
    public class DetailsModel : PageModel
    {
        private readonly PileOfShame.Data.PileOfShameContext _context;

        public DetailsModel(PileOfShame.Data.PileOfShameContext context)
        {
            _context = context;
        }

        public GameModel GameModel { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GameModel = await _context.GameModel.FirstOrDefaultAsync(m => m.ID == id);

            if (GameModel == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
