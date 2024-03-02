using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XMR.HomeApp.Pages
{
    class LoadingPage : ContentPage
    {
        public LoadingPage()
        {
            // Объявим новый текстовый элемент
            Label header = new Label() { Text = $"Запуск вашего первого приложения{Environment.NewLine} на Xamarin..." };

            // Здесь можно сразу установить стили и шрифт
            header.Opacity = 0;
            header.HorizontalTextAlignment = TextAlignment.Center;
            header.VerticalTextAlignment = TextAlignment.Center;
            header.FontSize = 21;
            // Можем даже задать анимацию
            header.FadeTo(1, 3000);

            // Инициализация свойства Content новым элементом.
            Content = header;
        }
    }
}
