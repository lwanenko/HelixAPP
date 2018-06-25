using System;
using System.Windows.Input;
using Xamvvm;

namespace HelixK1
{
    public class TestPageModel : BasePageModel
    {

        public string Title { get; set; } = "Test Page";
        //public string WelcomeText { get; set; }
        public string WelcomeText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public ICommand BackButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public ICommand ChangeTextButtonCommand
        {
            get { return GetField<ICommand>(); }
            set { SetField(value); }
        }

        public TestPageModel()
        {
            //= "Hello Test from Test Page"

            BackButtonCommand = new BaseCommand(async (arg) =>
            {
                await this.PopPageAsync();
            });

            ChangeTextButtonCommand = new BaseCommand((arg) =>
           {
               WelcomeText = "1" + WelcomeText;
           });
        }
    }
}
