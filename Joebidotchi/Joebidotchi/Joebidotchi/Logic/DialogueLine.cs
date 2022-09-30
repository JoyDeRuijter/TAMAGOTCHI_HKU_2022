using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi.Logic
{
    public class DialogueLine
    {
        public char group;
        public int index;
        public string dialogue;

        public DialogueLine(char _group, int _index, string _dialogue)
        { 
            group = _group;
            index = _index;
            dialogue = _dialogue;
        }
    }
}
