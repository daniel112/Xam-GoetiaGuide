using System;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.Views.ContentViews;
using Rg.Plugins.Popup.Extensions;
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
                        Orientation = StackOrientation.Vertical,
                        Padding = new Thickness(0, 0, 0, 10)
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
                        Source = "https://media.sandhills.com/img.axd?id=4069760217&wid=auctiontime&rwl=False&p=&ext=&w=639&h=480&t=&lp=MAT&c=True&wt=False&sz=Max&rt=0&checksum=G57lKREwooRb1XpA9q9GkSea1D0RnA9ph3k5g5tmg7qgf%2fVZcnmmpEIXsy4b1yi%2fUX3eIHcifFxhdwjZaPJzzFnf%2bGQB1LqU8liGkR0w0Z6kqrXDETjieTMfE05C2ERzsOf0wAjF9uNdJ7I49e1k3A%2bD7%2fd1UmRu",
                        Margin = new Thickness(0, 30, 0, 30),
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.CenterAndExpand,
                    };
                }
                return _Image;
            }
        }
      

        private StackLayout StackLayoutHeader = new StackLayout {
            BackgroundColor = Color.BlueViolet
        };
        private Label _LabelHeader;
        private Label LabelHeader {
            get {
                if (_LabelHeader == null) {
                    _LabelHeader = new Label {
                        FontSize = 22,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.White,
                        Margin = new Thickness(10, 0, 0, 10)
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
                        Text = "Click for full description",
                        FontSize = 16,
                        TextColor = Color.DarkBlue,
                        MaxLines = 4,
                        Margin = new Thickness(10, 0, 0, 20)
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
            this.Setup();
            ViewModel.ID = id;
        }
        protected override void OnAppearing() {
            base.OnAppearing();
            this.LoadGoetiaDetail();
        }

        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }
        #endregion

        #region Private API
        private void Setup() {

            this.Title = "Details";
            AbsoluteLayout layout = new AbsoluteLayout();

            // header
            StackLayoutHeader.Children.Add(LabelHeader);

            // contentStack
            ContentStackLayout.Children.Add(Image);
            ContentStackLayout.Children.Add(StackLayoutHeader);

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
            var popupPage = new LabelButtonPopupPage("Full Description", ViewModel.GoetiaItem.Description, "Close");
            //popupPage.PageDelegate = this;
            Navigation.PushPopupAsync(popupPage);
        }
        private void LoadGoetiaDetail() {

            this.ViewModel.GetItemDetails();
            // TODO: update the getItemDetails method to return bool
            if (ViewModel.GoetiaItem != null) {
                // Header
                StackLayoutHeader.Children.Add(LabelDescription);
                LabelHeader.Text = ViewModel.GoetiaItem.Name;
                LabelDescription.Text = ViewModel.GoetiaItem.Description;
                StackLayoutHeader.Children.Add(LabelFullDescription);

                // update contentStackLayout
                foreach (GoetiaDetailInformationViewModel informationVM in ViewModel.ListViewModels) {
                    ContentStackLayout.Children.Add(new HorizontalLabelDetailContentView(informationVM.Title, informationVM.Info));
                }
            }
            CustomActivityIndicator.IsRunning = false;

        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}

