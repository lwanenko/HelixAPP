using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer;
using Xamarin.Forms;
using Xamvvm;
using ZXing.Net.Mobile.Forms;



namespace HelixK1
{
    [DisableCache]
    public partial class QRScanIdentityPage : ContentPage, IBasePage<QRScanIdentityPageModel>
    {

        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;
        bool scanFinished = false;

        public void Scan()
        {
            var _pubkey = "";
            var _pubAddress = "";
            var _prvkey = "";
            var _lastQRCode = "";

            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () =>
                {
                    if (!scanFinished)
                    {
                        scanFinished = true;
                        // Stop analysis until we navigate away so we don't keep reading barcodes
                        zxing.IsAnalyzing = false;

                        // The QR Code is in result.Text
                        _lastQRCode = result.Text;

                        int i;
                        bool keyisint;
                        keyisint = Int32.TryParse(_lastQRCode, out i);
                        //result = $"QRCode verify is number: {keyisint} i: {i}" + " << " + result;
                        //TaskResult = result;
                        //Generate a private key pair using SecureRandom
                        var ecKey = Nethereum.Signer.EthECKey.GenerateKey();

                        //Get the Keys
                        _pubkey = ecKey.GetPubKey().ToHex();
                        _pubAddress = ecKey.GetPublicAddress();
                        _prvkey = ecKey.GetPrivateKey();
                        //Settings.EthPubKey = ecKey.GetPubKey().ToHex();
                        //Settings.EthPubAddress = ecKey.GetPublicAddress();
                        //Settings.EthPrvKey = ecKey.GetPrivateKey();

                        //result = "New Etherium Key generated" + " << " + result;
                        //send public key
                        string challengesent = "";
                        if (keyisint)
                        {
                            var cpk = new ChallengePubKey
                            {
                                challenge = i,
                                pubkey = _pubkey
                            };

                            challengesent = await _restK1Client.AddPostPubKey(cpk);

                        }
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
                            tx.Sign(new EthECKey(_prvkey.HexToByteArray(), true));
                            var encoded = tx.GetRLPEncoded();

                            HttpClient httpClient = new HttpClient();

                            // TODO var url = Settings.url_tx;
                            var url = "https://blockchainhelix.mybluemix.net/dlb/user/response";
                            HttpResponseMessage response = httpClient.PostAsync(url, new ByteArrayContent(encoded)).Result;
                            httpClient.Dispose();

                            //result = "tx: " + response.Content.ReadAsStringAsync() + " << " + result;
                            Settings.XEthPubKey = _pubkey;
                            Settings.XEthPubAddress = _pubAddress;
                            Settings.XEthPrvKey = _prvkey;
                            Settings.XLastQRCode = _lastQRCode;
                        }
                        else
                        {
                            //cleanup
                            Settings.CleanXKeys();
                            //Settings.XEthPrvKey = "TEST";
                        }

                        await this.GetPageModel().PopPageAsync();
                    }
                });

            overlay = new ZXingDefaultOverlay
            {
                TopText = "Hold your phone up to the QR Code",
                BottomText = "Scanning will happen automatically",
                ShowFlashButton = zxing.HasTorch,
            };
            overlay.FlashButtonClicked += (sender, e) =>
            {
                zxing.IsTorchOn = !zxing.IsTorchOn;
            };

            //Grid
            var grid = new Grid
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };
            grid.Children.Add(zxing);
            grid.Children.Add(overlay);

            Content = grid;
        }

        private readonly RestK1Client _restK1Client;

        public QRScanIdentityPage()
        {
            InitializeComponent();
            _restK1Client = new RestK1Client();
            Scan();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();

            zxing.IsScanning = true;
        }

        protected override void OnDisappearing()
        {
            zxing.IsScanning = false;

            base.OnDisappearing();
        }
    }
}
