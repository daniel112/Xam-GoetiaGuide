using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GoetiaGuide.Core.Models;
using GoetiaGuide.Core.Network;
using GoetiaGuide.Core.ViewModels.Base;

namespace GoetiaGuide.Core.ViewModels {
    public class MainViewModel : BaseViewModel {

        #region Variables
        public string SearchText = "";
        private readonly GoetiaAPIManager APIManager = new GoetiaAPIManager();

        #endregion

        #region Initialization
        public MainViewModel() {
        }
        #endregion


        #region Private API


        #endregion


        #region Public API
        public async Task<List<Goetia>> SearchWithText(string text) {
            //return await APIManager.PerformSearchQuery2(text);

            return await APIManager.PerformSearchQuery(text);

         }

        #endregion

        #region Delegates

        #endregion
    }
}
