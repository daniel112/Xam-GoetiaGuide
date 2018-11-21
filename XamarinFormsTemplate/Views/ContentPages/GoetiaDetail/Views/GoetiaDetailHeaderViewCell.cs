using System;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ContentPages.GoetiaDetail.Views {

    public class GoetiaDetailHeaderViewModel {
        public string Title { get; set; }
        public string Description { get; set; }

        public GoetiaDetailHeaderViewModel(string title, string imageName) {
            this.Title = title;
            this.Description = imageName;
        }
    }

    public class GoetiaDetailHeaderViewCell : ViewCell {
        #region Variables
        private Label _LabelText;
        private Label LabelText {
            get {
                if (_LabelText == null) {
                    _LabelText = new Label {
                        FontSize = 22,
                        FontAttributes = FontAttributes.Bold,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 0, 10)
                    };
                    _LabelText.SetBinding(Label.TextProperty, new Binding(nameof(GoetiaDetailHeaderViewModel.Title)));
                }
                return _LabelText;
            }
        }

        private Label _LabelDescription;
        private Label LabelDescription {
            get {
                if (_LabelDescription == null) {
                    _LabelDescription = new Label {
                        FontSize = 16,
                        TextColor = Color.White,
                        Margin = new Thickness(20, 0, 0, 10)
                    };
                    _LabelDescription.SetBinding(Label.TextProperty, new Binding(nameof(GoetiaDetailHeaderViewModel.Description)));
                }
                return _LabelDescription;
            }
        }

        private FlexLayout _FlexLayout;
        private FlexLayout FlexLayout {
            get {
                if (_FlexLayout == null) {
                    _FlexLayout = new FlexLayout {
                        Direction = FlexDirection.Column,
                        //Wrap = FlexWrap.Wrap,
                        JustifyContent = FlexJustify.Start
                    };
                }
                return _FlexLayout;
            }
        }
        #endregion

        #region Initialization
        public GoetiaDetailHeaderViewCell() {
            this.Setup();
        }
        #endregion


        #region Private API
        private void Setup() {

            FlexLayout.Children.Add(LabelText);
            FlexLayout.Children.Add(LabelDescription);

            View = FlexLayout;
            View.BackgroundColor = Color.BlueViolet;

        }

        #endregion


        #region Public API

        #endregion

        #region Delegates

        #endregion
    }
}
