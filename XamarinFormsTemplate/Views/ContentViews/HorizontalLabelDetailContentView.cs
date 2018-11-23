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
                LabelInfo.TextColor = value;
            }
        }

        private Label _LabelTitle;
        private Label LabelTitle {
            get {
                if (_LabelTitle == null) {
                    _LabelTitle = new Label {
                        TextColor = Color.White,
                        FontSize = 16,
                        FontAttributes = FontAttributes.Bold,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        Margin = new Thickness(10, 0, 0, 0)

                    };
                }
                return _LabelTitle;
            }
        }
        private Label _LabelInfo;
        private Label LabelInfo {
            get {
                if (_LabelInfo == null) {
                    _LabelInfo = new Label {
                        TextColor = Color.White,
                        FontSize = 16,
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                        LineBreakMode = LineBreakMode.WordWrap
                        //Margin = new Thickness(10, 0,0,0)
                    };
                }
                return _LabelInfo;
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
            this.LabelInfo.Text = detail;
            this.Setup();
        }
        #endregion

        #region Private API
        private void Setup() {
        

            // horizontal stack
            this.ContentStackLayout.Children.Add(this.LabelTitle);
            this.ContentStackLayout.Children.Add(this.LabelInfo);


            this.Content = this.ContentStackLayout;

        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
