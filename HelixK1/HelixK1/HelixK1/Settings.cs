using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace HelixK1
{
    /// <summary>
    /// This is the Settings static class that can be used in your Core solution or in any
    /// of your client applications. All settings are laid out the same exact way with getters
    /// and setters. 
    /// </summary>
    public static class Settings
    {
        private static ISettings AppSettings
        {
            get
            {
                return CrossSettings.Current;
            }
        }

        #region Setting Constants

        private const string SettingsKey = "settings_key";
        private static readonly string SettingsDefault = string.Empty;

        public const string url_k1_rest = "http://jsonplaceholder.typicode.com";
        public const string url_tx = "https://blockchainhelix.mybluemix.net/dlb/user/response";
        #endregion

        public static string Logger
        {
            get => AppSettings.GetValueOrDefault(nameof(Logger), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(Logger), value);
        }

        public static string QRScannerReferrer
        {
            get => AppSettings.GetValueOrDefault(nameof(QRScannerReferrer), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(QRScannerReferrer), value);
        }

        public static string LastQRCode
        {
            get => AppSettings.GetValueOrDefault(nameof(LastQRCode), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(LastQRCode), value);
        }

        public static string EthPubAddress
        {
            get => AppSettings.GetValueOrDefault(nameof(EthPubAddress), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(EthPubAddress), value);
        }

        public static string EthPrvKey
        {
            get => AppSettings.GetValueOrDefault(nameof(EthPrvKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(EthPrvKey), value);
        }

        public static string EthPubKey
        {
            get => AppSettings.GetValueOrDefault(nameof(EthPubKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(EthPubKey), value);
        }

        public static string XLastQRCode
        {
            get => AppSettings.GetValueOrDefault(nameof(XLastQRCode), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(XLastQRCode), value);
        }

        public static string XEthPubAddress
        {
            get => AppSettings.GetValueOrDefault(nameof(XEthPubAddress), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(XEthPubAddress), value);
        }

        public static string XEthPrvKey
        {
            get => AppSettings.GetValueOrDefault(nameof(XEthPrvKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(XEthPrvKey), value);
        }

        public static string XEthPubKey
        {
            get => AppSettings.GetValueOrDefault(nameof(XEthPubKey), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(XEthPubKey), value);
        }

        public static string EthTransaction
        {
            get => AppSettings.GetValueOrDefault(nameof(EthTransaction), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(EthTransaction), value);
        }

        public static bool ShowWelcome
        {
            get => AppSettings.GetValueOrDefault(nameof(ShowWelcome), true);
            set => AppSettings.AddOrUpdateValue(nameof(ShowWelcome), value);
        }

        public static string TaskResult
        {
            get => AppSettings.GetValueOrDefault(nameof(TaskResult), string.Empty);
            set => AppSettings.AddOrUpdateValue(nameof(TaskResult), value);
        }

        public static void CleanXKeys()
        {
            Settings.XEthPrvKey = "";
            Settings.XEthPubKey = "";
            Settings.XLastQRCode = "";
            Settings.XEthPubAddress = "";
        }

        public static void XKeys2Keys()
        {
            Settings.EthPrvKey = XEthPrvKey;
            Settings.EthPubKey = XEthPubKey;
            Settings.EthPubAddress = XEthPubAddress;
            Settings.LastQRCode = XLastQRCode;
            Settings.CleanXKeys();
        }

    }
}