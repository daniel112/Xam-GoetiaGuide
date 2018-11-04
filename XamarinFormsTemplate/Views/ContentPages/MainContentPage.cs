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
                        FontSize = 18,
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex("#7f1808"),
                        CornerRadius = 8,
                        HeightRequest = 40,
                        Margin = new Thickness(30, 30, 30, 0)

                    };
                    _ButtonSearch.Clicked += ButtonLogin_ClickedAsync;


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
                        FontSize = 18,
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex("#7f1808"),
                        CornerRadius = 8,
                        HeightRequest = 40,
                        Margin = new Thickness(30, 10, 30, 0)

                    };
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
                        FontFamily = "Cambria",
                        TextColor = Color.White.MultiplyAlpha(0.5f),
                        LineBreakMode = LineBreakMode.WordWrap,
                        HorizontalOptions = LayoutOptions.Center,
                        HorizontalTextAlignment = TextAlignment.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Margin = new Thickness(30, 0, 30, 0)
                    };
                }

                return _LabelSubLabel;
            }
        }

        private ScrollView _ScrollViewContent;
        private ScrollView ScrollViewContent {
            get {
                if (_ScrollViewContent == null) {
                    _ScrollViewContent = new ScrollView();
                }
                return _ScrollViewContent;
            }
        }

        private InputTextContentView _InputSearch;
        private InputTextContentView InputSearch {
            get {
                if (_InputSearch == null) {
                    _InputSearch = new InputTextContentView("InputTextIdentifierSearch", "", "Type something...", false, "input_username", this) {
                        Margin = new Thickness(30, 20, 30, 10),
                        //HeightRequest = 70
                    };

                }
                return _InputSearch;
            }
        }


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
            this.ScrollViewContent.Content = new StackLayout {
                VerticalOptions = LayoutOptions.CenterAndExpand,
                Children = {
                    //this.LabelTitle,
                    this.LabelSubLabel,
                    this.InputSearch,
                    this.ButtonSearch,
                    this.ButtonRandom,

                }
            };
            Content = this.ScrollViewContent;

        }

        async void ButtonRandom_ClickedAsync(object sender, EventArgs e) {

            GoetiaDetailContentPage destinationCP = new GoetiaDetailContentPage();
            destinationCP.Title = "Item Name";
            await this.Navigation.PushAsync(destinationCP);

        }

        async void ButtonLogin_ClickedAsync(object sender, EventArgs e) {
            //this.GoetiaAPIManager.testImage();
            // TODO: SAVE TEST

            // testing GET - success
            //Goetia test = this.GoetiaAPIManager.GetByName("Belial");
            //bool saveSuccess = await this.UserAPIManager.SaveAsync(new User("danielyo1", "password1"));
            //if (saveSuccess) {
            //    Console.WriteLine("success");
            //} else {
            //    Console.WriteLine("fail");

            //}







            Console.WriteLine("DONE");
        }


        #endregion


        #region Public API

        #endregion

        #region Delegates
        public void Input_TextChanged(string text, InputTextContentView inputText) {
        }

        public void Input_DidPressReturn(string text, InputTextContentView inputText) {
        }
        #endregion
    }
}
