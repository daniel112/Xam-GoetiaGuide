using System;
using UIKit;
using Foundation;
using GoetiaGuide.Core.Common;
using GoetiaGuide.iOS.Common;

[assembly: Xamarin.Forms.Dependency(typeof(DeviceOrientation))]
namespace GoetiaGuide.iOS.Common {
    public class DeviceOrientation : IDeviceOrientation {
        public DeviceOrientation() { }

        public DeviceOrientatione GetOrientation() {
            var currentOrientation = UIApplication.SharedApplication.StatusBarOrientation;
            bool isPortrait = currentOrientation == UIInterfaceOrientation.Portrait || currentOrientation == UIInterfaceOrientation.PortraitUpsideDown;

            return isPortrait ? DeviceOrientatione.Portrait : DeviceOrientatione.Landscape;
        }
    }
}
