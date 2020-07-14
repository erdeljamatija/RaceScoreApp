using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace RaceScore.Pages
{
    public class LoginModel : PageModel
    {
        public void OnGet()
        {

        }

        [BindProperty]
        public LoginData loginData { get; set; }

        public async Task<RedirectToPageResult> OnPostAsync()
        {
            if (ModelState.IsValid)
            {
                var isValid = (loginData.Username == "admin" && loginData.Password == "admin123");
                if (!isValid)
                {
                    ModelState.AddModelError("", "username or password is invalid");
                    return RedirectToPage("Login");
                }

                var claims = new List<Claim>
                {
                    new Claim("user", loginData.Username),
                    new Claim("role", "Admin")
                };

                var identity = new ClaimsIdentity(claims, "adminLogin", "user", "role");
                var principal = new ClaimsPrincipal(identity);
                await HttpContext.SignInAsync("adminLogin", principal, new AuthenticationProperties
                {
                    AllowRefresh = true,
                    ExpiresUtc = DateTimeOffset.Now.AddDays(1),
                    IsPersistent = loginData.RememberMe
                });
                return RedirectToPage("Index");
            }
            else
            {
                ModelState.AddModelError("", "username or password is blank");
                return RedirectToPage("Login");
            }
        }
    }

    public class LoginData
    {
        [Required]
        public string Username { get; set; }

        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}