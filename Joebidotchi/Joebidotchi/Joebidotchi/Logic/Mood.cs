using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi.Logic
{
    public class Mood
    {
        public string Name { get; set; }
        public string imgSrc;

        public Mood(string _name)
        { 
            Name = _name;
            imgSrc = $"Biden_{_name}";
        }
    }
}
