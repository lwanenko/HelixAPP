using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamvvm;

namespace HelixK1
{
    public class MainPageModel : BasePageModel
    {
        public string Title { get; set; } = "HELIX ALPHA";
        public string WelcomeText { get; set; } = "HELIX ALPHA";

        public MainPageModel()
        {
            UIVerifyCommand = BaseCommand.FromTask<string>((param) => UIVerifyCommandExecute(param));
            UIAuthorizeCommand = BaseCommand.FromTask<string>((param) => UIAuthorizeCommandExecute(param));
            UIResetCommand = BaseCommand.FromTask<string>((param) => UIResetCommandExecute(param));
            UIImprintCommand = BaseCommand.FromTask<string>((param) => UIImprintCommandExecute(param));
            //UIFAKECommand = BaseCommand.FromTask<string>((param) => UIFAKECommandExecute(param));
            //K1ButtonCommand = BaseCommand.FromTask<string>((param) => K1ButtonCommandExecute(param));
            //UITestButtonCommand = BaseCommand.FromTask<string>((param) => UITestCommandExecute(param));
            //DevButtonCommand = BaseCommand.FromTask<string>((param) => DevButtonCommandExecute(param));
            //TestButtonCommand = BaseCommand.FromTask<string>((param) => TestButtonCommandExecute(param));
            //QRScanButtonCommand = BaseCommand.FromTask<string>((param) => QRScanButtonCommandExecute(param));
            //RestButtonCommand = BaseCommand.FromTask<string>((param) => RestButtonCommandExecute(param));
            //TestRestButtonCommand = BaseCommand.FromTask<string>((param) => TestRestButtonCommandExecute(param));
            //SettingsButtonCommand = BaseCommand.FromTask<string>((param) => SettingsButtonCommandExecute(param));
            //NetherCommand = BaseCommand.FromTask<string>((param) => NetherButtonCommandExecute(param));
        }

        public ICommand UIVerifyCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UIVerifyCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<UIIdentifyScanPageModel>();
        }

        public ICommand UIAuthorizeCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UIAuthorizeCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<UIAuthorizeScanPageModel>();
        }

        public ICommand UIResetCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UIResetCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<UIResetPageModel>();
        }

        public ICommand UIImprintCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UIImprintCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<UIImprintPageModel>();
        }

        public bool ShowVerifyButton
        {
            get
            {
                return Settings.EthPrvKey == String.Empty || Settings.EthPrvKey == "" ? true : false;
            }

        }

        public bool ShowAuthorizeButton
        {
            get
            {
                return ShowVerifyButton ? false : true;
            }

        }

        public override void OnAppearing()
        {
            base.OnAppearing();
            //    //if (Settings.EthPrvKey == String.Empty || Settings.EthPrvKey == "")
            //    //{
            //    //    ShowVerifyButton = true;
            //    //    ShowAuthorizeButton = false;

            //    //}
            //    //else
            //    //{
            //    //    ShowVerifyButton = false;
            //    //    ShowAuthorizeButton = true;
            //    //}
            //Task.Delay(2500);
            OnPropertyChanged(nameof(Settings.EthPrvKey));
            OnPropertyChanged(nameof(ShowVerifyButton));
            OnPropertyChanged(nameof(ShowAuthorizeButton));
        }

        //public ICommand UIFAKECommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task UIFAKECommandExecute(string param)
        //{
        //    EthPrvKey = "TEST";
        //    //await this.PushPageAsNewInstanceAsync<MainPageModel>();
        //    //await this.PushPageFromCacheAsync<MainPageModel>();
        //}

        //public ICommand K1ButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}
        //async Task K1ButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<K1PageModel>();
        //}
        //public ICommand UITestButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}
        //async Task UITestCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<UI1PageModel>();
        //}
        ////public ICommand DevButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task DevButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<DeveloperPageModel>();
        //} 

        //public ICommand TestButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task TestButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<TestPageModel>();
        //}

        //public ICommand QRScanButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task QRScanButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<QRScanPageModel>();
        //}

        //public ICommand RestButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task RestButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<RestPageModel>();
        //}

        //public ICommand TestRestButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task TestRestButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<TestRestPageModel>();
        //}

        //public ICommand NetherCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task NetherButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<NetherPageModel>();
        //}

        //public ICommand SettingsButtonCommand
        //{
        //    get { return GetField<ICommand>(); }
        //    set { SetField(value); }
        //}

        //async Task SettingsButtonCommandExecute(string param)
        //{
        //    await this.PushPageFromCacheAsync<SettingsPageModel>();
        //}

        //public string EthPrvKey
        //{
        //    get => Settings.EthPrvKey;
        //    set
        //    {
        //        if (Settings.EthPrvKey == value)
        //            return;

        //        Settings.EthPrvKey = value;
        //        OnPropertyChanged(nameof(Settings.EthPrvKey));
        //        OnPropertyChanged(nameof(ShowVerifyButton));
        //        OnPropertyChanged(nameof(ShowAuthorizeButton));
        //    }
        //}

    }
}
