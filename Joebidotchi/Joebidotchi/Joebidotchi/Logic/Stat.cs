using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Joebidotchi.Logic
{
    public class Stat
    {
        public string Name { get; set; }
        public float Value { get; set; }
        public int index;

        public delegate void StatEvent(Stat stat);
        private event StatEvent OnStatChanged;

        private Joe joe = DependencyService.Get<Joe>();

        public string currentIconSrc;
        private string[] iconSrcs = new string[3];
        private float[] statThresholds = { 0.4f, 0.8f, 1f };
        private float statIncrease;

        public Stat(string _name, float _statIncrease, int _index)
        { 
            Name = _name;
            statIncrease = _statIncrease;
            index = _index;

            BuildIconSrcs(_name);

            if(Preferences.ContainsKey($"{Name}_Stat"))
                Value = Preferences.Get($"{Name}_Stat", Value);
            else
                SaveData();
        }

        public void AddStatObserver(StatEvent _function) { OnStatChanged += _function; }
        public void RemoveStatObserver(StatEvent _function) { OnStatChanged -= _function; }

        public void Increase()
        {
            if (Value + statIncrease >= 1)
                Value = 1;
            else
                Value += statIncrease;

            CheckThreshold();
            OnStatChanged?.Invoke(this);
        }

        public void Decrease(float _value)
        {
            if (Value - _value <= 0)
                Value = 0;
            else
                Value -= _value;

            CheckThreshold();
            OnStatChanged?.Invoke(this);
        }

        public void GetData()
        {
            if(Preferences.ContainsKey($"{Name}_Stat"))
                Value = Preferences.Get($"{Name}_Stat", 0f);
        }

        public void SaveData()
        {
            Preferences.Set($"{Name}_Stat", Value);
        }

        private void BuildIconSrcs(string _statName)
        {
            iconSrcs[0] = $"Icon_{_statName}_Green";
            iconSrcs[1] = $"Icon_{_statName}_Yellow";
            iconSrcs[2] = $"Icon_{_statName}_Red";
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
    }
}
