using System;
using System.Net.Http;

namespace OpenDataGovRo.Factory
{
    public static class HttpClientFactory
    {
        private static readonly Lazy<HttpClient> _httpClientInstance = new Lazy<HttpClient>(() => 
        {
            var client = new HttpClient();
            client.Timeout = TimeSpan.FromMinutes(60);  // Set timeout to 60 minutes (3600 seconds)
            client.DefaultRequestHeaders.UserAgent.ParseAdd("Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/120.0.0.0 Safari/537.36 OpenDataGovRoTool/1.0");
            return client;
        });

        public static HttpClient Client => _httpClientInstance.Value;
    }
}
