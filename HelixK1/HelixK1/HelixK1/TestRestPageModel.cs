using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamvvm;

namespace HelixK1
{
    public class TestRestPageModel : BasePageModel
    {
        public string Title { get; set; } = "REST Page";
        public string WelcomeText { get; set; } = "Hello REST";

        public string ResultLabel
        {
            get { return GetField<string>(); }
            set
            {
                SetField(value);
            }
        }

        //Sample stuff REFACTOR once it works
        private string _baseApiUrl = "https://jsonplaceholder.typicode.com";
        private string _waiting_for = "waiting ...";
        private readonly RestClient _restClient;

        public TestRestPageModel()
        {
            _restClient = new RestClient();

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

        async Task RestPostOneCommandExecute(string param)
        {

            var fooCollection = await _restClient.GetPosts();

            ResultLabel = $"{fooCollection[0].id} - {fooCollection[0].title}";
        }

        async Task RestPostTwoCommandExecute(string param)
        {
            var foo = await _restClient.GetPost(3);

            ResultLabel = $"{foo.id} - {foo.title}";
        }

        async Task RestPostThreeCommandExecute(string param)
        {
            ResultLabel = "RestPostThreeCommandExecute";
            var foo = new Foo
            {
                id = 1337,
                title = "Awesome!",
                body = "Unicorns and rainbows",
                userId = 1
            };

            await _restClient.AddPost(foo);

            ResultLabel = $"Added";

        }
    }
}
