using Xamarin.Forms;
using Xamvvm;
using ZXing.Net.Mobile.Forms;

namespace HelixK1
{
    [DisableCache]
    public partial class QRScanPage : ContentPage, IBasePage<QRScanPageModel>
    {
        ZXingScannerView zxing;
        ZXingDefaultOverlay overlay;

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

        public void Scan()
        {

            zxing = new ZXingScannerView
            {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand
            };
            zxing.OnScanResult += (result) =>
                Device.BeginInvokeOnMainThread(async () =>
                {

                    // Stop analysis until we navigate away so we don't keep reading barcodes
                    zxing.IsAnalyzing = false;

                    // The QR Code is in result.Text
                    LastQRCode = result.Text;

                    //Navigate away from the PageModel as intended by xamvvm

                    await this.GetPageModel().PopPageAsync();

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

        public QRScanPage()
        {
            InitializeComponent();
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
