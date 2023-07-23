using anketdeneme.Models;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace anketdeneme.Pages;


public class IndexModel : PageModel
{
    public List<SelectListItem> Options { get; set; }

    private readonly RepoDbContext _context;
    private readonly IValidator<Sorular> _soruValidate;

    public IndexModel(RepoDbContext context, IValidator<Sorular> soruValidate)
    {
        _context = context;
        _soruValidate = soruValidate;
    }

    public void OnGet()
    {
        string ipadress = HttpContext.Connection.RemoteIpAddress.ToString();
        ViewData["IpAddress"] = ipadress;
        Options = _context.Memnuniyets
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.MemnuniyetDerecesi
            })
            .ToList();
    }
    public IActionResult OnPost(Sorular sorular)
    {
        var validate = _soruValidate.Validate(sorular);
        if (validate.IsValid)
        {

            _context.Sorulars.Add(sorular);
            _context.SaveChanges();
            return RedirectToPage("/success");
        }
        else
        {
            foreach (var error in validate.Errors)
            {
                ModelState.AddModelError(error.PropertyName, error.ErrorMessage);
            }
            Options = _context.Memnuniyets
            .Select(x => new SelectListItem
            {
                Value = x.Id.ToString(),
                Text = x.MemnuniyetDerecesi
            })
            .ToList();
            return Page();
        }
    }
}
