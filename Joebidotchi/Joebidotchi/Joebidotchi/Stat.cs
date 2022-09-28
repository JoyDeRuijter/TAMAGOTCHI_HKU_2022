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

        //public void Increase(float _value)
        //{
        //    if (value + _value >= 1)
        //        value = 1;
        //    else 
        //        value += _value;
        //}

        //public void Decrease(float _value)
        //{ 
        //    if (value - _value <= 0)
        //        value = 0;
        //    else
        //        value -= _value;
        //}
    }
}
