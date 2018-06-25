using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    public partial class App : Application
    {

        //public bool ShowWelcome
        //{
        //    get => Settings.ShowWelcome;
        //    set
        //    {
        //        if (Settings.ShowWelcome == value)
        //            return;

        //        Settings.ShowWelcome = value;
        //        OnPropertyChanged(nameof(Settings.ShowWelcome));
        //    }
        //}

        public App()
        {
            InitializeComponent();
            var factory = new XamvvmFormsFactory(this);
            //if (ShowWelcome == true)
            //{
            //    factory.RegisterNavigationPage<MainNavigationPageModel>(
            //        () => this.GetPageFromCache<UIWelcomePageModel>());
            //}
            //else
            //{
            //    factory.RegisterNavigationPage<MainNavigationPageModel>(
            //        () => this.GetPageFromCache<MainPageModel>());
            //}
            factory.RegisterNavigationPage<MainNavigationPageModel>(
                () => this.GetPageFromCache<UIWelcomePageModel>());
            XamvvmCore.SetCurrentFactory(factory);
            MainPage = this.GetPageFromCache<MainNavigationPageModel>() as NavigationPage;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
