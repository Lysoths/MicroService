using System;
using System.Net;
using orderApi.Interfaces;

namespace orderApi.Helpers
{
    public class ServiceCallHelper : IServiceCallHelper
    {
        public async Task<string> GetAsync(string uri)
        {
            using (HttpClient httpClient = new HttpClient())
            {
                return await httpClient.GetStringAsync(uri);
            }
        }

        public async Task<string> Post(string uri, HttpMethod httpMethod, string content)
        {
            using(var client=new HttpClient())
            {
                var request = new HttpRequestMessage(httpMethod,uri);
                request.Content = new StringContent(content, System.Text.Encoding.UTF8,"application/json");
                request.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var response = await client.SendAsync(request);
                response.EnsureSuccessStatusCode();
                return await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            }
        }
    }
}

