using System;
using System.Threading.Tasks;
using Refit;

namespace HelixK1
{
    public class RestClient
    {
        private readonly IRestClient _restClient;

        public RestClient()
        {
            _restClient = RestService.For<IRestClient>("http://jsonplaceholder.typicode.com");
        }

        public async Task<Foo[]> GetPosts()
        {
            return await _restClient.GetPosts();
        }

        public async Task<Foo> GetPost(int id)
        {
            return await _restClient.GetPost(id);
        }

        public async Task AddPost(Foo foo)
        {
            await _restClient.AddPost(foo);
        }
    }
}