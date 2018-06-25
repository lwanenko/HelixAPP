using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    [DisableCache]
    public partial class MainPage : ContentPage, IBasePage<MainPageModel>
    {
        public MainPage()
        {
            InitializeComponent();
        }
    }
}
