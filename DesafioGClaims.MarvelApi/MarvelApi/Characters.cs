using DesafioGClaims.MarvelApi.IMarvelApi;
using DesafioGClaims.MarvelApi.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
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
            var response = await _request.RequestApiUrl($"/v1/public/characters/{characterId}");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterDataWrapper>(json); ;
        }

        public async Task<CharacterDataWrapper> GetCharacters()
        {
            var response = await _request.RequestApiUrl($"/v1/public/characters");

            if (!response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterDataWrapper>(json);
        }
    }
}
