using System;
using System.Threading.Tasks;
using System.Net.Http;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer;

namespace HelixK1
{
    public class HttpTxSender
    {
        public HttpTxSender()
        {
        }

        //public async Task SignSerialzeSendTransaction(string param)
        //{
        //    int x = 0;
        //    if (Int32.TryParse(Settings.LastQRCode, out x))
        //    {
        //        var nonce = x.ToBytesForRLPEncoding();
        //        var amount = 0.ToBytesForRLPEncoding();
        //        var to = "0x0000000000000000000000000000000000000000".HexToByteArray();
        //        var gasPrice = 10000000000000.ToBytesForRLPEncoding();
        //        var gasLimit = 21000.ToBytesForRLPEncoding();
        //        var data = "".HexToByteArray();
        //        //Create a transaction from scratch
        //        var tx = new RLPSigner(new byte[][] { nonce, gasPrice, gasLimit, to, amount, data });
        //        tx.Sign(new EthECKey(Settings.EthPrvKey.HexToByteArray(), true));
        //        var encoded = tx.GetRLPEncoded();

        //        HttpClient httpClient = new HttpClient();

        //        // TODO var url = Settings.url_tx;
        //        var url = "https://blockchainhelix.mybluemix.net/dlb/user/response";
        //        HttpResponseMessage response = httpClient.PostAsync(url, new ByteArrayContent(encoded)).Result;
        //        httpClient.Dispose();
        //    }
        //}
    }
}
