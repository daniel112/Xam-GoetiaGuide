using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace GoetiaGuide.Core.ViewModels.Base {
    public class BaseViewModel : INotifyPropertyChanged {
        #region Variables
        private Dictionary<string, object> properties = new Dictionary<string, object>();

        #endregion
        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }


}
