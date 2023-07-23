using anketdeneme.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using System.Security.Claims;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using anketdeneme.Enums;

namespace anketdeneme.Pages
{
    public class LoginModel : PageModel
    {
        private readonly RepoDbContext _context;
        private readonly IValidator<Users> _userValidator;

        public LoginModel(RepoDbContext context, IValidator<Users> userValidator)
        {
            _context = context;
            _userValidator = userValidator;
        }
        public void OnGet()
        {


        }
        public async Task<IActionResult> OnPost(string name, string password)
        {
            var claims = new List<Claim>();

            var t = _context?.Users?.FirstOrDefault(x => x.Name == name && x.Password == password);
            if (t is not null)
            {
                var validation = _userValidator.Validate(t);
                if (validation.IsValid)
                {
                    claims.Add(new Claim(ClaimTypes.NameIdentifier, t.Id.ToString()));
                    claims.Add(new Claim(ClaimTypes.Name, t.Name));
                    var role = _context?.AppRoles?.FirstOrDefault(x => x.Id == t.Id).Role.ToString();
                    claims.Add(new Claim(ClaimTypes.Role, role));

                    var claimsIdentity = new ClaimsIdentity(
                        claims, CookieAuthenticationDefaults.AuthenticationScheme);

                    var authProperties = new AuthenticationProperties
                    {
                    };

                    await HttpContext.SignInAsync(
                        CookieAuthenticationDefaults.AuthenticationScheme,
                        new ClaimsPrincipal(claimsIdentity),
                        authProperties);
                    return RedirectToPage("AdminHome");
                }
                else
                {
                    foreach (var error in validation.Errors)
                    {
                        ModelState.AddModelError(error.ErrorCode, error.ErrorMessage);
                    }
                    return Page();
                }
            }
            else
            {
                ModelState.AddModelError("", "Kullanıcı Bulunamadı");
                return Page();
            }
        }
    }
}

