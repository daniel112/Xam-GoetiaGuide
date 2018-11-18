using System;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.Network;
using GoetiaGuide.Core.ViewModels.Base;

namespace GoetiaGuide.Core.ViewModels {
    public class GoetiaDetailViewModel :BaseViewModel {
        #region Variables
        public int ID { get; set; }
        public Goetia Goetia { get; set; }
        private readonly GoetiaAPIManager APIManager = new GoetiaAPIManager();
        #endregion

        #region Initialization

        #endregion

        #region Private API

        #endregion

        #region Public API
        public void GetItemDetails() {

            // TODO: Just testing get
            Goetia = APIManager.GetByName("Belial");

        }

        #endregion

        #region Delegates

        #endregion
    }
}
