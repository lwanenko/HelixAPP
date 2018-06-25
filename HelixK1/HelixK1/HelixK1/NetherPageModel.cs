using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer;
using Xamvvm;

namespace HelixK1
{
    public class NetherPageModel : BasePageModel
    {

        public string Title { get; set; } = "Nethereum Tools ";
        public string WelcomeText { get; set; } = "";

        public NetherPageModel()
        {
            NetherGenKeyCommand = BaseCommand.FromTask<string>((param) => NetherGenKeyCommandExecute(param));
            NetherTxCommand = BaseCommand.FromTask<string>((param) => NethereumSignAndSerialzeTransaction(param));

        }

        public ICommand NetherGenKeyCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand NetherTxCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task NetherGenKeyCommandExecute(string param)
        {
            //Generate a private key pair using SecureRandom
            var ecKey = Nethereum.Signer.EthECKey.GenerateKey();

            //Get the Keys
            EthPubKey = ecKey.GetPubKey().ToHex();
            EthPubAddress = ecKey.GetPublicAddress();
            EthPrvKey = ecKey.GetPrivateKey();
        }

        async Task NethereumSignAndSerialzeTransaction(string param)
        {
            int x = 0;
            if (Int32.TryParse(Settings.LastQRCode, out x))
            {
                var nonce = x.ToBytesForRLPEncoding();
                var amount = 0.ToBytesForRLPEncoding();
                var to = "0x0000000000000000000000000000000000000000".HexToByteArray();
                var gasPrice = 10000000000000.ToBytesForRLPEncoding();
                var gasLimit = 21000.ToBytesForRLPEncoding();
                var data = "".HexToByteArray();
                //Create a transaction from scratch
                var tx = new RLPSigner(new byte[][] { nonce, gasPrice, gasLimit, to, amount, data });
                tx.Sign(new EthECKey(Settings.EthPrvKey.HexToByteArray(), true));
                var encoded = tx.GetRLPEncoded();

                HttpClient httpClient = new HttpClient();

                // TODO var url = Settings.url_tx;
                var url = "https://blockchainhelix.mybluemix.net/dlb/user/response";
                HttpResponseMessage response = httpClient.PostAsync(url, new ByteArrayContent(encoded)).Result;
                httpClient.Dispose();
            }
        }

        //Properties bounded to Settings 
        public string EthPubKey
        {
            get => Settings.EthPubKey;
            set
            {
                if (Settings.EthPubKey == value)
                    return;

                Settings.EthPubKey = value;
                OnPropertyChanged(nameof(Settings.EthPubKey));
            }
        }

        public string EthPrvKey
        {
            get => Settings.EthPrvKey;
            set
            {
                if (Settings.EthPrvKey == value)
                    return;

                Settings.EthPrvKey = value;
                OnPropertyChanged(nameof(Settings.EthPrvKey));
            }
        }

        public string EthPubAddress
        {
            get => Settings.EthPubAddress;
            set
            {
                if (Settings.EthPubAddress == value)
                    return;

                Settings.EthPubAddress = value;
                OnPropertyChanged(nameof(Settings.EthPubAddress));
            }
        }

        public string EthTransaction
        {
            get => Settings.EthTransaction;
            set
            {
                if (Settings.EthTransaction == value)
                    return;

                Settings.EthTransaction = value;
                OnPropertyChanged(nameof(Settings.EthTransaction));
            }
        }
    }
}