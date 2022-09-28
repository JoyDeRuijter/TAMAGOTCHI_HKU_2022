using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi
{
    internal class Stat
    {
        public string statName { get; set; }
        public float statValue { get; set; }

        //public Stat(string _name, float _startValue)
        //{
        //    name = _name;
        //    value = _startValue;
        //}

        public void Increase(float _value)
        {
            if (statValue + _value >= 1)
                statValue = 1;
            else
                statValue += _value;
        }

        public void Decrease(float _value)
        {
            if (statValue - _value <= 0)
                statValue = 0;
            else
                statValue -= _value;
        }
    }
}
