using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi.Logic
{
    public interface IStatPage
    {
        string Name { get; set; }
        Stat Stat { get; set; }

        void OnLeftArrowClicked(object sender, EventArgs e);
        void OnRightArrowClicked(object sender, EventArgs e);
        void OnStatButtonClicked(object sender, EventArgs e);
    }
}
