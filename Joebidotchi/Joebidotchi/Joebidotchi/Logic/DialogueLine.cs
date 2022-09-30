using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi.Logic
{
    public class DialogueLine
    {
        public char Group { get; set; }
        public int Index { get; set; }
        public string Dialogue { get; set; }

        public DialogueLine(char _group, int _index, string _dialogue)
        { 
            Group = _group;
            Index = _index;
            Dialogue = _dialogue;
        }
    }
}
