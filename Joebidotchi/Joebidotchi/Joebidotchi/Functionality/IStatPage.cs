using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi.Functionality
{
    internal interface IStatPage
    {
        void OnLeftArrowClicked(object sender, EventArgs e);
        void OnRightArrowClicked(object sender, EventArgs e);
        void OnStatButtonClicked(object sender, EventArgs e);
    }
}
