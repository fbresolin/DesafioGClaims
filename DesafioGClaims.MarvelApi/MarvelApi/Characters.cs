using DesafioGClaims.MarvelApi.ComicSchemas;
using DesafioGClaims.MarvelApi.IMarvelApi;
using DesafioGClaims.MarvelApi.Schemas;
using System.Threading.Tasks;

namespace DesafioGClaims.MarvelApi.MarvelApi
{
    public class Characters : ICharacters
    {
        private readonly IRequestApi _request;
        public Characters(IRequestApi request)
        {
            _request = request;
        }
        public async Task<CharacterDataWrapper> GetCharacter(int characterId)
        {
            return await _request.ExecuteCharRequest($"/v1/public/characters/{characterId}");            
        }

        public async Task<ComicDataWrapper> GetCharacterComics(int characterId)
        {
            return await _request.ExecuteComicRequest($"/v1/public/characters/{characterId}/comics");
        }

        public async Task<CharacterDataWrapper> GetCharacters()
        {
            return await _request.ExecuteCharRequest("/v1/public/characters", "&orderBy=name");
        }

        public async Task<CharacterDataWrapper> SearchCharacter(string SearchString)
        {
            return await _request.ExecuteCharRequest("/v1/public/characters", $"&nameStartsWith={SearchString}&orderBy=name");
        }
    }
}
