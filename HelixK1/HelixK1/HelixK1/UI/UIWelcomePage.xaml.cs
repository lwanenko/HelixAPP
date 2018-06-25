using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    public partial class UIWelcomePage : ContentPage, IBasePage<UIWelcomePageModel>
    {
        public UIWelcomePage()
        {
            InitializeComponent();
        }
    }
}
