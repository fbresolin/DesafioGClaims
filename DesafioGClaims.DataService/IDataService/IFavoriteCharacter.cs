using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGClaims.DataService.IDataService
{
    public interface IFavoriteCharacter
    {
        bool FavoriteChar(int UserId, int CharacterId);
        bool UnFavoriteChar(int UserId, int CharacterId);
        Task<List<int>> GetFavorites(int UserId);
        bool IsFavorite(int UserId, int CharacterId);
    }
}
