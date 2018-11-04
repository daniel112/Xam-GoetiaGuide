using System;
using GoetiaGuide.Core.Components.CustomRenderers;
using GoetiaGuide.iOS.CustomRenderers;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(EntryBorderless), typeof(EntryBorderlessCustomRenderer))]
namespace GoetiaGuide.iOS.CustomRenderers {
    public class EntryBorderlessCustomRenderer : EntryRenderer {

        public EntryBorderlessCustomRenderer() {

        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e) {
            base.OnElementChanged(e);
            Control.Layer.BorderWidth = 0;
            Control.BorderStyle = UITextBorderStyle.None;
        }

    }
}
