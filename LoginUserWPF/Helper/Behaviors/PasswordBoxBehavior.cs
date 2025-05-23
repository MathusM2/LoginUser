using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using Microsoft.Xaml.Behaviors;
using MaterialDesignThemes;
using MaterialDesignThemes.Wpf;
using LoginUserWPF.Models;
using System.Diagnostics;

namespace LoginUserWPF.Helper.Behaviors
{
    public class PasswordBoxBehavior : Behavior<PasswordBox>
    {
        public static readonly DependencyProperty ValidationStateProperty =
            DependencyProperty.Register("ValidationState", typeof(InputFieldModel<string>), typeof(PasswordBoxBehavior), new PropertyMetadata(null));

        public InputFieldModel<string> ValidationState
        {
            get { return (InputFieldModel<string>)GetValue(ValidationStateProperty); }
            set { SetValue(ValidationStateProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.GotFocus += OnGotFocus;
        }
        private void OnGotFocus(object sender, RoutedEventArgs e)
        {
            if(ValidationState.hasError == true)
            {
                ValidationState.hasError = false;
                ValidationState.Message = string.Empty;
            }
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.GotFocus -= OnGotFocus;
        }
    }
}
