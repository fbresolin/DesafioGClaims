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
        Task<CharacterDataWrapper> GetCharacters();
    }
}
