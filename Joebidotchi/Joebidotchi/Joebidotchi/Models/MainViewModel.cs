using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace Joebidotchi.Models
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private int numOfDays;
        public int NumOfDays
        { 
            get => numOfDays;
            set
            {
                if (numOfDays == value)
                    return;

                numOfDays = value;
                OnPropertyChanged(nameof(NumOfDays));
                OnPropertyChanged(nameof(DisplayNumOfDays));
            }
        }

        public string DisplayNumOfDays => $"Day: {NumOfDays}";


        public void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
