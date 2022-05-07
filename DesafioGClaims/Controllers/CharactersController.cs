using DesafioGClaims.DataService.IDataService;
using DesafioGClaims.MarvelApi.IMarvelApi;
using DesafioGClaims.ViewModels;
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
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = _userAuth.GetUserId(User.Identity.Name);
            var favoriteIds = await _favoriteChar.GetFavorites(userId);

            var indexViewModel = new IndexCharViewModel();
            foreach (var favoriteId in favoriteIds)
            {
                var characterWrapper = await _characters.GetCharacter(favoriteId);
                indexViewModel.FavoriteCharacterDataWrapper
                    .Add(characterWrapper);
            };

            indexViewModel.GeneralCharacterDataWrapper = await _characters.GetCharacters();

            return View(indexViewModel);
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
        public IActionResult Favorite(int characterId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = _userAuth.GetUserId(User.Identity.Name);
            _favoriteChar.FavoriteChar(userId, characterId);

            return RedirectToAction("Index");
        }
        [Authorize]
        [HttpPost]
        public IActionResult UnFavorite(int characterId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var userId = _userAuth.GetUserId(User.Identity.Name);
            _favoriteChar.UnFavoriteChar(userId, characterId);

            return RedirectToAction("Index");
        }
    }
}
