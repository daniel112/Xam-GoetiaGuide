using System;
using Xamarin.Forms;
using GoetiaGuide.Core.Common;

namespace GoetiaGuide.Core.Views {
    public class BaseNavigationPage : NavigationPage {
        public BaseNavigationPage() {
        }

        public BaseNavigationPage(Page root) : base(root) {
            BarBackgroundColor = Color.FromHex(AppTheme.DefaultBarBackgroundColor());
            BarTextColor = Color.FromHex(AppTheme.DefaultTextColor());
        }
    }
}
