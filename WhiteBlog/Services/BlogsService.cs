using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.AspNetCore.WebUtilities;
using WhiteBlog.Models;

namespace WhiteBlog.Services
{
    public class GitHubBranch
    {
        public string name { get; set; }
        public Dictionary<string, string> commit { get; set; }
        public bool @protected;
    }

    public class BlogsService
    {
        private readonly IHttpClientFactory _clientFactory;

        public BlogsService(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }

        public async Task<Response<List<Blog>>> GetBlogsByPage(int page, int limit)
        {
            var request =
                new HttpRequestMessage(HttpMethod.Get,
                    $"https://rockrockwhite.cn:4333/api/Blogs?page={page}&limit={limit}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);
            

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                var blogs = await JsonSerializer.DeserializeAsync
                    <Response<List<Blog>>>(responseStream, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    }).ConfigureAwait(false);

                return blogs;
            }
            else
            {
                return null;
            }
        }


        public async Task<Response<Blog>> GetBlogById(string id)
        {
            var request =
                new HttpRequestMessage(HttpMethod.Get,
                    $"https://rockrockwhite.cn:4333/api/Blogs/{id}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request).ConfigureAwait(false);


            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false);

                var blog = await JsonSerializer.DeserializeAsync
                    <Response<Blog>>(responseStream, new JsonSerializerOptions()
                    {
                        PropertyNameCaseInsensitive = true
                    }).ConfigureAwait(false);

                return blog;
            }
            else
            {
                return null;
            }
        }
    }
}