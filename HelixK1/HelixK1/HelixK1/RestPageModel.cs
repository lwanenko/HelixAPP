using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamvvm;

namespace HelixK1
{
    public class RestPageModel : BasePageModel
    {

        public string Title { get; set; } = "K1 REST Page";
        public string WelcomeText { get; set; } = "Hello K1 REST";

        //public string ResultLabel { get; set; } = "something else ...";
        public string ResultLabel
        {
            get { return GetField<string>(); }
            set
            {
                SetField(value);
            }
        }

        //Sample stuff REFACTOR once it works
        private readonly RestK1Client _restK1Client;

        public RestPageModel()
        {
            _restK1Client = new RestK1Client();

            RestPostOneCommand = BaseCommand.FromTask<string>((param) => RestPostOneCommandExecute(param));
            RestPostTwoCommand = BaseCommand.FromTask<string>((param) => RestPostTwoCommandExecute(param));
            RestPostThreeCommand = BaseCommand.FromTask<string>((param) => RestPostThreeCommandExecute(param));

            BackButtonCommand = new BaseCommand(async (arg) =>
            {
                await this.PopPageAsync();
            });
        }

        public ICommand BackButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand RestPostOneCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand RestPostTwoCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand RestPostThreeCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        //  <Button Text = "Send PubKey" Command="{Binding RestPostOneCommand}" CommandParameter="this is a Rest 1 parameter" />
        //  <Button Text = "Send Response" Command="{Binding RestPostTwoCommand}" CommandParameter="this is a Rest 2 parameter" />
        //  <Button Text = "Get Metrics" Command="{Binding RestPostThreeCommand}" CommandParameter="this is a Rest 3 parameter" />

        async Task RestPostOneCommandExecute(string param)
        {
            // challengepubkey
            int i;
            Int32.TryParse(Settings.LastQRCode, out i);

            var cpk = new ChallengePubKey
            {
                challenge = i,
                pubkey = Settings.EthPubKey
            };

            ResultLabel = await _restK1Client.AddPostPubKey(cpk);

        }

        async Task RestPostTwoCommandExecute(string param)
        {
            // Response
            //var rp = new Response
            //{
            //    response = Settings.EthTransaction,
            //    pubkey = Settings.EthPubKey
            //};



            //ResultLabel = await _restK1Client.AddPostResponse(rp);

        }

        async Task RestPostThreeCommandExecute(string param)
        {
            var metricsCollection = await _restK1Client.GetMetrics();

            ResultLabel = $"{ metricsCollection[0].id} - { metricsCollection[0].amount} - { metricsCollection[0].count}";

        }
    }
}
