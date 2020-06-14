using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using EnergyStyleCore.Models;
using Microsoft.AspNetCore.Authentication.Cookies;
using EnergyStyleCore.Models.Classes;
using Microsoft.EntityFrameworkCore;

namespace EnergyStyleCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly AppDBContext _context;
        public AccountController(AppDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult Signin()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> CreateAdmin()
        {
            var user = new User
            {
                Login = "pavanvo",
                Password = "qazwsxedc",
                FirstName = "Anton",
                LastName = "Pavanvo",
                Role = "admin, user"
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> Signin(string userName, string pass, bool presist = true)
        {
            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(pass)) return View("Введите логин и пароль");
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Login == userName);
                if (user != null)
                {
                    if (user.Password == pass)
                    {
                        // In a real-world application, user credentials would need validated before signing in
                        var claims = new List<Claim>();
                        // Add a Name claim and, if birth date was provided, a DateOfBirth claim
                        claims.Add(new Claim(ClaimTypes.Name, user.Login));
                        if (true)
                        {
                            claims.Add(new Claim(ClaimTypes.Role, user.Role));
                        }

                        // Create user's identity and sign them in
                        var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var authProperties = new AuthenticationProperties
                        {
                            AllowRefresh = true,
                            ExpiresUtc = DateTimeOffset.UtcNow.AddDays(1),
                            IsPersistent = presist,
                            IssuedUtc = DateTimeOffset.UtcNow,
                            RedirectUri = "/"
                        };
                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                            new ClaimsPrincipal(claimsIdentity),
                            authProperties
                            );
                    }
                    else return View("Signin", "Пароль не правильный");
                }
                else return View("Signin", "Пользователь не найден");
            }
            catch (Exception ex)
            {
                return BadRequest($"ex = {ex.Message}");
            }
            return Redirect("/");
        }

        public async Task<IActionResult> Signout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Redirect("/");
        }

        [HttpGet]
        public IActionResult Denied()
        {
            return View();
        }
    }
}
