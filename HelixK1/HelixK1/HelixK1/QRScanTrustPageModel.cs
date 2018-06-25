using System;
using Xamvvm;
using ZXing.Net.Mobile.Forms;

namespace HelixK1
{
    public class QRScanTrustPageModel : BasePageModel, IPageVisibilityChange
    {
        public string Title
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public QRScanTrustPageModel()
        {
            Title = "QR Scan";
            var currentPage = this.GetCurrentPage();
        }
    }
}
