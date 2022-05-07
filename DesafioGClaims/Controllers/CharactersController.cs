using DesafioGClaims.MarvelApi.IMarvelApi;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DesafioGClaims.Controllers
{
    public class CharactersController : Controller
    {
        private readonly ICharacters _characters;
        public CharactersController(ICharacters characters)
        {
            _characters = characters;
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
    }
}
