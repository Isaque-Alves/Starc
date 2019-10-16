using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Xamarin.Essentials;
using System.Net.Http;

namespace STARC
{
    public partial class App : Application
    {

        public static HttpClient http = new HttpClient();

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new MainPage()) { BarBackgroundColor = Color.Black, BackgroundColor = Color.White};
        }

        protected override void OnStart()
        {
            
        }

        protected override void OnSleep()
        {
            try
            {
                // Use default vibration length
                //Vibration.Vibrate();

                // Or use specified time
                /*var duration = TimeSpan.FromSeconds(10);
                Vibration.Vibrate(duration);*/
            }
            catch (FeatureNotSupportedException ex)
            {
                // Feature not supported on device
            }
            catch (Exception ex)
            {
                // Other error has occurred.
            }
        }

        protected override void OnResume()
        {
            Vibration.Cancel();
        }
    }
}
