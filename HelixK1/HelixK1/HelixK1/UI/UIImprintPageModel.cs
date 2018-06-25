using System;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;
using Xamvvm;

namespace HelixK1
{
    [DisableCache]
    public class UIImprintPageModel : BasePageModel
    {

        public string Title
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public string ImprintText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public string DisclaimerText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public string InlineStyleText
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public string Html
        {
            get { return GetField<string>(); }
            set { SetField(value); }
        }

        public HtmlWebViewSource WebViewSource
        {
            get
            {
                return new HtmlWebViewSource { Html = Html };
            }
        }

        public UIImprintPageModel()
        {
            UIBackButtonCommand = BaseCommand.FromTask<string>((param) => UIBackCommandExecute(param));
            Title = "Imprint Title";

            DisclaimerText = @"<h1>Disclaimer</h1>

<p>Please note, that this is a simulation involving real functions,
but not offering any service other than demonstrating functionalities to you.
We therefore do not offer or guarantee any possibility of re-using any or all
of the entered data (or simulated entry of data) for later usage(s).</p>
<p>This demonstration version is only meant to demonstrate the functionality of our core idea
and does not check for the plausibility of entries. It is not a functioning service platform.</p>

<h1>Imprint</h1>

<p>Blockchain HELIX AG<br/>
Münchener Strasse 45<br/>
60329 Frankfurt am Main<br/>
Germany</p>

<p>Telefon: +49&#8211;69&#8211;7158994&#8211;0<br/>
Telefax: +49&#8211;69&#8211;7158994–55<br/>
E-Mail: info@blockchain-helix.com</p>

<p>Trade register<br/>
REGISTERGERICHT Frankfurt am Main<br/>
HRB 55757</p>

<p>Authorized representative<br/>
Oliver Naegele | Vorstand<br/>
UMSATZSTEUER-IDENTIFIKATIONSNUMMER GEMÄSS §27A<br/>
Umsatzsteuergesetz: DE229794566</p>

<p>Responsible according to German law (“§ 55 Abs. 2 Rundfunkstaatsvertrag”)<br/>
Board: Reimund Noack (Chairman), Dr. Walter Naegele, Martin Url</p>

<p>Chief Executive Officer: Oliver Naegele</p>

<p>With this demonstration Blockchain HELIX AG does not offer any service other than a demonstration object.</p>
<p>©Blockchain HELIX AG, 2016&#8211;2017</p>";

            ImprintText = @""; //Disclaimer and Imprint both in DisclaimerText

            InlineStyleText = @"style=""font-family: Arial, Helvetica, sans-serif """;
 
            Html = $"<div {InlineStyleText}>{DisclaimerText}</div>"; 
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
    }
}
