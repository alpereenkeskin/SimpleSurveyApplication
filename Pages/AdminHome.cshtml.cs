using System.Diagnostics;
using anketdeneme.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace anketdeneme.Pages
{
    [Authorize(Roles = "Admin")]
    public class AdminHomeModel : PageModel
    {
        public List<Sorular>? Sorulars { get; set; }
        private readonly RepoDbContext? _context;

        public AdminHomeModel(RepoDbContext context)
        {
            _context = context;
        }

        public void OnGet()
        {
            Sorulars = _context.Sorulars.Include(x => x.Memnuniyet).ToList();

        }

    }
}
