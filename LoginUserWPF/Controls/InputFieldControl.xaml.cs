using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace LoginUserWPF.Controls
{
    /// <summary>
    /// Interação lógica para InputFieldControl.xam
    /// </summary>
    public partial class InputFieldControl : UserControl
    {
        public static readonly DependencyProperty StyleProperty =
            DependencyProperty.Register("TextBoxStyle", typeof(Style), typeof(InputFieldControl), new PropertyMetadata(null));
        public static readonly DependencyProperty HasErrorProperty =
            DependencyProperty.Register("HasError", typeof(bool), typeof(InputFieldControl), new PropertyMetadata(false));
        public static readonly DependencyProperty TextProperty = 
            DependencyProperty.Register("Text", typeof(string), typeof(InputFieldControl), new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
        public Style TextBoxStyle
        {
            get { return (Style)GetValue(StyleProperty); }
            set { SetValue(StyleProperty, value); }
        }
        public bool HasError
        {
            get { return (bool)GetValue(HasErrorProperty); }
            set { SetValue(HasErrorProperty, value); }
        }
        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public TextBox InnerTextBox => InputField;
        public InputFieldControl()
        {
            InitializeComponent();
        }
    }
}
