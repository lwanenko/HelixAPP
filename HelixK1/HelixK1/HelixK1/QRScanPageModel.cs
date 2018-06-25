using System.Windows.Input;
using Xamvvm;
using ZXing.Net.Mobile.Forms;

namespace HelixK1
{
    [DisableCache]
    public class QRScanPageModel : BasePageModel, IPageVisibilityChange
    {

        // The Code you are rightfully looking for in the PageModel is exceptionally in the Page
        // The Implemetation of the third party QR Scanner is deeply intertwined with the UI
        public string Title
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public QRScanPageModel()
        {
            Title = "QR Scan";

            var currentPage = this.GetCurrentPage();

        }
    }
}