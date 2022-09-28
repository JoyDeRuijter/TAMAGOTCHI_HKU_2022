using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi
{
    internal class Joe
    {
        public Dictionary<string, Stat> stats = new Dictionary<string, Stat>()
        {
            { "Hunger", new Stat { statName = "Hunger", statValue = 1f} },
            { "Thirst", new Stat { statName = "Thirst", statValue = 1f} },
            { "Boredom", new Stat { statName = "Boredom", statValue = 1f} },
            { "Loneliness", new Stat { statName = "Loneliness", statValue = 1f} },
            { "Stimulated", new Stat { statName = "Stimulated", statValue = 1f} },
            { "Energy", new Stat { statName = "Energy", statValue = 1f} }
        };
    }
}
