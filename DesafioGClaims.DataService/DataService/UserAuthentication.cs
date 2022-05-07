using DesafioGClaims.DataService.IDataService;
using DesafioGClaims.Entities.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Security.Cryptography;
using System.Text;

namespace DesafioGClaims.DataService.DataService
{
    public class UserAuthentication : ConnectionConfig, IUserAuthentication
    {
        public bool Authenticate(string Username, string Password)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT password FROM users WHERE username=@username";
                    command.Parameters.AddWithValue("@username", Username);
                    var result = (string)command.ExecuteScalar();

                    var hash = CreateHash($"{Password}{Salt}");
                    if (hash == result)
                        return true;
                    else
                        return false;
                }
            }
        }

        public bool IsRegistered(string Username)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    command.CommandText = $"SELECT 1 FROM users WHERE username=@username";
                    command.Parameters.AddWithValue("@username", Username);
                    var result = command.ExecuteScalar();

                    if (result != null)
                        return true;
                    else
                        return false;
                }
            }
        }

        public void RegisterUser(string Username, string Password)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                using (var command = connection.CreateCommand())
                {
                    var hash = CreateHash($"{Password}{Salt}");
                    command.CommandText = "INSERT INTO users (username, password) values (@username, @password)";
                    command.Parameters.AddWithValue("@username", Username);
                    command.Parameters.AddWithValue("@password", hash);
                    command.ExecuteNonQuery();
                }
            }
        }
        private string CreateHash(string input)
        {
            using (MD5 md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("x2"));
                }
                return sb.ToString();
            }
        }
    }
}
