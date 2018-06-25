using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer;
using Xamvvm;

namespace HelixK1
{
    public class K1PageModel : BasePageModel
    {

        private readonly RestK1Client _restK1Client;

        public K1PageModel()
        {
            _restK1Client = new RestK1Client();
            K1NewUserButtonCommand = BaseCommand.FromTask<string>((param) => K1NewUserButtonCommandExecute(param));
            K1ConfirmButtonCommand = BaseCommand.FromTask<string>((param) => K1ConfirmButtonCommandExecute(param));
            K1ResetButtonCommand = BaseCommand.FromTask<string>((param) => K1ResetButtonCommandExecute(param));
            UINewUserButtonCommand = BaseCommand.FromTask<string>((param) => UINewUserCommandExecute(param));
            UITrustAuthorizationButtonCommand = BaseCommand.FromTask<string>((param) => UITrustAuthorizationCommandExecute(param));
        }

        public ICommand UITrustAuthorizationButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UITrustAuthorizationCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<UITrustAuthorizationPageModel>();
        }

        public ICommand UINewUserButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UINewUserCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<UINewUserPageModel>();
        }

        public ICommand K1NewUserButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task K1NewUserButtonCommandExecute(string param)
        {
            var result = "";
            if (EthPubKey != "")
            {
                //alert "Key exists! Delete your Keys first before creating new account!"
                result = "Key exists, did not create new Key";
            }
            else
            {
                //cleanup
                EthPubKey = "";
                EthPrvKey = "";
                EthPubAddress = "";
                LastQRCode = "";

                await this.PushPageFromCacheAsync<QRScanPageModel>();
                await Task.Delay(2500);
                var _lastqrcode = LastQRCode;
                if (_lastqrcode != "")
                {
                    result = "qr code generated" + " << " + result;
                }
                int i;
                bool keyisint;
                keyisint = Int32.TryParse(LastQRCode, out i);
                result = $"QRCode verify is number: {keyisint} i: {i}" + " << " + result;
                TaskResult = result;
                //Generate a private key pair using SecureRandom
                var ecKey = Nethereum.Signer.EthECKey.GenerateKey();

                //Get the Keys
                EthPubKey = ecKey.GetPubKey().ToHex();
                EthPubAddress = ecKey.GetPublicAddress();
                EthPrvKey = ecKey.GetPrivateKey();

                result = "New Etherium Key generated" + " << " + result;



                //send public key

                string challengesent = "";
                if (keyisint)
                {
                    var cpk = new ChallengePubKey
                    {
                        challenge = i,
                        pubkey = EthPubKey
                    };

                    challengesent = await _restK1Client.AddPostPubKey(cpk);
                    result = "ChallengePubKey sent true? " + " << " + result;
                }

                // if true send transaction
                if (challengesent == "true")
                {

                    var nonce = i.ToBytesForRLPEncoding();
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

                    result = "tx: " + response.Content.ReadAsStringAsync() + " << " + result;
                }
            }

            //if successful key created!
            TaskResult = result;
        }



        public ICommand K1ConfirmButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task K1ConfirmButtonCommandExecute(string param)
        {
            var result = "";
            TaskResult = result;
            // LastQRCode = "";
            if (EthPubKey == "")
            {
                result = "no public key found!";
            }
            else
            {
                result = "public key found";
                await this.PushPageFromCacheAsync<QRScanPageModel>();
                await Task.Delay(2500);
                var _lastqrcode = LastQRCode;
                if (_lastqrcode != "")
                {
                    result = "qr code generated" + " << " + result;
                }

                int i;
                bool keyisint;
                keyisint = Int32.TryParse(LastQRCode, out i);
                result = $"QRCode verify is number: {keyisint} i: {i}" + " << " + result;
                TaskResult = result;
                if (keyisint)
                {
                    result = "building tx..." + " << " + result;
                    var nonce = i.ToBytesForRLPEncoding();
                    var amount = 0.ToBytesForRLPEncoding();
                    var to = "0x0000000000000000000000000000000000000000".HexToByteArray();
                    var gasPrice = 10000000000000.ToBytesForRLPEncoding();
                    var gasLimit = 21000.ToBytesForRLPEncoding();
                    var data = "".HexToByteArray();
                    //Create a transaction from scratch
                    var tx = new RLPSigner(new byte[][] { nonce, gasPrice, gasLimit, to, amount, data });
                    tx.Sign(new EthECKey(Settings.EthPrvKey.HexToByteArray(), true));
                    var encoded = tx.GetRLPEncoded();

                    result = "sending tx ..." + " << " + result;

                    HttpClient httpClient = new HttpClient();

                    // TODO var url = Settings.url_tx;
                    var url = "https://blockchainhelix.mybluemix.net/dlb/user/response";
                    HttpResponseMessage response = httpClient.PostAsync(url, new ByteArrayContent(encoded)).Result;
                    httpClient.Dispose();

                    result = "tx: " + response.Content.ReadAsStringAsync() + " << " + result;
                }
                TaskResult = result;

            }
        }


        public ICommand K1ResetButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task K1ResetButtonCommandExecute(string param)
        {
            //cleanup
            EthPubKey = "";
            EthPrvKey = "";
            EthPubAddress = "";
            EthTransaction = "";
            LastQRCode = "";
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

        public string LastQRCode
        {
            get => Settings.LastQRCode;
            set
            {
                if (Settings.LastQRCode == value)
                    return;

                Settings.LastQRCode = value;
                OnPropertyChanged(nameof(Settings.LastQRCode));
            }
        }

        public string TaskResult
        {

            get => Settings.TaskResult;
            set
            {
                if (Settings.TaskResult == value)
                    return;

                Settings.TaskResult = value;
                OnPropertyChanged(nameof(Settings.TaskResult));
            }

        }
    }
}