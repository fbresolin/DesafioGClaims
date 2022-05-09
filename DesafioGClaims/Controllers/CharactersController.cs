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
    [Authorize]
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
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var indexViewModel = new IndexCharViewModel();

            var characterWrapper = await _characters.GetCharacters();

            if (characterWrapper != null)
                indexViewModel.GeneralCharacters = characterWrapper.Data.Results;
            
            var userId = _userAuth.GetUserId(User.Identity.Name);
            var favoriteIds = await _favoriteChar.GetFavorites(userId);
            
            foreach (var favoriteId in favoriteIds)
            {
                indexViewModel.GeneralCharacters
                    .RemoveAll(c => c.Id == favoriteId);

                var favCharacterWrapper = await _characters.GetCharacter(favoriteId);

                if (favCharacterWrapper != null)
                    indexViewModel.FavoriteCharacters
                        .Add(favCharacterWrapper.Data.Results.First());
            };
            indexViewModel.FavoriteCharacters
                .Sort((x, y) => x.Name
                .CompareTo(y.Name));

            return View(indexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> SearchCharacters(string searchString)
        {
            var indexViewModel = new IndexCharViewModel();

            var characterWrapper = await _characters.SearchCharacter(searchString);

            if (characterWrapper != null)
                indexViewModel.GeneralCharacters = characterWrapper.Data.Results;

            return View("Index", indexViewModel);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int characterId)
        {
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

            var userId = _userAuth.GetUserId(User.Identity.Name);
            characterViewModel.IsFavorite = _favoriteChar.IsFavorite(userId, characterId);

            return View(characterViewModel);
        }
        [HttpPost]
        public IActionResult Favorite(int characterId)
        {
            var userId = _userAuth.GetUserId(User.Identity.Name);
            _favoriteChar.FavoriteChar(userId, characterId);

            return RedirectToAction("Details", new { characterId = characterId });
        }
        
        [HttpPost]
        public IActionResult UnFavorite(int characterId)
        {
            var userId = _userAuth.GetUserId(User.Identity.Name);
            _favoriteChar.UnFavoriteChar(userId, characterId);

            return RedirectToAction("Index");
        }
    }
}
