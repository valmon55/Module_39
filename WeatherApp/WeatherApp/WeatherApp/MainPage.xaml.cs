using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace WeatherApp
{
    public partial class MainPage : ContentPage
    {
        public const string BUTTON_TEXT = "Узнать погоду";
        public const string BUTTON_ALARM = "Установить будильник";
        public MainPage()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Метод для отображения погоды по клику
        /// </summary>
        private void LoadWeather(object sender, EventArgs e)
        {
            // Создаем новую табличную разметку
            var layout = new Grid();
            // Задаем чёрный фон
            layout.BackgroundColor = Color.Black;

            // Создаем цветной прямоугольник, который будет фоном для текста
            var upperBox = new BoxView { BackgroundColor = Color.Bisque };
            // Генерим заголовок и выравниваем с помощью свойств.
            var upperHeader = new Label() 
            { 
                Text = $"{Environment.NewLine}Inside", 
                HorizontalTextAlignment = TextAlignment.Center, 
                VerticalTextAlignment = TextAlignment.Start, 
                FontSize = 45, 
                TextColor = Color.FromRgb(48, 48, 48) 
            };
            // Генерим непосредственно текст со значениями температуры и тоже выравниваем.
            var upperText = new Label() 
            { 
                Text = $"{Environment.NewLine}+ 26 °C  ", 
                HorizontalTextAlignment = TextAlignment.End, 
                VerticalTextAlignment = TextAlignment.Center, 
                FontSize = 105, 
                TextColor = Color.FromRgb(48, 48, 48) 
            };
            // Добавляем все элементы в одну ячейку табличной разметки Grid.
            // В результате они будут помещены "один поверх другого", и прямоугольник будет фоном для текста
            layout.Children.Add(upperBox, 0, 0);
            layout.Children.Add(upperHeader, 0, 0);
            layout.Children.Add(upperText, 0, 0);

            // Аналогично заполняем средний блок
            var middleBox = new BoxView { BackgroundColor = Color.LightBlue };
            var middleHeader = new Label() 
            { 
                Text = $"{Environment.NewLine} Outside", 
                HorizontalTextAlignment = TextAlignment.Center, 
                VerticalTextAlignment = TextAlignment.Start, 
                FontSize = 45, 
                TextColor = Color.FromRgb(48, 48, 48) 
            };
            var middleText = new Label() 
            { 
                Text = $"{Environment.NewLine}- 15 °C  ", 
                HorizontalTextAlignment = TextAlignment.End, 
                VerticalTextAlignment = TextAlignment.Center, 
                FontSize = 105, 
                TextColor = Color.FromRgb(48, 48, 48) 
            };
            layout.Children.Add(middleBox, 0, 1);
            layout.Children.Add(middleHeader, 0, 1);
            layout.Children.Add(middleText, 0, 1);

            // Аналогично заполняем нижний блок
            var bottomBox = new BoxView { BackgroundColor = Color.DarkCyan };
            var bottomHeader = new Label() 
            { 
                Text = $"{Environment.NewLine} Pressure", 
                HorizontalTextAlignment = TextAlignment.Center, 
                FontSize = 45, 
                TextColor = Color.FromRgb(48, 48, 48) 
            };
            var bottomText = new Label() 
            { 
                Text = $"{Environment.NewLine}760 mm ", 
                HorizontalTextAlignment = TextAlignment.End, 
                VerticalTextAlignment = TextAlignment.Center, 
                FontSize = 100, 
                TextColor = Color.FromRgb(48, 48, 48) 
            };
            layout.Children.Add(bottomBox, 0, 2);
            layout.Children.Add(bottomHeader, 0, 2);
            layout.Children.Add(bottomText, 0, 2);

            // Инициализация свойства Content созданным табличным лейаутом идентична тому,
            // как если бы мы создавали его в XAML и разместили внутри ContentPage.
            this.Content = layout;
        }
        /// <summary>
        /// Отображение настроек будильника
        /// </summary>
        private void AlarmSetup(object sender, EventArgs e)
        {
            var layout = new StackLayout() { Margin = new Thickness(20) };

            // Заголовок
            var header = new Label { Text = "Установить будильник", Margin = new Thickness(0, 20, 0, 0), 
                                     FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            layout.Children.Add(header);

            // Виджет выбора даты с описанием
            var datePickerText = new Label { Text = "Дата запуска", Margin = new Thickness(0, 20, 0, 0) };
            layout.Children.Add(datePickerText);
            var date = new DatePicker()
            {
                HorizontalOptions = LayoutOptions.Center,
                Format = "d.MM.yyyy",
                MinimumDate = DateTime.Now.AddDays(-7),
                MaximumDate = DateTime.Now.AddDays(7),
                Date = DateTime.Now.Date
            };
            layout.Children.Add(date);

            // Виджет выбора времени с описанием
            var timePickerText = new Label { Text = "Время запуска ", Margin = new Thickness(0, 20, 0, 0) };
            layout.Children.Add(timePickerText);
            var time = new TimePicker()
            {
                HorizontalOptions = LayoutOptions.Center,
                Format = "H:mm",
                Time = DateTime.Now.TimeOfDay
            };
            layout.Children.Add(time);

            var soundLevel = new Slider()
            {
                ThumbColor = Color.DodgerBlue,
                MinimumTrackColor = Color.DodgerBlue,
                MaximumTrackColor = Color.Gray,
                Minimum = 0,
                Maximum = 30,
                Value = 5.0
            };
            var soundLevelText = new Label()
            {
                Text = $"Громкость: {soundLevel.Value}",
                HorizontalOptions = LayoutOptions.Center,
                Margin = new Thickness(0, 30, 0, 0)
            };

            layout.Children.Add(soundLevelText);
            layout.Children.Add(soundLevel);
            soundLevel.ValueChanged += (send, t) => SoundLevelHandler(send, t, soundLevelText);

            // Переключатель и заголовок для него
            var switchHeader = new Label { Text = "Повторять каждый день", 
                HorizontalOptions = LayoutOptions.Center, Margin = new Thickness(0, 5, 0, 0) };
            layout.Children.Add(switchHeader);
            var daily = new Switch()
            {
                HorizontalOptions = LayoutOptions.Center,
                IsToggled = false,
                ThumbColor = Color.DodgerBlue,
                OnColor = Color.LightSteelBlue
            };
            layout.Children.Add(daily);

            var save = new Button()
            {
                BackgroundColor = Color.Silver,
                Margin = new Thickness(0, 5, 0, 0),
                Text = "Сохранить",                
            };
            save.Clicked += (send, t) => ShowAlarmType(send, t, date.Date + time.Time);
            layout.Children.Add(save);

            this.Content = layout;
        }

        private void SoundLevelHandler(object sender, ValueChangedEventArgs e, Label label)
        {
            if (e.NewValue == 0)
            {
                label.Text = "Без звука";
                return;
            }
            label.Text = $"Громкость {e.NewValue}";
        }
        private void SwitchHandler(object sender, ToggledEventArgs e, Label label)
        {
            if(e.Value)
            {
                label.Text = "Ежедневно";
                return;
            }
            label.Text = string.Empty;
        }
        private void ShowAlarmType(object sender, EventArgs e, DateTime alarmDate)
        {
            var layout = new StackLayout() { Margin = new Thickness(20), VerticalOptions = LayoutOptions.Center };
            var dateHeader = new Label { Text = $"Будильник сработает:", 
                FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            var dateText = new Label { Text = $"{alarmDate.Day}.{alarmDate.Month} в {alarmDate.Hour}:{alarmDate.Minute}", 
                FontSize = 20, HorizontalTextAlignment = TextAlignment.Center };
            layout.Children.Add(dateHeader);
            layout.Children.Add(dateText);
            this.Content = layout;
        }
    }
}
