using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGClaims.DataService.IDataService
{
    public interface IFavoriteCharacter
    {
        bool FavoriteChar(int UserId, int CharacterId);
        bool UnFavoriteChar(int CharacterId);
    }
}
