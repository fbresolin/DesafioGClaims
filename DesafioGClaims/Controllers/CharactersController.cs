using DesafioGClaims.DataService.IDataService;
using DesafioGClaims.MarvelApi.IMarvelApi;
using DesafioGClaims.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Linq;
using System;

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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var indexViewModel = new IndexCharViewModel();

            var characterWrapper = await _characters.GetCharacters();
            indexViewModel.GeneralCharacters = characterWrapper.Data.Results;
            
            var userId = _userAuth.GetUserId(User.Identity.Name);
            var favoriteIds = await _favoriteChar.GetFavorites(userId);
            
            foreach (var favoriteId in favoriteIds)
            {
                indexViewModel.GeneralCharacters
                    .RemoveAll(c => c.Id == favoriteId);
                var favCharacter = await _characters.GetCharacter(favoriteId);
                indexViewModel.FavoriteCharacters
                    .Add(favCharacter.Data.Results.First());
            };
            if (favoriteIds.Count > 0)
                indexViewModel.FavoriteCharacters
                    .Sort((x, y) => x.Name
                    .CompareTo(y.Name));

            return View(indexViewModel);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> SearchCharacters(string searchString)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var indexViewModel = new IndexCharViewModel();

            var characterWrapper = await _characters.SearchCharacter(searchString);
            indexViewModel.GeneralCharacters = characterWrapper.Data.Results;

            return View("Index", indexViewModel);
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> Details(int characterId)
        {
            if (!User.Identity.IsAuthenticated)
                return RedirectToAction("Login");

            var characterWrapper = await _characters.GetCharacter(characterId);

            if (characterWrapper == null)
                return View("~/Views/Shared/Error.cshtml");

            var characterViewModel = new CharacterDetailsViewModel();
            characterViewModel.Character = characterWrapper.Data.Results.First();

            var comicWrapper = await _characters.GetCharacterComics(characterId);
            for (int i = 0; i < 5 && i < comicWrapper.Data.Count; i++)
            {
                characterViewModel.ComicList.Add(comicWrapper.Data.Results[i]);
            };

            return View(characterViewModel);
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
