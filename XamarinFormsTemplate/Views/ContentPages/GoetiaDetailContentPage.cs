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


            AbsoluteLayout layout = new AbsoluteLayout();


            // stackview
            this.ContentStackLayout.Children.Add(this.Image);


            // scrollview
            this.ScrollViewContent.Content = this.ContentStackLayout;
            AbsoluteLayout.SetLayoutFlags(this.ScrollViewContent, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this.ScrollViewContent, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(this.ScrollViewContent);

            this.Content = layout;
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}

