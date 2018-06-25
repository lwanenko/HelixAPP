using System;
using System.Collections.Generic;

using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    public partial class TestPage : ContentPage, IBasePage<TestPageModel>
    {
        public TestPage()
        {
            InitializeComponent();
        }
    }
}
