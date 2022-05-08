using DesafioGClaims.MarvelApi.Schemas;
using System.Collections.Generic;

namespace DesafioGClaims.ViewModels
{
    public class IndexCharViewModel
    {
        public List<Character> FavoriteCharacters { get; set; } = new List<Character>();
        public List<Character> GeneralCharacters { get; set; } = new List<Character>();
    }
}
