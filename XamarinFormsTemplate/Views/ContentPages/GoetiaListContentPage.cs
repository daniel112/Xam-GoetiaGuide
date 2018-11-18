using System;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.ViewModels;
using GoetiaGuide.Core.Views.Base;
using GoetiaGuide.Core.Views.ViewCells;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ContentPages {
    public class GoetiaListContentPage : BaseContentPage<GoetiaListViewModel> {

        #region Variables
        private ListView _ListView;
        private ListView ListView {
            get {
                if (_ListView == null) {
                    _ListView = new ListView {
                        RowHeight = 60,
                        BackgroundColor = Color.Transparent,
                        SeparatorVisibility = SeparatorVisibility.None,
                        ItemTemplate = new DataTemplate(typeof(ImageLabelViewCell))
                    };
                    _ListView.ItemSelected += ListView_ItemSelected;
                }
                return _ListView;
            }
        }
        #endregion

        #region Initialization
        public GoetiaListContentPage() {
            Setup();
            LoadData();
        }
        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }
        #endregion

        #region Private API
        private void Setup() {
            Title = "Search Results (72)";
            Content = ListView;
        }

        private void LoadData() {
            ViewModel.Items.Add(new ImageLabelViewModel("Item 1", "test"));
            ViewModel.Items.Add(new ImageLabelViewModel("Item 2", "test"));
            ViewModel.Items.Add(new ImageLabelViewModel("Item 3", "test"));

            ListView.ItemsSource = ViewModel.Items;
        }

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
        void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e) {

            ListView.SelectedItem = null;
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}

