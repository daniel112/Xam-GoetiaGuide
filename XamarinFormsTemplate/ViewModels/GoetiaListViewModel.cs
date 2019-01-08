using System;
using System.Collections.Generic;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.ViewModels.Base;
using GoetiaGuide.Core.Views.ViewCells;

namespace GoetiaGuide.Core.ViewModels {
    public class GoetiaListViewModel : BaseViewModel {
        #region Variables
        public List<ImageLabelViewModel> Items = new List<ImageLabelViewModel>();
        private List<Goetia> _Goetias;
        public List<Goetia> Goetias {
            get {
                if (_Goetias == null) {
                    _Goetias = new List<Goetia>();
                }
                return _Goetias;
            }
            set {
                _Goetias = value;
            }
        }

        #endregion

        #region Initialization

        #endregion

        #region Private API
        public void UpdateListViewModel(List<Goetia>goetias) {
            this.Goetias = goetias;
            foreach (var goetia in goetias) {
                Items.Add(new ImageLabelViewModel(goetia.Name, goetia.ImageURL, goetia.ID));
            }
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
