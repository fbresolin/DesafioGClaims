using DesafioGClaims.MarvelApi.ComicSchemas;
using DesafioGClaims.MarvelApi.Schemas;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGClaims.MarvelApi.IMarvelApi
{
    public interface ICharacters
    {
        Task<CharacterDataWrapper> GetCharacter(int CharacterId);
        Task<ComicDataWrapper> GetCharacterComics(int CharacterId);
        Task<CharacterDataWrapper> GetCharacters();
        Task<CharacterDataWrapper> SearchCharacter(string SearchString);
    }
}
