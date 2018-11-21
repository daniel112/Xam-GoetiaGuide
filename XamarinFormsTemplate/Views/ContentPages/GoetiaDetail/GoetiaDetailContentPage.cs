using System;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.Components.Templates.DataTemplates;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.Views.ContentPages.GoetiaDetail.Views;
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
        private ListView _ListView;
        private ListView ListView {
            get {
                if (_ListView == null) {
                    _ListView = new ListView {
                        //RowHeight = 60,
                        BackgroundColor = Color.Transparent,
                        SeparatorVisibility = SeparatorVisibility.None,
                        HasUnevenRows = true,
                        ItemTemplate = new GoetiaDetailDataTemplateSelector {
                            GoetiaDetailHeaderTemplate = new DataTemplate(typeof(GoetiaDetailHeaderViewCell)),
                            GoetiaDetailInformationTemplate = new DataTemplate(typeof(GoetiaDetailInformationViewCell))
                        }
                    };
                    //_ListView.ItemTapped += ListView_ItemTapped;
                }
                return _ListView;
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

            // contentStack
            ContentStackLayout.Children.Add(Image);
            ContentStackLayout.Children.Add(ListView);

            // scrollview
            this.ScrollViewContent.Content = this.ContentStackLayout;
            AbsoluteLayout.SetLayoutFlags(this.ScrollViewContent, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this.ScrollViewContent, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(this.ScrollViewContent);

            AbsoluteLayout.SetLayoutFlags(CustomActivityIndicator, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(CustomActivityIndicator, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(CustomActivityIndicator);

            this.Content = layout;
        }

        private void LoadGoetiaDetail() {

            this.CustomActivityIndicator.IsRunning = true;
            this.ViewModel.GetItemDetails();

            // ListView Logic

            ListView.ItemsSource = ViewModel.ListViewModels;

            if (CustomActivityIndicator.IsRunning) { CustomActivityIndicator.IsRunning = false; }
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}

