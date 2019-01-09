using System;
using Xamarin.Forms;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Network;
using GoetiaGuide.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;
using GoetiaGuide.Core.Views.ContentViews;
using FFImageLoading.Forms;
using FFImageLoading.Work;
using FFImageLoading.Transformations;
using GoetiaGuide.Core.Components;
using System.Linq;

namespace GoetiaGuide.Core.Views.ContentPages {
    public class MainContentPage : BaseContentPage<MainViewModel>, IInputTextDelegate {
        #region Variables

        private readonly GoetiaAPIManager GoetiaAPIManager = new GoetiaAPIManager();
        private readonly UserAPIManager UserAPIManager = new UserAPIManager();

        private Button _ButtonSearch;
        private Button ButtonSearch {
            get {
                if (_ButtonSearch == null) {
                    _ButtonSearch = new Button {
                        Text = "Search",
                        FontSize = 16,
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex(AppTheme.PrimaryButtonColor()),
                        CornerRadius = 8,
                        HeightRequest = 40,
                        Margin = new Thickness(30, 30, 30, 0)

                    };
                    _ButtonSearch.SetDynamicResource(StyleProperty, ApplicationResourcesConstants.CustomFontFamily);
                    _ButtonSearch.Clicked += ButtonSearch_ClickedAsync;


                }
                return _ButtonSearch;
            }
        }

        private Button _ButtonRandom;
        private Button ButtonRandom {
            get {
                if (_ButtonRandom == null) {
                    _ButtonRandom = new Button {
                        Text = "Feeling Lucky?",
                        FontSize = 16,
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex(AppTheme.PrimaryButtonColor()),
                        CornerRadius = 8,
                        HeightRequest = 40,
                        Margin = new Thickness(30, 10, 30, 0)

                    };
                    _ButtonRandom.SetDynamicResource(StyleProperty, ApplicationResourcesConstants.CustomFontFamily);
                    _ButtonRandom.Clicked += ButtonRandom_ClickedAsync;


                }
                return _ButtonRandom;
            }
        }

        private Label _LabelSubLabel;
        private Label LabelSubLabel {
            get {
                if (_LabelSubLabel == null) {
                    _LabelSubLabel = new Label {
                        Text = "Type your specific need or name of the spirit you wish to contact in the search bar below \n The spirits are expecting you...",
                        FontSize = 14,
                        TextColor = Color.White.MultiplyAlpha(0.5f),
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(30, 30, 30, 0)
                    };
                }

                return _LabelSubLabel;
            }
        }

        private ScrollView _ScrollViewContent;
        private ScrollView ScrollViewContent {
            get {
                if (_ScrollViewContent == null) {
                    _ScrollViewContent = new ScrollView {
                        Margin = new Thickness(0, 0, 0, 20)

                    };
                }
                return _ScrollViewContent;
            }
        }

        private InputTextContentView _InputSearch;
        private InputTextContentView InputSearch {
            get {
                if (_InputSearch == null) {
                    _InputSearch = new InputTextContentView("InputTextIdentifierSearch", "", "Enter 1-2 word(s)..", false, "icon_search", this) {
                        Margin = new Thickness(30, 20, 30, 10),
                        //HeightRequest = 70
                    };

                }
                return _InputSearch;
            }
        }

        private Image _Image;
        private Image Image {
            get {
                if (_Image == null) {
                    _Image = new Image {
                        Aspect = Aspect.AspectFit,
                        Opacity = 0.1f,
                        Source = "background_main",
                        VerticalOptions = LayoutOptions.Center,
                        HorizontalOptions = LayoutOptions.Center,
                    };
                }
                return _Image;
            }
        }

        private readonly CachedImage ImagePentagram = new CachedImage() {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            WidthRequest = 100,
            Aspect = Aspect.AspectFit,
            CacheDuration = TimeSpan.FromDays(30),
            DownsampleToViewSize = true,
            RetryCount = 0,
            RetryDelay = 250,
            Opacity = 0.4f,
            Source = "icon_pentagram",
            Transformations = new List<ITransformation>() {
                new TintTransformation("#ffffff") {
                    EnableSolidColor = true
                }
            },
        };

        private StackLayout _StackLayout;
        private StackLayout StackLayout {
            get {
                if (_StackLayout == null) {
                    _StackLayout = new StackLayout {
                        VerticalOptions = LayoutOptions.CenterAndExpand,
                    };
                }
                return _StackLayout;
            }
        }

        private readonly DimActivityIndicatorContentView CustomActivityIndicator = new DimActivityIndicatorContentView();

        #endregion

        #region Initialization
        public MainContentPage() {
            this.Setup();
        }

        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }
        #endregion


        #region Private API
        private void Setup() {
        
            NavigationPage.SetBackButtonTitle(this, "");
            this.Title = "Find A Spirit";

            AbsoluteLayout layout = new AbsoluteLayout();

            // background image
            AbsoluteLayout.SetLayoutFlags(this.Image, AbsoluteLayoutFlags.PositionProportional | AbsoluteLayoutFlags.SizeProportional);
            AbsoluteLayout.SetLayoutBounds(this.Image, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(this.Image);

            // stacklayout
            this.StackLayout.Children.Add(this.ImagePentagram);
            this.StackLayout.Children.Add(LabelSubLabel);
            this.StackLayout.Children.Add(InputSearch);
            this.StackLayout.Children.Add(ButtonSearch);
            this.StackLayout.Children.Add(ButtonRandom);

            // scrollview
            this.ScrollViewContent.Content = this.StackLayout;
            AbsoluteLayout.SetLayoutFlags(this.ScrollViewContent, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(this.ScrollViewContent, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(this.ScrollViewContent);


            // loading indicator
            AbsoluteLayout.SetLayoutFlags(CustomActivityIndicator, AbsoluteLayoutFlags.All);
            AbsoluteLayout.SetLayoutBounds(CustomActivityIndicator, new Rectangle(0, 0, 1, 1));
            layout.Children.Add(CustomActivityIndicator);

            Content = layout;

        }

        private async void PerformSearch() {
            this.CustomActivityIndicator.IsRunning = true;
            var results = await ViewModel.SearchWithText(ViewModel.SearchText);
            if (results.Count == 1) {
                GoetiaDetailContentPage destinationCP = new GoetiaDetailContentPage(results.FirstOrDefault());
                await this.Navigation.PushAsync(destinationCP);
            } else if (results.Count > 1) {
                await Navigation.PushAsync(new GoetiaListContentPage(results));
            } else {
                await DisplayAlert("Search", "No result. Please try a different keyword search", "OK");
            }
            this.CustomActivityIndicator.IsRunning = false;

        }

        async void ButtonRandom_ClickedAsync(object sender, EventArgs e) {

            int randomNumber = new Random().Next(1, 72);
            GoetiaDetailContentPage destinationCP = new GoetiaDetailContentPage(randomNumber);
            await this.Navigation.PushAsync(destinationCP);

        }

        private void ButtonSearch_ClickedAsync(object sender, EventArgs e) {

            PerformSearch();
        }


        #endregion


        #region Public API

        #endregion

        #region Delegates
        public void Input_TextChanged(string text, InputTextContentView inputText) {
            if (text != " ")
                text = text.Trim(); 

            ViewModel.SearchText = text;
        }

        public void Input_DidPressReturnAsync(string text, InputTextContentView inputText) {
           PerformSearch();
        }
        #endregion
    }
}
