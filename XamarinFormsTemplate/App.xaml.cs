using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.Views.ContentPages;
using GoetiaGuide.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace GoetiaGuide.Core {
    public partial class App : Application {

        // initial values obtained from device specific startup
        public static double DisplayScreenWidth = 0f;
        public static double DisplayScreenHeight = 0f;
        public static double DisplayScaleFactor = 0f;
        public static DeviceOrientatione DeviceOrientation;
        public App() {
            InitializeComponent();

            MainPage = new DisclaimerContentPage();
        }

        protected override void OnStart() {
            // Handle when your app starts
        }

        protected override void OnSleep() {
            // Handle when your app sleeps
        }

        protected override void OnResume() {
            // Handle when your app resumes
        }
    }
}
