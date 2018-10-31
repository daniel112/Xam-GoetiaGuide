using System;
using Xamarin.Forms;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Network;
using GoetiaGuide.Core.Models;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace GoetiaGuide.Core.Views.ContentPages {
    public class MainContentPage : BaseContentPage<MainViewModel> {
        #region Variables

        private readonly GoetiaAPIManager GoetiaAPIManager = new GoetiaAPIManager();
        private readonly UserAPIManager UserAPIManager = new UserAPIManager();

        private Button _ButtonLogin;
        private Button ButtonLogin {
            get {
                if (_ButtonLogin == null) {
                    _ButtonLogin = new Button {
                        Text = "Log In",
                        FontSize = 18,
                        TextColor = Color.White,
                        BackgroundColor = Color.FromHex("618ec6"),
                        CornerRadius = 8,
                        HeightRequest = 50,
                        Margin = new Thickness(30, 30, 30, 0)

                    };
                    _ButtonLogin.Clicked += ButtonLogin_ClickedAsync;


                }
                return _ButtonLogin;
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
            // setup anything view related here
            this.BackgroundColor = Color.Blue;

            Content = new StackLayout {
                Children = {
                    ButtonLogin
                }
            };

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

        #endregion
    }
}
