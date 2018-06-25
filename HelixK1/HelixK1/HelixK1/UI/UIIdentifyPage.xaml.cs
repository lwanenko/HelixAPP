using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    [DisableCache]
    public partial class UIIdentifyPage : ContentPage, IBasePage<UIIdentifyPageModel>
    {
        public UIIdentifyPage()
        {
            InitializeComponent();
        }
    }
}
