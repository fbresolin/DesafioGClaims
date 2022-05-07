using System;
using System.Collections.Generic;
using System.Text;

namespace DesafioGClaims.DataService.DataService
{
    public class ConnectionConfig
    {
        public readonly string ConnectionString = "Server=(localdb)\\MSSqlLocalDb;Database=DesafioGClaimsDb;Trusted_Connection=True;";
        public readonly string Salt = "cc362c2d15d3bce7cd50e37e6c2ea621fdb260cd";
    }
}
