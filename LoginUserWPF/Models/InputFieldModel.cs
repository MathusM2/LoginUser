using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Models
{
    public class InputFieldModel<T> : INotifyPropertyChanged
    {
        public string _nameField;
        public T _value;
        public string _errorMessage;
        public bool _hasError;

        public T Value
        {
            get { return _value; }
            set { _value = value; OnPropertyChanged(nameof(Value)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
