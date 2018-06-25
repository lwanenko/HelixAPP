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
    public class UIAuthorizeScanPageModel : BasePageModel
    {
        public string DescriptionText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public string NoticeText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }


        public UIAuthorizeScanPageModel()
        {
            ScanButtonCommand = BaseCommand.FromTask<string>((param) => ScanButtonCommandExecute(param));
            DescriptionText = @"Try out how to authorize TRUST via HELIX APP.
             
By doing this play around like you would be giving HELIX TRUST to Digital Identities.

On your Desktop Solution go to TRUST Network > TRUST Taker or > TRUST Provider and use this QR Code to proceed.";

            NoticeText = @"Please note that the APP is for demonstration purposes only and NOT productive.";


        }

        public ICommand ScanButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task ScanButtonCommandExecute(string param)
        {
            //var result = "";
            if (EthPrvKey != "")
            {
                await this.PushPageFromCacheAsync<QRScanTrustPageModel>();
            }
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            if (Settings.XLastQRCode != "")
            {
                Settings.XLastQRCode = "";
                this.PopPageAsync();
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


    }
}
