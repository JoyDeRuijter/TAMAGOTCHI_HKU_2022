using System;
using System.Collections.Generic;
using System.Text;
using Joebidotchi.Functionality.Stats;

namespace Joebidotchi.Functionality
{
    internal class Joe
    {
        public Dictionary<string, AStat> stats = new Dictionary<string, AStat>()
        {
            { "Hunger", new AStat { statName = "Hunger", Value = 1f} },
            { "Thirst", new AStat { statName = "Thirst", Value = 1f} },
            { "Boredom", new AStat { statName = "Boredom", Value = 1f} },
            { "Loneliness", new AStat { statName = "Loneliness", Value = 1f} },
            { "Stimulated", new AStat { statName = "Stimulated", Value = 1f} },
            { "Energy", new AStat { statName = "Energy", Value = 1f} }
        };
    }
}
