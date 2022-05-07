using DesafioGClaims.DataService.IDataService;
using DesafioGClaims.Entities.Models;
using DesafioGClaims.Models;
using DesafioGClaims.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesafioGClaims.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserAuthentication _userAuth;
        public UsersController(IUserAuthentication userAuth)
        {
            _userAuth = userAuth;
        }

        [AllowAnonymous]
        public ActionResult Register()
        {
            return View(new UserFormViewModel());
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Register(UserFormViewModel userForm)
        {
            if (!ModelState.IsValid)
                return View(new UserFormViewModel{ Message = "Usuário inválido" });

            if (_userAuth.IsRegistered(userForm.Username))
                return View(new UserFormViewModel{ Message = "Usuário já existe" });

            _userAuth.RegisterUser(userForm.Username, userForm.Password);

            return RedirectToAction("Login");
        }
        [AllowAnonymous]
        public IActionResult Login()
        {
            return View(new UserFormViewModel());
        }
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(UserFormViewModel userLogin)
        {
            if (!ModelState.IsValid)
                return View(new UserFormViewModel { Message = "Usuário inválido" });

            if (!_userAuth.IsRegistered(userLogin.Username))
                return View(new UserFormViewModel { Message = "Usuário não registrado" });

            var userDb = _userAuth.Authenticate(userLogin.Username, userLogin.Password);

            if (userDb != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userDb.Username),
                    new Claim(ClaimTypes.NameIdentifier, userDb.Id.ToString()),
                    new Claim(ClaimTypes.Role, "LoggedUser"),
                };

                var claimsIdentity = new ClaimsIdentity(
                    claims, CookieAuthenticationDefaults.AuthenticationScheme);

                var authProperties = new AuthenticationProperties
                {
                    AllowRefresh = true,
                    // Refreshing the authentication session should be allowed.

                    ExpiresUtc = DateTimeOffset.UtcNow.AddMinutes(10),
                    // The time at which the authentication ticket expires. A 
                    // value set here overrides the ExpireTimeSpan option of 
                    // CookieAuthenticationOptions set with AddCookie.

                    IsPersistent = true,
                    // Whether the authentication session is persisted across 
                    // multiple requests. When used with cookies, controls
                    // whether the cookie's lifetime is absolute (matching the
                    // lifetime of the authentication ticket) or session-based.

                    //IssuedUtc = <DateTimeOffset>,
                    // The time at which the authentication ticket was issued.

                    //RedirectUri = <string>
                    // The full path or absolute URI to be used as an http 
                    // redirect response value.
                };

                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity),
                    authProperties);
                return RedirectToAction("Index", "Home");
            }

            return View(new UserFormViewModel{ Message = "Senha incorreta" });
        }
       
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login");
        }
    }
}
