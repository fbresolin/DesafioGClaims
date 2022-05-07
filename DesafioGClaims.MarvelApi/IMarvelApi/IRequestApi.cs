using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGClaims.MarvelApi.IMarvelApi
{
    public interface IRequestApi
    {
        Task<HttpResponseMessage> RequestApiUrl(string ApiString);
    }
}
