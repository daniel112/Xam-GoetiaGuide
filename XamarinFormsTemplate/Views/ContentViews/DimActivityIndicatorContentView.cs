using System;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ContentViews {
    public class DimActivityIndicatorContentView : ContentView {

        #region Variables
        public bool IsRunning {
            get {
                return ActivityIndicator.IsRunning;
            }
            set {
                ActivityIndicator.IsRunning = value;
                this.IsVisible = value;
            }
        }

        private ActivityIndicator _ActivityIndicator;
        private ActivityIndicator ActivityIndicator {
            get {
                if (_ActivityIndicator == null) {
                    _ActivityIndicator = new ActivityIndicator {
                        IsRunning = false,
                        IsVisible = true,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                        Color = Color.White,
                        Scale = 1.5

                    };
                }
                return _ActivityIndicator;
            }
        }

        #endregion

        #region Initialization
        public DimActivityIndicatorContentView() {
            this.Setup();
        }
        #endregion

        #region Private API
        private void Setup() {
            VerticalOptions = LayoutOptions.FillAndExpand;
            HorizontalOptions = LayoutOptions.FillAndExpand;
            this.IsVisible = false;
            this.BackgroundColor = Color.Black.MultiplyAlpha(0.4);
            this.Content = this.ActivityIndicator;
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
