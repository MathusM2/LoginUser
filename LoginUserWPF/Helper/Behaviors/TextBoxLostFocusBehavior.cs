using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using LoginUserWPF.Infraestructure;
using LoginUserWPF.Models;
using Microsoft.Xaml.Behaviors;
using LoginUserWPF.Controls;
using System.Diagnostics;

namespace LoginUserWPF.Helper.Behaviors
{
    /// <summary>
    /// Behavior to validate the input field when it loses focus
    /// </summary>
    public class TextBoxLostFocusBehavior : Behavior<InputFieldControl>
    {
        public static readonly DependencyProperty ValidationResultProperty =
            DependencyProperty.Register("ValidationResult", typeof(InputFieldModel<string>), typeof(TextBoxLostFocusBehavior), new PropertyMetadata(null));

        public InputFieldModel<string> ValidationResult
        {
            get { return (InputFieldModel<string>)GetValue(ValidationResultProperty); }
            set { SetValue(ValidationResultProperty, value); }
        }
        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.LostFocus += AssociatedObject_ValidateField;
        }


        private void AssociatedObject_ValidateField(object sender, RoutedEventArgs e)
        {
            var (hasError, Message) = ValidateInputsHelper.Validate(AssociatedObject.Tag.ToString(), AssociatedObject.InnerTextBox.Text);

            if (!hasError)
            {
                ValidationResult.hasError = !hasError;
                ValidationResult.Message = Message;
            }
            else
            {
                ValidationResult.hasError = !hasError;
                ValidationResult.Message = Message;
            }   
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.LostFocus -= AssociatedObject_ValidateField;
        }
    }
}
