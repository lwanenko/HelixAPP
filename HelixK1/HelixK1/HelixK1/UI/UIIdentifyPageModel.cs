using System;
using Xamvvm;

namespace HelixK1
{
    public class UIIdentifyPageModel : BasePageModel
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


        public UIIdentifyPageModel()
        {

            DescriptionText = @"You have already created a Digital Identity with our Desktop Solution my.blockchain-helix.com - GREAT!

Now it is time to verify your HELIX Account with a QR Code coming from the Desktop.

Click on the button below and we onboard you to HELIX.";
            NoticeText = @"Please note that the APP is for demonstration purposes only and NOT productive.";
        }
    }
}
