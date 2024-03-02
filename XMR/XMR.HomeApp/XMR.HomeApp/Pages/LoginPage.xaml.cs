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
    public partial class LoginPage : ContentPage
    {
        public const string BUTTON_TEXT = "Войти";
        public static int loginCounter = 0;
        // Создаем объект, возвращающий свойства устройства
        IDeviceDetector detector = DependencyService.Get<IDeviceDetector>();
        public LoginPage()
        {
            InitializeComponent();
            //if(Device.RuntimePlatform == Device.UWP)
            //{
            //    loginButton.CornerRadius = 0;
            //}
            if(Device.Idiom == TargetIdiom.Desktop)
            {
                loginButton.CornerRadius = 0;
            }
            // Передаем информацию о платформе на экран
            runningDevice.Text = detector.GetDevice();
        }
        /// <summary>
        /// По клику обрабатываем счётчик и выводим разные сообщения
        /// </summary>
        private void login_Click(object sender, EventArgs e)
        {
            if (loginCounter == 0)
            {
                // Если первая попытка - просто меняем сообщения
                loginButton.Text = $"Выполняется вход..";
            }
            else if (loginCounter > 5) // Слишком много попыток - показываем ошибку
            {
                // Деактивируем кнопку
                loginButton.IsEnabled = false;
                // Показываем текстовое сообщение об ошибке
                //var infoMessage = (Label)stackLayout.Children.Last();
                infoMessage.Text = "Слишком много попыток! Попробуйте позже.";
                // Используем добавленный глобальный ресурс
                infoMessage.TextColor = (Color)Application.Current.Resources["errorColor"];

                //// Новый цвет для информационных сообщений
                //var warningColor = Color.FromHex("#ffa500");
                //// Добавлем в словарь.
                //Resources.Add("warningColor", warningColor);

                //// Используем добавленный ресурс
                //infoMessage.TextColor = (Color)Resources["warningColor"];
            }
            else
            {
                // Изменяем текст кнопки и показываем количество попыток входа
                loginButton.Text = $"Выполняется вход...   Попыток входа: {loginCounter}";
            }

            // Увеличиваем счетчик
            loginCounter += 1;
        }
    }
}