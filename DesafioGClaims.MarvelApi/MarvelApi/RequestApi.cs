using DesafioGClaims.MarvelApi.ComicSchemas;
using DesafioGClaims.MarvelApi.IMarvelApi;
using DesafioGClaims.MarvelApi.Schemas;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DesafioGClaims.MarvelApi.MarvelApi
{
    public class RequestApi : IRequestApi
    {
        private readonly string _baseUrl = "http://gateway.marvel.com";
        private readonly string _publicApiKey = "e001a0c8b629b6c2a1355362520b9825";
        private readonly string _privateApiKey = "cc362c2d15d3bce7cd50e37e6c2ea632fdb260cd";
        private static readonly HttpClient _client = new HttpClient();

        public async Task<HttpResponseMessage> RequestApiUrl(string apiString, string additionalQuery)
        {
            // ts - a timestamp(or other long string which can change on a request - by - request basis)
            string timestamp = (DateTime.Now.ToUniversalTime() - new DateTime(1970, 1, 1)).TotalSeconds.ToString();

            // hash - a md5 digest of the ts parameter, your private key and your public key(e.g.md5(ts+privateKey+publicKey)
            string hash = CreateHash($"{timestamp}{_privateApiKey}{_publicApiKey}");

            // http://gateway.marvel.com/v1/public/comics?ts=1&apikey=1234&hash=ffd275c5130566a2916217b101f26150 (the hash value is the md5 digest of 1abcd1234)
            string requestUrl = $"{_baseUrl}{apiString}?ts={timestamp}&apikey={_publicApiKey}&hash={hash}{additionalQuery}";

            var uri = new Uri(requestUrl);

            var httpResponse = new HttpResponseMessage();
            try
            {
                httpResponse = await _client.GetAsync(uri);
            }
            catch (Exception ex)
            {
                httpResponse = null;
                Console.WriteLine($"Ocorreu um problema na conexão com a API da Marvel, {ex}");
            }
            return httpResponse;
        }
        public async Task<CharacterDataWrapper> ExecuteCharRequest(string request, string additionalQuery = "")
        {
            var response = await RequestApiUrl(request, additionalQuery);

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<CharacterDataWrapper>(json);
        }
        public async Task<ComicDataWrapper> ExecuteComicRequest(string request, string additionalQuery = "")
        {
            var response = await RequestApiUrl(request, additionalQuery);

            if (response == null || !response.IsSuccessStatusCode)
                return null;

            var json = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<ComicDataWrapper>(json);
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
