using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Input;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.Network;
using GoetiaGuide.Core.ViewModels.Base;
using Xamarin.Forms;

namespace GoetiaGuide.Core.ViewModels {
    public class GoetiaDetailInformationViewModel {
        public string Title { get; set; }
        public string Info { get; set; }
        public GoetiaDetailInformationViewModel(string title, string info) {
            Title = title;
            Info = info;
        }
    }
    public class GoetiaDetailViewModel : BaseViewModel {
        #region Variables
        public int ID { get; set; }
        public Goetia GoetiaItem { get; set; }

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

        #endregion

        #region Public API

        public void GetItemDetails() {

            GoetiaItem = APIManager.GetByName("Belial");

            // update the list viewmodel
            Type type = GoetiaItem.GetType();
            BindingFlags flags = BindingFlags.Public | BindingFlags.Instance;
            PropertyInfo[] properties = type.GetProperties(flags);

            foreach (PropertyInfo property in properties) {
                // excluding Keywords, Direction, ImageURL, BaseModel, ID, Name, Description
                if (property.Name != nameof(Goetia.Keywords) && property.Name != nameof(Goetia.Direction) && property.Name != nameof(Goetia.ImageURL) &&
                    property.Name != nameof(Goetia.Success) && property.Name != nameof(Goetia.Message) && property.Name != nameof(Goetia.ID) && property.Name != nameof(Goetia.Name)
                    && property.Name != nameof(Goetia.Description)) {

                    string name = property.Name;
                    object propertyValue = property.GetValue(GoetiaItem, null);
                    if (propertyValue != null) {
                        string info = "";
                        // we're expecting string or list of string
                        if (propertyValue is string) {
                            info = propertyValue as string;
                            ListViewModels.Add(new GoetiaDetailInformationViewModel($"{name} : ", info));

                        } else if (propertyValue is List<string>) {
                            List<string> list = propertyValue as List<string>;
                            if (list.Count > 0) {
                                for(int i = 0; i < list.Count; i++) {
                                    info += list[i];
                                    if (i + 1 < list.Count) info += ", ";
                                }
                                ListViewModels.Add(new GoetiaDetailInformationViewModel($"{name} : ", info));
                            }
                        }
                    }
                }
               

            }
            Console.WriteLine("");
        }

        #endregion

        #region Delegates

        #endregion
    }
}
