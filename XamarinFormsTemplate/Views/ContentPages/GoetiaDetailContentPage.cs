using System;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.Views.ContentViews;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ContentPages {
    public class GoetiaDetailContentPage : BaseContentPage<GoetiaDetailViewModel> {

        #region Variables

        private ScrollView _ScrollViewContent;
        private ScrollView ScrollViewContent {
            get {
                if (_ScrollViewContent == null) {
                    _ScrollViewContent = new ScrollView();
                }
                return _ScrollViewContent;
            }
        }
        private StackLayout _ContentStackLayout;
        private StackLayout ContentStackLayout {
            get {
                if (_ContentStackLayout == null) {
                    _ContentStackLayout = new StackLayout {
                        Orientation = StackOrientation.Vertical
                    };
                }
                return _ContentStackLayout;
            }
        }

        private Image _Image;
        private Image Image {
            get {
                if (_Image == null) {
                    _Image = new Image {
                        Aspect = Aspect.AspectFit,
                        WidthRequest = 300,
                        HeightRequest = 300,
                        Source = "test",
                        Margin = new Thickness(0, 30, 0, 30),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                }
                return _Image;
            }
        }
        #endregion

        #region Initialization
        public GoetiaDetailContentPage() {
            this.Setup();
        }
        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }
        #endregion

        #region Private API
        private void Setup() {

            // stackview
            this.ContentStackLayout.Children.Add(this.Image);
            HorizontalLabelDetailContentView test = new HorizontalLabelDetailContentView("Description:", "Detail") {
                Margin = new Thickness(30, 5, 30, 0)
            };
            HorizontalLabelDetailContentView test1 = new HorizontalLabelDetailContentView("Direction:", "Detail2") {
                Margin = new Thickness(30, 5, 30, 0)
            };
            HorizontalLabelDetailContentView test2 = new HorizontalLabelDetailContentView("Tarot:", "Detail3") {
                Margin = new Thickness(30, 5, 30, 0)
            };
            HorizontalLabelDetailContentView test3 = new HorizontalLabelDetailContentView("Title3:", "Detail4") {
                Margin = new Thickness(30, 5, 30, 0)
            };
            HorizontalLabelDetailContentView test4 = new HorizontalLabelDetailContentView("Demonic Enn:", "Ayer avage Shax aken") {
                Margin = new Thickness(30, 5, 30, 0),
                LabelColor = Color.FromHex("#d65448")
            };
            this.ContentStackLayout.Children.Add(test);
            this.ContentStackLayout.Children.Add(test1);
            this.ContentStackLayout.Children.Add(test2);
            this.ContentStackLayout.Children.Add(test3);
            this.ContentStackLayout.Children.Add(test4);


            // scrollview
            this.ScrollViewContent.Content = this.ContentStackLayout;

            this.Content = this.ScrollViewContent;
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}

