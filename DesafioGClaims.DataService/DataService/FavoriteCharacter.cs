using DesafioGClaims.DataService.IDataService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGClaims.DataService.DataService
{
    public class FavoriteCharacter : ConnectionConfig, IFavoriteCharacter
    {
        public bool FavoriteChar(int UserId, int CharacterId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT COUNT(userid) FROM characters WHERE (characterid={CharacterId} AND userid={UserId})";
                    var result = Convert.ToInt32(command.ExecuteScalar());
                    if (result != 0)
                        return false;

                    command.CommandText = $"SELECT COUNT(userid) FROM characters WHERE characterid={CharacterId}";
                    result = Convert.ToInt32(command.ExecuteScalar());
                    if (result >= 5)
                        return false;

                    command.CommandText = $"INSERT INTO characters (characterid, userid) values ({CharacterId}, {UserId})";
                    command.ExecuteNonQuery();
                    return true;
                }
            }
        }

        public async Task<List<int>> GetFavorites(int UserId)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT characterid FROM characters WHERE userid={UserId}";
                    var data = await command.ExecuteReaderAsync();
                    var characterIds = new List<int>();
                    while (data.Read())
                    {
                        int characterId = data.GetInt32(0);
                        characterIds.Add(characterId);
                    }
                    return characterIds;
                }
            }
        }

        public bool UnFavoriteChar(int UserId, int CharacterId)
        {
            throw new NotImplementedException();
        }
    }
}
