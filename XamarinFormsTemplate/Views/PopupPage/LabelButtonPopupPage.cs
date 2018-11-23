using System;
using System.Threading.Tasks;
using Rg.Plugins.Popup.Extensions;
using Rg.Plugins.Popup.Pages;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views {

    public interface ILabelButtonPopupPage {
        void DidTapButton();
    }

    public class LabelButtonPopupPage : PopupPage {

        #region Variables
        public ILabelButtonPopupPage PageDelegate;
        private StackLayout _FlexLayoutWrapper;
        private StackLayout FlexLayoutWrapper {
            get {
                if (_FlexLayoutWrapper == null) {
                    _FlexLayoutWrapper = new StackLayout {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        BackgroundColor = Color.Black,
                        WidthRequest = 300
                    };
                }
                return _FlexLayoutWrapper;
            }
        }

        private Label _LabelTitle;
        private Label LabelTitle {
            get {
                if (_LabelTitle == null) {
                    _LabelTitle = new Label() {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        Text = "Title Here",
                        FontSize = 20,
                        FontAttributes = FontAttributes.Bold,
                        HeightRequest = 40,
                        BackgroundColor = Color.Black,
                        TextColor = Color.White
                    };
                }
                return _LabelTitle;
            }
        }

        private Label _LabelMessage;
        private Label LabelMessage {
            get {
                if (_LabelMessage == null) {
                    _LabelMessage = new Label() {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalTextAlignment = TextAlignment.Center,
                        LineBreakMode = LineBreakMode.WordWrap,
                        Text = "Message placeholder",
                        FontSize = 15,
                        HeightRequest = 150,
                        TextColor = Color.White,
                        BackgroundColor = Color.Transparent,
                        Margin = new Thickness(10)
                    };
                }
                return _LabelMessage;
            }
        }

        private Button _ButtonAction;
        private Button ButtonAction {
            get {
                if (_ButtonAction == null) {
                    _ButtonAction = new Button {
                        Text = "Action Button",
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        BackgroundColor = Color.Black,
                        TextColor = Color.White,
                        FontAttributes = FontAttributes.Bold,
                        FontSize = 18,
                        CornerRadius = 0,
                        HeightRequest = 40
                    };
                    _ButtonAction.Clicked += ButtonAction_Clicked;
                }
                return _ButtonAction;
            }
        }

        #endregion

        #region Initialization
        public LabelButtonPopupPage() {
            SetupContent();
        }

        public LabelButtonPopupPage(string title, string message, string buttonText) {
            LabelTitle.Text = title;
            LabelMessage.Text = message;
            ButtonAction.Text = buttonText;
            SetupContent();
        }

        protected override void OnAppearing() {
            base.OnAppearing();
        }

        protected override void OnAppearingAnimationBegin() {
            base.OnAppearingAnimationBegin();
        }

        protected override Task OnAppearingAnimationEndAsync() {
            return base.OnAppearingAnimationEndAsync();
        }

        protected override Task OnDisappearingAnimationBeginAsync() {
            return base.OnDisappearingAnimationBeginAsync();
        }

        protected override bool OnBackButtonPressed() {
            Navigation.RemovePopupPageAsync(this);
            return base.OnBackButtonPressed();
            // android back button

        }
        protected override bool OnBackgroundClicked() {
            // return false if you don't want popup to close when background is clicked
            return false;
        }
        #endregion


        #region Private API
        private void SetupContent() {

            FlexLayoutWrapper.Children.Add(LabelTitle);
            FlexLayoutWrapper.Children.Add(LabelMessage);
            FlexLayoutWrapper.Children.Add(ButtonAction);

            this.Content = FlexLayoutWrapper;

        }

        private async void ClosePopupAsync() {
            await Navigation.RemovePopupPageAsync(this);
        }
        // UIResponder
        private void ButtonAction_Clicked(object sender, EventArgs e) {
            ClosePopupAsync();
            //PageDelegate.DidTapButton();
        }

        #endregion


        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
