using DesafioGClaims.MarvelApi.ComicSchemas;
using DesafioGClaims.MarvelApi.Schemas;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGClaims.MarvelApi.IMarvelApi
{
    public interface IRequestApi
    {
        Task<HttpResponseMessage> RequestApiUrl(string ApiString, string AdditionalQuery = "");
        Task<CharacterDataWrapper> ExecuteCharRequest(string request, string additionalQuery = "");
        Task<ComicDataWrapper> ExecuteComicRequest(string request, string additionalQuery = "");
    }
}
