using System;
using System.Threading.Tasks;
using System.Windows.Input;
using CarouselView.FormsPlugin.Abstractions;
using Xamvvm;

namespace HelixK1
{
    public class UIWelcomePageModel : BasePageModel
    {
        public string Title { get; set; } = "Welcome";
        public string Description { get; set; } = "HELIX ALPHA";

        public UIWelcomePageModel()
        {
            //Settings.CleanKeys();
            UIStartCommand = BaseCommand.FromTask<string>((param) => UIStartCommandExecute(param));
        }

        public ICommand UIStartCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        async Task UIStartCommandExecute(string param)
        {
            await this.PushPageFromCacheAsync<MainPageModel>();
        }
    }
}
