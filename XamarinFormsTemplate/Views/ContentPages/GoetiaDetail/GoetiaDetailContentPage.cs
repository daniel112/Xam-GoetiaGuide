using System;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.Components;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.Views.ContentViews;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ContentPages {
    public class GoetiaDetailContentPage : BaseContentPage<GoetiaDetailViewModel>, ILabelButtonPopupPage {

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
                        Orientation = StackOrientation.Vertical,
                        Margin = new Thickness(0, 0, 0, 10),
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Spacing = 0
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
                        HeightRequest = 300,
                        Margin = new Thickness(0, 30, 0, 30),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                    };
                }
                return _Image;
            }
        }


        private readonly StackLayout StackLayoutHeader = new StackLayout {
            BackgroundColor = Color.FromHex(AppTheme.SecondaryColor())
        };
        private Label _LabelHeader;
        private Label LabelHeader {
            get {
                if (_LabelHeader == null) {
                    _LabelHeader = new Label {
                        FontSize = 22,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.White,
                        Margin = new Thickness(10, 10, 0, 10)
                    };
                }
                return _LabelHeader;
            }
        }

        private Label _LabelDescription;
        private Label LabelDescription {
            get {
                if (_LabelDescription == null) {
                    _LabelDescription = new Label {
                        FontSize = 16,
                        TextColor = Color.White,
                        LineBreakMode = LineBreakMode.TailTruncation,
                        MaxLines = 4,
                        Margin = new Thickness(10, 0, 0, 10)
                    };
                }
                return _LabelDescription;
            }
        }
        private Label _LabelFullDescription;
        private Label LabelFullDescription {
            get {
                if (_LabelFullDescription == null) {
                    _LabelFullDescription = new Label {
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Text = "Click for full description",
                        FontSize = 16,
                        TextColor = Color.FromHex("#215bb7"),
                        MaxLines = 4,
                        Margin = new Thickness(10, 0, 0, 10)
                    };
                    var gestureRecognizer = new TapGestureRecognizer();
                    gestureRecognizer.Tapped += LabelFullDescription_Tapped;
                    _LabelFullDescription.GestureRecognizers.Add(gestureRecognizer);

                }
                return _LabelFullDescription;
            }
        }

        private readonly DimActivityIndicatorContentView CustomActivityIndicator = new DimActivityIndicatorContentView();

        #endregion

        #region Initialization
        public GoetiaDetailContentPage(int id) {
            // messaging center
            MessagingCenter.Instance.Subscribe<GoetiaDetailViewModel>(this, MessagingCenterKeys.RetreivedDetailItem, (sender) => {
                Device.BeginInvokeOnMainThread(UpdateViewAsync);
            });
            this.Setup();
            ViewModel.ID = id;
        }

        protected override void OnAppearing() {
            base.OnAppearing();

        }

        protected override void OnDisappearing() {
            base.OnDisappearing();
            MessagingCenter.Instance.Unsubscribe<GoetiaDetailViewModel>(this, MessagingCenterKeys.RetreivedDetailItem);

        }
        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }
        #endregion

        #region Private API
        private void Setup() {

            this.Title = "Details";
            AbsoluteLayout layout = new AbsoluteLayout();

            // scrollview
            this.ScrollViewContent.Content = this.ContentStackLayout;
            AbsoluteLayout.SetLayoutFlags(this.ScrollViewContent, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this.ScrollViewContent, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(this.ScrollViewContent);

            AbsoluteLayout.SetLayoutFlags(CustomActivityIndicator, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(CustomActivityIndicator, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(CustomActivityIndicator);
            this.CustomActivityIndicator.IsRunning = true;

            this.Content = layout;
        }

        private void LabelFullDescription_Tapped(object sender, EventArgs args) {
            var popupPage = new LabelButtonPopupPage("Description", ViewModel.GoetiaItem.Description, "Close", null);
            Navigation.PushPopupAsync(popupPage);
        }
        private async void UpdateViewAsync() {
        
            if (ViewModel.GoetiaItem != null && ViewModel.GoetiaItem.Success) {

                // Image
                this.Image.Source = ViewModel.GoetiaItem.ImageURL;

                // header
                StackLayoutHeader.Children.Add(LabelHeader);
                StackLayoutHeader.Children.Add(LabelDescription);
                LabelHeader.Text = ViewModel.GoetiaItem.Name;
                LabelDescription.Text = ViewModel.GoetiaItem.Description;
                StackLayoutHeader.Children.Add(LabelFullDescription);

                // contentStack
                var headerViewSeparatorBottom = new BoxView { BackgroundColor = Color.FromHex(AppTheme.SeparatorColor()).MultiplyAlpha(0.5f), HeightRequest = 10, };
                ContentStackLayout.Children.Add(Image);
                ContentStackLayout.Children.Add(StackLayoutHeader);
                ContentStackLayout.Children.Add(headerViewSeparatorBottom);

                // info stackLayout
                var stackLayoutInfo = new StackLayout {
                    BackgroundColor = Color.FromHex("#400000"),
                    Spacing = 0,
                    VerticalOptions = LayoutOptions.FillAndExpand
                };
                foreach (GoetiaDetailInformationViewModel informationVM in ViewModel.ListViewModels) {
                    stackLayoutInfo.Children.Add(new HorizontalLabelDetailContentView(informationVM.Title, informationVM.Info));
                }
                ContentStackLayout.Children.Add(stackLayoutInfo);

            } else {
                // network error
                var popupPage = new LabelButtonPopupPage("Error", "Something went wrong, please try again later.", "Close", 100) {
                    PageDelegate = this
                };
                await Navigation.PushPopupAsync(popupPage);
            }
            CustomActivityIndicator.IsRunning = false;

        }


        #endregion

        #region Public API

        #endregion

        #region Delegates
        void ILabelButtonPopupPage.DidTapButton(string messageTitle) {
            if (messageTitle.ToLower() == "error") {
                Navigation.PopAsync();
            }
        }
        #endregion

    }
}

