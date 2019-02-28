using System.Windows;
using System.Windows.Controls;

namespace Poberezhets01.Tools.Controls
{
    public partial class LabelAndTextControl : UserControl
    {
        public LabelAndTextControl()
        {
            InitializeComponent();
        }
        public static readonly DependencyProperty TextProperty = DependencyProperty.Register
        (
            "Text",
            typeof(string),
            typeof(LabelAndTextControl),
            new PropertyMetadata(null)
        );
        public string Text
        {
            get
            {
                return (string)GetValue(TextProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }

        public static readonly DependencyProperty CaptionProperty = DependencyProperty.Register
        (
            "Caption",
            typeof(string),
            typeof(LabelAndTextControl),
            new PropertyMetadata(null)
        );
        public string Caption
        {
            get
            {
                return (string)GetValue(CaptionProperty);
            }
            set
            {
                SetValue(CaptionProperty, value);
            }
        }
    }
}
