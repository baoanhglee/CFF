using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Text;
using System.Threading.Tasks;

namespace Cyberdex.DexUtils
{
    public static partial class PokeApi
    {
        private const string ROOT_API_URL_V2 = @"https://pokeapi.co/api/v2/";
        private const string USER_AGENT = @"Mozilla/5.0 (Windows NT 6.1; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/58.0.3029.110 Safari/537.36";

        private static UriInfo _apiUri = CallRoot();

        public static UriInfo ApiUri { get => _apiUri; }

        private static UriInfo CallRoot()
        {
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
                var response = httpClient.GetStringAsync(new Uri(ROOT_API_URL_V2)).Result;
                return UriInfo.FromJson(response);
            }
        }

        private static Uri GetUriWithPaging(string url, int limit, int page)
        {
            UriBuilder builder = new UriBuilder(url);
            var query = HttpUtility.ParseQueryString(builder.Query);
            query["limit"] = limit.ToString();
            query["offset"] = (limit * (page - 1)).ToString();
            builder.Query = query.ToString();
            return builder.Uri;
        }

        public static ApiResult Call_GetList(string requestUrl, int limit=20, int page=1)
        {
            var uri = GetUriWithPaging(requestUrl, limit, page);
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Add("User-Agent", USER_AGENT);
                var response = httpClient.GetStringAsync(uri).Result;
                return ApiResult.FromJson(response);
            }
        }
    }
}