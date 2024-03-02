using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XMR.HomeApp.Droid.Renderes;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRenderer))]
namespace XMR.HomeApp.Droid.Renderes
{
    /// <summary>
    /// Отключаем подчеркивание по умолчанию для элемента Entry не платформе Android
    /// </summary>
    public class CustomEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackgroundColor(Android.Graphics.Color.Transparent);
        }
    }
}