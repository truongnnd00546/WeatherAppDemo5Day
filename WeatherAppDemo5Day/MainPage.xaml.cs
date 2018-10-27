using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using static WeatherAppDemo5Day.APIManager;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace WeatherAppDemo5Day
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            collection = new ObservableCollection<List>();
            this.DataContext = this;
        }
        public ObservableCollection<List> collection { get; set; }


        private async void Button_Click(object sender, RoutedEventArgs e)
        {

            var postion = await LocationData.getPosition();
            var lat = postion.Coordinate.Latitude;
            var lon = postion.Coordinate.Longitude;

            RootObject forecast = await APIManager.GetWearther(lat, lon);
            for (int i = 0; i < 5; i++)
            {
                collection.Add(forecast.list[i]);

            }
            ForeCast.ItemsSource = collection;


        }
    }
}