using DesafioGClaims.DataService.IDataService;
using DesafioGClaims.MarvelApi.IMarvelApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DesafioGClaims.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacters _characters;
        private readonly IUserAuthentication _userAuth;
        private readonly IFavoriteCharacter _favoriteChar;
        public CharactersController(
            ICharacters characters,
            IUserAuthentication userAuth,
            IFavoriteCharacter favoriteChar)
        {
            _characters = characters;
            _userAuth = userAuth;
            _favoriteChar = favoriteChar;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var characterDataWrapper = await _characters.GetCharacters();

            if (characterDataWrapper == null)
                return View("~/Views/Shared/Error.cshtml");

            // criar um viewmodel para organizar a resposta da api

            return View(characterDataWrapper);
        }
        [Authorize]
        public async Task<IActionResult> Details(int characterId)
        {
            var characterDataWrapper = await _characters.GetCharacter(characterId);

            if (characterDataWrapper == null)
                return View("~/Views/Shared/Error.cshtml");

            return View(characterDataWrapper);
        }
        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Favorite(int characterId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = _userAuth.GetUserId(User.Identity.Name);
            _favoriteChar.FavoriteChar(userId, characterId);

            return RedirectToAction("Index");
        }
    }
}
