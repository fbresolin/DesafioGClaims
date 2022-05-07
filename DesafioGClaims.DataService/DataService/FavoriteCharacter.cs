using DesafioGClaims.DataService.IDataService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

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

        public bool UnFavoriteChar(int CharacterId)
        {
            throw new NotImplementedException();
        }
    }
}
