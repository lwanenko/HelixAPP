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
    public class UIIdentifyScanPageModel : BasePageModel
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

        public UIIdentifyScanPageModel()
        {
            ScanButtonCommand = BaseCommand.FromTask<string>((param) => ScanButtonCommandExecute(param));

            DescriptionText = @"You have already created a Digital Identity with our Desktop Solution my.blockchain-helix.com - GREAT!

Now it is time to verify your HELIX Account with a QR Code coming from the Desktop.

Click on the button below and we onboard you to HELIX.";
            NoticeText = @"Please note that the APP is for demonstration purposes only and NOT productive.";

        }

        public ICommand ScanButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task ScanButtonCommandExecute(string param)
        {
            //await this.PushPageAsNewInstanceAsync<QRScanIdentityPageModel>();
            await this.PushPageFromCacheAsync<QRScanIdentityPageModel>();
        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            //Task.Delay(2500);
            if (Settings.XEthPrvKey != "")
            {
                Settings.XKeys2Keys();
                this.PopPageAsync();
            }
        }
    }
}
