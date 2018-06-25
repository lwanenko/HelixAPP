using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamvvm;

namespace HelixK1
{
    public class DeveloperPageModel : BasePageModel
    {
        public DeveloperPageModel()
        {

            TestButtonCommand = BaseCommand.FromTask<string>((param) => TestButtonCommandExecute(param)); QRScanButtonCommand = BaseCommand.FromTask<string>((param) => QRScanButtonCommandExecute(param));
            RestButtonCommand = BaseCommand.FromTask<string>((param) => RestButtonCommandExecute(param));
            TestRestButtonCommand = BaseCommand.FromTask<string>((param) => TestRestButtonCommandExecute(param));
            NetherCommand = BaseCommand.FromTask<string>((param) => NetherButtonCommandExecute(param));
            QRScanButtonCommand = BaseCommand.FromTask<string>((param) => QRScanButtonCommandExecute(param));
            SettingsButtonCommand = BaseCommand.FromTask<string>((param) => SettingsButtonCommandExecute(param));

        }

        public ICommand TestButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task TestButtonCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<TestPageModel>();
        }

        public ICommand QRScanButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task QRScanButtonCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<QRScanPageModel>();
        }

        public ICommand RestButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }



        async Task RestButtonCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<RestPageModel>();
        }

        public ICommand TestRestButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task TestRestButtonCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<TestRestPageModel>();
        }

        public ICommand NetherCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task NetherButtonCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<NetherPageModel>();
        }

        public ICommand SettingsButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task SettingsButtonCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<SettingsPageModel>();
        }
    }
}
