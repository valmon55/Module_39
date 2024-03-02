using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace XMR.HomeApp
{
    public class SpanPage : ContentPage
    {
        public SpanPage()
        {
            // Инициализация объекта
            Label label = new Label()
            {
                FontSize = 16,
                Padding = new Thickness(30, 24, 30, 0),
                FormattedText = new FormattedString()
                {
                    Spans =
               {
                   new Span() { Text = "Learn more at " },
                   new Span() { Text = "https://aka.ms/xamarin-quickstart", FontAttributes = FontAttributes.Bold }
               }
                }
            };

            // Добавление на страницу
            this.Content = label;
        }
    }
}
