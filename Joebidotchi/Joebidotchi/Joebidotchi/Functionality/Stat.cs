using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Joebidotchi.Functionality
{
    public abstract class Stat
    {
        public string Name { get; set; }
        public float Value { get; set; }
        //public StatThreshold[] statThresholds;
        public delegate void StatEvent(float _currentValue);
        public string currentIconSrc;

        private float[] statThresholds = { 0.4f, 0.8f, 1f };
        private string[] iconSrcs = new string[3];
        private event StatEvent OnStatChanged;
        private Joe joe = DependencyService.Get<Joe>();

        public Stat(string _name)
        {
            Name = _name;
            Value = Preferences.Get($"{Name}_Stat", Value);
            BuildIconSrcs(_name);
            //App.OnAppSleep += OnSleep;
        }

        public void AddStatObserver(StatEvent _function) { OnStatChanged += _function; }
        public void RemoveStatObserver(StatEvent _function) { OnStatChanged -= _function; }

        private void OnSleep() { SaveData(); }

        public void Increase(float _value)
        {
            if (Value + _value >= 1)
                Value = 1;
            else
                Value += _value;

            OnStatChanged?.Invoke(Value);
            CheckThreshold();
        }

        public void Decrease(float _value)
        {
            if (Value - _value <= 0)
                Value = 0;
            else
                Value -= _value;

            OnStatChanged?.Invoke(Value);
        }

        private void CheckThreshold()
        {
            for (int i = 0; i < statThresholds.Length; i++)
            {
                if (Value <= statThresholds[i])
                {
                    if (i + 1 >= statThresholds.Length || Value <= statThresholds[i + 1])
                    {
                        currentIconSrc = iconSrcs[i];
                        return;
                    }
                }
            }
        }

        private void BuildIconSrcs(string _statName)
        {
            iconSrcs[0] = $"Icon_{_statName}_Green";
            iconSrcs[1] = $"Icon_{_statName}_Yellow";
            iconSrcs[2] = $"Icon_{_statName}_Red";
        }

        private void SaveData()
        {
            Preferences.Set($"{Name}_Stat", Value);
        }
    }
}
