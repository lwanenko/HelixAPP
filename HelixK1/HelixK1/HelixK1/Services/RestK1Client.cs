using System;
using System.IO;
using System.Threading.Tasks;
using Refit;

namespace HelixK1
{
    public class RestK1Client
    {
        private readonly IRestK1Client _restK1Client;

        public RestK1Client()
        {
            // TODO _restK1Client = RestService.For<IRestK1Client>(Settings.url_k1_rest);
            _restK1Client = RestService.For<IRestK1Client>("https://blockchainhelix.mybluemix.net"); //HELIX Adresse!!!
            //_restK1Client = RestService.For<IRestK1Client>("https://bchelixtest03.eu-gb.mybluemix.net"); //HELIX Adresse!!!

        }

        public async Task<Metrics[]> GetMetrics()
        {
            return await _restK1Client.GetMetrics();
        }

        public async Task<string> AddPostPubKey(ChallengePubKey pb)
        {
            return await _restK1Client.AddPostPubKey(pb);
        }

        //Stream stream = new MemoryStream(byteArray);

        public async Task<string> AddPostResponse(Response response)
        {
            return await _restK1Client.AddPostResponse(response);
        }
    }

}
