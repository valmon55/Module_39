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
    public partial class WebPage : ContentPage
    {
        public WebPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Обработчик навигации
        /// </summary>
        void NavigateToPage(object sender, EventArgs e)
        {
            // переход по ссылке с автодополнением при необходимости 
            webView.Source = new UrlWebViewSource { Url = urlEntry.Text.Contains("http") ? urlEntry.Text : $"https://{urlEntry.Text}" };
        }
    }
}