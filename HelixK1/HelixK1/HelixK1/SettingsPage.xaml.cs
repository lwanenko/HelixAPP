using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    [DisableCache]
    public partial class SettingsPage : ContentPage, IBasePage<SettingsPageModel>
    {
        public SettingsPage()
        {
            InitializeComponent();
        }
    }


}
