using System;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ContentViews {
    public class HorizontalLabelDetailContentView : ContentView {

        #region Variables
        public Color LabelColor {
            get {
                return LabelTitle.TextColor;
            }
            set {
                LabelTitle.TextColor = value;
                LabelDetail.TextColor = value;
            }
        }

        private Label _LabelTitle;
        private Label LabelTitle {
            get {
                if (_LabelTitle == null) {
                    _LabelTitle = new Label {
                        FontSize = 18,
                        TextColor = Color.White,
                        FontAttributes = FontAttributes.Bold,
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };
                }

                return _LabelTitle;
            }
        }
        private Label _LabelDetail;
        private Label LabelDetail {
            get {
                if (_LabelDetail == null) {
                    _LabelDetail = new Label {
                        FontSize = 18,
                        TextColor = Color.White,
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                    };
                }

                return _LabelDetail;
            }
        }
        private StackLayout _ContentStackLayout;
        private StackLayout ContentStackLayout {
            get {
                if (_ContentStackLayout == null) {
                    _ContentStackLayout = new StackLayout {
                        Orientation = StackOrientation.Horizontal
                    };
                }
                return _ContentStackLayout;
            }
        }

        #endregion

        #region Initialization
        public HorizontalLabelDetailContentView() {
        }
        public HorizontalLabelDetailContentView(string title, string detail) {
            this.LabelTitle.Text = title;
            this.LabelDetail.Text = detail;
            this.Setup();
        }
        #endregion

        #region Private API
        private void Setup() {
        

            // horizontal stack
            this.ContentStackLayout.Children.Add(this.LabelTitle);
            this.ContentStackLayout.Children.Add(this.LabelDetail);


            this.Content = this.ContentStackLayout;

        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
