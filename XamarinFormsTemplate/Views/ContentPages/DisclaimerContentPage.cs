using System;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Views;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.Views.ContentPages;
using Xamarin.Forms;

namespace GoetiaGuide.Views {
    public class DisclaimerContentPage : BaseContentPage<DisclaimerViewModel> {

        #region Variables
        private Button _DismissButton;
        private Button DismissButton {
            get {
                if (_DismissButton == null) {
                    _DismissButton = new Button {
                        Text = "START",
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex("89211b"),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        CornerRadius = 0,
                    };
                    _DismissButton.Clicked += DismissButton_Clicked;
                }
                return _DismissButton;
            }
        }


        private Label _LabelDisclaimer;
        private Label LabelDisclaimer {
            get {
                if (_LabelDisclaimer == null) {
                    var formattedString = new FormattedString();
                    formattedString.Spans.Add(new Span { Text = "Adult Warning: ", ForegroundColor = Color.FromHex("#d65448"), FontAttributes = FontAttributes.Bold, FontSize = 17 });
                    formattedString.Spans.Add(new Span { Text = "Treat spirits with respect. This app is for serious practitioners of Magick only. Please do not attempt to summon" +
                            " these spirits and demand anything. Use your manners! We are not responsible for any damage you do to yourself."});

                    _LabelDisclaimer = new Label {
                        FormattedText = formattedString,                     
                        FontSize = 17,
                        TextColor = Color.White.MultiplyAlpha(0.7f),
                        FontFamily = "Cambria",
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(30, 0, 30 , 0)
                    };
                }

                return _LabelDisclaimer;
            }
        }

        private Image _ImageBackground;
        private Image ImageBackground {
            get {
                if (_ImageBackground == null) {
                    _ImageBackground = new Image {
                        Aspect = Aspect.AspectFit,
                        Opacity = 0.1f,
                        Source = "background_disclaimer",
                    };
                }
                return _ImageBackground;
            }
        }

        private StackLayout _StackDisclaimer;
        private StackLayout StackDisclaimer {
            get {
                if (_StackDisclaimer == null) {
                    _StackDisclaimer = new StackLayout();
                }
                return _StackDisclaimer;
            }
        }
        #endregion

        #region Initialization
        public DisclaimerContentPage() {
            this.Setup();
        }

        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }

        protected override void OnAppearing() {
            base.OnAppearing();

        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
        }

        #endregion

        #region Private API
        private void Setup() {
            this.BackgroundColor = Color.FromHex(AppTheme.DefaultBarBackgroundColor());
            AbsoluteLayout layout = new AbsoluteLayout();

            // background image
            AbsoluteLayout.SetLayoutFlags(this.ImageBackground, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this.ImageBackground, new Rectangle(0, 0.5, 1, 1));
            layout.Children.Add(this.ImageBackground);

            this.StackDisclaimer.Children.Add(this.LabelDisclaimer);
            // center label
            AbsoluteLayout.SetLayoutFlags(this.StackDisclaimer, AbsoluteLayoutFlags.PositionProportional);
            AbsoluteLayout.SetLayoutBounds(this.StackDisclaimer, new Rectangle(0.5, 0.5, AbsoluteLayout.AutoSize, AbsoluteLayout.AutoSize));
            layout.Children.Add(this.StackDisclaimer);


            // align to bottom button
            AbsoluteLayout.SetLayoutFlags(this.DismissButton, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.WidthProportional);
            AbsoluteLayout.SetLayoutBounds(this.DismissButton, new Rectangle(0, 1, 1, 60));
            layout.Children.Add(this.DismissButton);


            // update size based on device
            if (Device.Idiom == TargetIdiom.Tablet) {
                this.LabelDisclaimer.FontSize = 24;
            }

            if (Device.Idiom == TargetIdiom.Phone) {
                this.LabelDisclaimer.FontSize = 17;
            }

            Content = layout;
        }



        // UIResponder
        void DismissButton_Clicked(object sender, EventArgs e) {

            Application.Current.MainPage = new BaseNavigationPage(new MainContentPage());

        }



        #endregion

    }
}
