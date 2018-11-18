using System;
using GoetiaGuide.Core.Views.ViewCells;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XamarinFormsTemplate.iOS.CustomRenderers;

[assembly: ExportRenderer(typeof(ImageLabelViewCell), typeof(ImageLabelViewCellRenderer))]
namespace XamarinFormsTemplate.iOS.CustomRenderers {

    public class ImageLabelViewCellRenderer : ViewCellRenderer {

        public override UITableViewCell GetCell(Cell item, UITableViewCell reusableCell, UITableView tv) {
            var cell = base.GetCell(item, reusableCell, tv);
            var view = item as ImageLabelViewCell;
            cell.SelectedBackgroundView = new UIView {
                BackgroundColor = view.SelectedBackgroundColor.ToUIColor(),
            };

            return cell;
        }
    }
}
