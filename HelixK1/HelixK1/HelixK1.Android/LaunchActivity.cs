using Android.App;
using Android.OS;

namespace HelixK1.Droid
{
    [Activity(Label = "HELIX ALPHA", Theme = "@style/Theme.Splash", //Indicates the theme to use for this activity
             MainLauncher = true, //Set it as boot activity
             NoHistory = true)]
    public class LaunchActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            //System.Threading.Thread.Sleep(50); //Let's wait awhile...
            this.StartActivity(typeof(MainActivity));
            // Create your application here
        }
    }
}