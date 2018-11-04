using System;
using System.ComponentModel;
using Xamarin.Forms;
using GoetiaGuide.Core.Common;

namespace GoetiaGuide.Core.Views.Base {

    public abstract class BaseContentPage<TVieModel> : ContentPage where TVieModel : INotifyPropertyChanged, new() {
        
        #region Variables
        protected TVieModel ViewModel = new TVieModel();
        #endregion

        #region Abstract
        protected abstract void OnOrientationUpdate(DeviceOrientatione orientation);
        #endregion

        #region Initialization
        protected BaseContentPage() {
            this.BackgroundColor = Color.FromHex(AppTheme.DefaultBarBackgroundColor());
            BindingContext = ViewModel;
        }


        /// <summary>
        /// Retreive new width/height and updates DeviceOrientatione value 
        /// </summary>
        /// <param name="width">Width.</param>
        /// <param name="height">Height.</param>
        protected override void OnSizeAllocated(double width, double height) {
            base.OnSizeAllocated(width, height);

            var currentOrientation = DependencyService.Get<IDeviceOrientation>().GetOrientation();
            if (App.DeviceOrientation == DeviceOrientatione.Undefined || App.DeviceOrientation != currentOrientation) {
                App.DeviceOrientation = currentOrientation;
            }
            if ((int)App.DisplayScreenWidth != (int)width && (int)App.DisplayScreenHeight != (int)height) {
                App.DisplayScreenWidth = width;
                App.DisplayScreenHeight = height;
                OnOrientationUpdate(App.DeviceOrientation);
            }


        }


        #endregion


    }
}
