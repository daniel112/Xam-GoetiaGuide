using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Windows.Input;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.Network;
using GoetiaGuide.Core.ViewModels.Base;
using GoetiaGuide.Core.Views.ContentPages.GoetiaDetail.Views;
using Xamarin.Forms;

namespace GoetiaGuide.Core.ViewModels {
    public class GoetiaDetailViewModel :BaseViewModel {
        #region Variables
        public int ID { get; set; }
        public Goetia Goetia { get; set; }

        private ObservableCollection<object> _ListViewModels;
        public ObservableCollection<object> ListViewModels {
            get {
                if (_ListViewModels == null) {
                    _ListViewModels = new ObservableCollection<object>();
                }
                return _ListViewModels;
            }
        }

        private readonly GoetiaAPIManager APIManager = new GoetiaAPIManager();

        //public ICommand GetItemCommand { protected set; get; }

        #endregion

        #region Initialization
        public GoetiaDetailViewModel() {
            //GetItemCommand = new Command(GetItem);
        }
        #endregion

        #region Private API
        //private void GetItem() {
        //    Goetia = APIManager.GetByName("Belial");
        //    ListViewModels.Add(new GoetiaDetailHeaderViewModel(Goetia.Name, Goetia.Description));
        //}
        #endregion

        #region Public API

        public void GetItemDetails() {
    
            Goetia = APIManager.GetByName("Belial");

            // update the list viewmodel
            ListViewModels.Add(new GoetiaDetailHeaderViewModel(Goetia.Name, Goetia.Description));
        }

        #endregion

        #region Delegates

        #endregion
    }
}
