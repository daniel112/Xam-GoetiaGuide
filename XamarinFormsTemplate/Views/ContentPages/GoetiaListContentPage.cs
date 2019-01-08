using System;
using System.Collections.Generic;
using GoetiaGuide.Core.Common;
using GoetiaGuide.Core.Models;
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
                    _ListView.ItemTapped += ListView_ItemTapped;
                }
                return _ListView;
            }
        }
        #endregion

        #region Initialization
        public GoetiaListContentPage() {
        }

        public GoetiaListContentPage(List<Goetia>goetias) {
            ViewModel.UpdateListViewModel(goetias);
            Setup();
            LoadData();
        }
        protected override void OnOrientationUpdate(DeviceOrientatione orientation) {
        }
        #endregion

        #region Private API
        private void Setup() {
            Title = $"Search Results ({ViewModel.Goetias.Count})";
            Content = ListView;
        }

        private void LoadData() {
            ListView.ItemsSource = ViewModel.Items;
        }


        private void ListView_ItemTapped(object sender, ItemTappedEventArgs e) {

            ImageLabelViewModel item = (ImageLabelViewModel)e.Item;

            GoetiaDetailContentPage destinationCP = new GoetiaDetailContentPage(item.ID);
            this.Navigation.PushAsync(destinationCP);

            // deselect
            ((ListView)sender).SelectedItem = null;


        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}

