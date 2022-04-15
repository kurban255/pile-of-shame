using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using PileOfShame.Data;
using PileOfShame.Models;

namespace PileOfShame.Pages.Games
{
    public class CreateModel : PageModel
    {
        private readonly PileOfShame.Data.PileOfShameContext _context;

        public CreateModel(PileOfShame.Data.PileOfShameContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public GameModel GameModel { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.GameModel.Add(GameModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
