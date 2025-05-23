using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using LoginUserWPF.Models;
using Microsoft.Xaml.Behaviors;

namespace LoginUserWPF.Helper.Behaviors
{
    public class ComboBoxBehavior : Behavior<ComboBox>
    {
        public static readonly DependencyProperty ValidationResultProperty =
            DependencyProperty.Register("ValidationResult", typeof(InputFieldModel<string>), typeof(ComboBoxBehavior), new PropertyMetadata(null));

        public InputFieldModel<string> ValidationResult
        {
            get { return (InputFieldModel<string>)GetValue(ValidationResultProperty); }
            set { SetValue(ValidationResultProperty, value); }
        }

        protected override void OnAttached()
        {
            base.OnAttached();
            AssociatedObject.SelectionChanged += OnSelectionChanged;
        }

        private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selected = e.AddedItems.Count > 0 ? e.AddedItems[0] : null;
            var selectedTagItem = AssociatedObject.Tag.ToString();
            string? value = null;

            if (selected is ComboBoxItem comboBoxItem)
            {
                value = comboBoxItem?.Content?.ToString();
            }
            else if (selected != null)
            {
                value = selected.ToString();
            }
            else
            {
                value = AssociatedObject.Text;
            }
            if(!string.IsNullOrEmpty(value) && selectedTagItem != null)
            {
                var (IsValid, Message) = ValidateInputsHelper.Validate(selectedTagItem, value);

                ValidationResult.hasError = !IsValid;
                ValidationResult.Message = Message ?? string.Empty;
            }
        }

        protected override void OnDetaching()
        {
            base.OnDetaching();
            AssociatedObject.SelectionChanged -= OnSelectionChanged;
        }
    }
}
