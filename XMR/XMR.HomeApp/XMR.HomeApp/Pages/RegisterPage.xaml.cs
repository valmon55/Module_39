using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace XMR.HomeApp.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class RegisterPage : ContentPage
    {
        public RegisterPage()
        {
            InitializeComponent();
            PlatformAdjust();
        }
        private void register_click(object sender, EventArgs e)
        {

        }
        public void PlatformAdjust()
        {
            if(Device.RuntimePlatform == Device.UWP)
            {
                placeHolder.PlaceholderColor = Color.SlateGray;
                loginButton.TextColor = Color.AliceBlue;
                loginButton.Margin = new Thickness(0, 5);
            }
        }
    }
}