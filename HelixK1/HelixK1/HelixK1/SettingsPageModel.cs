using System;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamvvm;

namespace HelixK1
{
    [DisableCache]
    public class SettingsPageModel : BasePageModel, IPageVisibilityChange
    {
        public string Title { get; set; } = "Settings";

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
                OnPropertyChanged(nameof(Settings.EthPubAddress));
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
                OnPropertyChanged(nameof(Settings.EthTransaction));
            }
        }

        public bool ShowWelcome
        {
            get => Settings.ShowWelcome;
            set
            {
                if (Settings.ShowWelcome == value)
                    return;

                Settings.ShowWelcome = value;
                OnPropertyChanged(nameof(Settings.ShowWelcome));
            }
        }

        public SettingsPageModel()
        {
            SetQRDefaultButtonCommand = BaseCommand.FromTask<string>((param) => SetQRDefaultButtonCommandExecute(param));
            OnPropertyChanged(nameof(Settings.LastQRCode));
            OnPropertyChanged(nameof(Settings.EthPubKey));

        }

        public ICommand SetQRDefaultButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task SetQRDefaultButtonCommandExecute(string param)
        {
            LastQRCode = "1133015910"; //TODO hardcoded for Test 
        }
    }
}