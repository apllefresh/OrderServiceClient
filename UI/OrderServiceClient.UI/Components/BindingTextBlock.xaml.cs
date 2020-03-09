using System.Windows;
using System.Windows.Controls;

namespace OrderServiceClient.UI.Components
{
    public partial class BindingTextBlock : UserControl
    {
        public string Label
        {
            get { return (string)GetValue(LabelProperty); }
            set { SetValue(LabelProperty, value); }
        }

        public static readonly DependencyProperty LabelProperty = DependencyProperty.Register("Label", typeof(string), typeof(BindingTextBlock), new FrameworkPropertyMetadata(""));

        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }

        public static readonly DependencyProperty ValueProperty = DependencyProperty.Register("Value", typeof(string), typeof(BindingTextBlock), new FrameworkPropertyMetadata(""));

        public BindingTextBlock()
        {
            InitializeComponent();
        }
    }
}
