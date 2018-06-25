using System;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Net.Http;
using Nethereum.Hex.HexConvertors.Extensions;
using Nethereum.RLP;
using Nethereum.Signer;
using Xamvvm;

namespace HelixK1
{
    public class UIResetPageModel : BasePageModel
    {

        public string DescriptionText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        //public string NoticeText
        //{
        //    get { return GetField<string>(); }
        //    set { SetField(value); }
        //}

        public UIResetPageModel()
        {
            UIBackButtonCommand = BaseCommand.FromTask<string>((param) => UIBackCommandExecute(param));
            ResetButtonCommand = BaseCommand.FromTask<string>((param) => ResetButtonCommandExecute(param));
            DescriptionText = @"You want to start over again, reset your HELIX ALPHA APP by deleting the Private Key from the smartphone.";
        }

        public ICommand UIBackButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UIBackCommandExecute(string param)
        {
            await this.PopPageAsync();
        }

        public ICommand ResetButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task ResetButtonCommandExecute(string param)
        {
            //cleanup
            //Settings.CleanKeys();
            Settings.EthPubKey = "";
            Settings.EthPrvKey = "";
            Settings.EthPubAddress = "";
            Settings.EthTransaction = "";
            Settings.LastQRCode = "";
            // ShowWelcome = true;
            await this.PopPageAsync();
            //await this.SetNewRootAndResetAsync<MainPageModel>();
            //await this.GetCurrentPage().GetPageFromCache<MainPageModel>();
            //await this.PopPagesToRootAsync();
        }

        //Properties bounded to Settings 
        public string EthPubKey
        {
            get => Settings.EthPubKey;
            set
            {
                if (Settings.EthPubKey == value)
                    return;

                Settings.EthPubKey = value;
                OnPropertyChanged(nameof(Settings.EthPubKey));
            }
        }

        public string EthPrvKey
        {
            get => Settings.EthPrvKey;
            set
            {
                if (Settings.EthPrvKey == value)
                    return;

                Settings.EthPrvKey = value;
                OnPropertyChanged(nameof(Settings.EthPrvKey));
            }
        }

        public string EthPubAddress
        {
            get => Settings.EthPubAddress;
            set
            {
                if (Settings.EthPubAddress == value)
                    return;

                Settings.EthPubAddress = value;
                // OnPropertyChanged(nameof(Settings.EthPubAddress));
            }
        }

        public string EthTransaction
        {
            get => Settings.EthTransaction;
            set
            {
                if (Settings.EthTransaction == value)
                    return;

                Settings.EthTransaction = value;
                // OnPropertyChanged(nameof(Settings.EthTransaction));
            }
        }

        public string LastQRCode
        {
            get => Settings.LastQRCode;
            set
            {
                if (Settings.LastQRCode == value)
                    return;

                Settings.LastQRCode = value;
                OnPropertyChanged(nameof(Settings.LastQRCode));
            }
        }

        //public string TaskResult
        //{

        //    get => Settings.TaskResult;
        //    set
        //    {
        //        if (Settings.TaskResult == value)
        //            return;

        //        Settings.TaskResult = value;
        //        OnPropertyChanged(nameof(Settings.TaskResult));
        //    }

        //}

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
    }
}
