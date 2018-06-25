using System;
using System.IO;
using System.Threading.Tasks;
using Refit;

namespace HelixK1
{
    public interface IRestK1Client
    {
        [Get("/dlb/ethereum/getTransactionsPerMinuteMetrics")]
        Task<Metrics[]> GetMetrics();

        [Post("/dlb/user/pubkey")]
        Task<String> AddPostPubKey(ChallengePubKey cp);

        //[Multipart]
        [Post("/dlb/user/response")]
        Task<String> AddPostResponse(Response response);

    }
}