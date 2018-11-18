using System;
using Xamarin.Forms;

namespace GoetiaGuide.Core.Views.ViewCells {
    public class ImageLabelViewModel {
        public string Text { get; set; }
        public string ImageName { get; set; }
        public int ID { get; set; }

        public ImageLabelViewModel(string text, string imageName, int id) {
            this.Text = text;
            this.ImageName = imageName;
            this.ID = id;
        }
    }

    public class ImageLabelViewCell : ViewCell {
        #region Variables
        public static readonly BindableProperty SelectedBackgroundColorProperty =
        BindableProperty.Create("SelectedBackgroundColor",
                                typeof(Color),
                                typeof(ImageLabelViewCell),
                                Color.Default);

        public Color SelectedBackgroundColor {
            get { return (Color)GetValue(SelectedBackgroundColorProperty); }
            set { SetValue(SelectedBackgroundColorProperty, value); }
        }

        private Label _LabelText;
        private Label LabelText {
            get {
                if (_LabelText == null) {
                    _LabelText = new Label {
                        FontSize = 22,
                        TextColor = Color.White,
                    };
                    _LabelText.SetBinding(Label.TextProperty, new Binding(nameof(ImageLabelViewModel.Text)));
                }
                return _LabelText;
            }
        }

        private Image _ImageLeft;
        private Image ImageLeft {
            get {
                if (_ImageLeft == null) {
                    _ImageLeft = new Image {
                        Aspect = Aspect.AspectFit,
                        WidthRequest = 24,
                        HeightRequest = 24,
                        Margin = new Thickness(10, 0, 10, 0)
                    };
                    _ImageLeft.SetBinding(Image.SourceProperty, new Binding(nameof(ImageLabelViewModel.ImageName)));
                }
                return _ImageLeft;
            }
        }
        private BoxView _Separator;
        private BoxView Separator {
            get {
                if (_Separator == null) {
                    _Separator = new BoxView {
                        Color = Color.White.MultiplyAlpha(0.3),
                        HeightRequest = 1,
                    };
                }
                return _Separator;
            }
        }

        private readonly Image ImageArrow = new Image {
            Source = "arrow_right",
            WidthRequest = 24,
            HeightRequest = 24,
            Aspect = Aspect.AspectFit,
            VerticalOptions = LayoutOptions.Center,
            HorizontalOptions = LayoutOptions.End
        };

        private readonly StackLayout StackLayoutHorizontal = new StackLayout {
            Orientation = StackOrientation.Horizontal,
            VerticalOptions = LayoutOptions.Center
        };
        #endregion

        #region Initialization
        public ImageLabelViewCell() {
            this.Setup();
        }
        #endregion

        #region Private API
        private void Setup() {
            var relativeLayout = new RelativeLayout();

            // content
            this.StackLayoutHorizontal.Children.Add(this.ImageLeft);
            this.StackLayoutHorizontal.Children.Add(this.LabelText);
            this.StackLayoutHorizontal.Children.Add(this.Separator);

            relativeLayout.Children.Add(StackLayoutHorizontal,
                            Constraint.RelativeToParent((parent) => {
                                return parent.X;
                            }),
                            Constraint.RelativeToParent((parent) => {
                                return parent.Y;
                            }),
                            Constraint.RelativeToParent((parent) => {
                                return parent.Width;
                            }),
                            Constraint.RelativeToParent((parent) => {
                                return parent.Height;
                            })
                           );

            // indicator
            relativeLayout.Children.Add(ImageArrow,
                                        Constraint.RelativeToParent((parent) => {
                                            double imageWidth = ImageArrow.Width;
                                            if (ImageArrow.Width < 0) { imageWidth = 24; }
                                            return parent.Width - (imageWidth / 2) - 20;
                                        }),
                                        Constraint.RelativeToParent((parent) => {
                                            double imageHeight = ImageArrow.Height;
                                            if (ImageArrow.Width < 0) { imageHeight = 24; }
                                            return (parent.Height / 2) - (imageHeight / 2);
                                        })
                                       );


            // separator
            // add(view, xPos?, yPos?, width?, height?)
            relativeLayout.Children.Add(Separator,
                                        Constraint.RelativeToParent((parent) => {
                                            return parent.X;
                                        }),
                                        Constraint.RelativeToParent((parent) => {
                                            return parent.Height - 1;
                                        }),
                                        Constraint.RelativeToParent((parent) => {
                                            return parent.Width;
                                        })
                                       );

            SelectedBackgroundColor = Color.FromHex("#183844");
            View = relativeLayout;
        }
        #endregion

        #region Public API

        #endregion

        #region Delegates

        #endregion

    }
}
