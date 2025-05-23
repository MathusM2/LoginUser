using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoginUserWPF.Models
{
    /// <summary>
    /// Model for the input field
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class InputFieldModel<T> : INotifyPropertyChanged
    {
        private T _value;
        private string _Message;
        private bool _hasError;

        public T Value
        {
            get { return _value; }
            set
            {
                if (!Equals(_value, value))
                {
                    _value = value; OnPropertyChanged(nameof(Value));
                }
            }
        }
        public bool hasError
        {
            get { return _hasError; }
            set { _hasError = value; OnPropertyChanged(nameof(hasError)); }
        }

        public string Message
        {
            get { return _Message; }
            set { _Message = value; OnPropertyChanged(nameof(Message)); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
