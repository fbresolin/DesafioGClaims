using DesafioGClaims.MarvelApi.Schemas;
using System.Collections.Generic;

namespace DesafioGClaims.ViewModels
{
    public class IndexCharViewModel
    {
        public List<CharacterDataWrapper> FavoriteCharacterDataWrapper { get; set; } = new List<CharacterDataWrapper>();
        public CharacterDataWrapper GeneralCharacterDataWrapper { get; set; }
    }
}
