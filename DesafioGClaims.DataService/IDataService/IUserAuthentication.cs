using DesafioGClaims.Entities.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGClaims.DataService.IDataService
{
    public interface IUserAuthentication
    {
        void RegisterUser(string Username, string Password);
        User Authenticate(string Username, string Password);
        bool IsRegistered(string Username);
        int GetUserId(string Username);
    }
}
