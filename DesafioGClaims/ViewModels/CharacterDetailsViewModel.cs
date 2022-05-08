using DesafioGClaims.MarvelApi.ComicSchemas;
using DesafioGClaims.MarvelApi.Schemas;
using System.Collections.Generic;

namespace DesafioGClaims.ViewModels
{
    public class CharacterDetailsViewModel
    {
        public Character Character { get; set; } = new Character();
        public List<Comic> ComicList { get; set; } = new List<Comic>();
    }
}
