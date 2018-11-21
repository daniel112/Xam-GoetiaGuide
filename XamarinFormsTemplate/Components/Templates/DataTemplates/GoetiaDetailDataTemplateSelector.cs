using System;
using GoetiaGuide.Core.Views.ContentPages.GoetiaDetail.Views;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Components.Templates.DataTemplates {
    public class GoetiaDetailDataTemplateSelector : DataTemplateSelector {
        public DataTemplate GoetiaDetailHeaderTemplate { get; set; }
        public DataTemplate GoetiaDetailInformationTemplate { get; set; }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container) {
            return item is GoetiaDetailHeaderViewModel ? GoetiaDetailHeaderTemplate : GoetiaDetailInformationTemplate;
        }
    }
}
