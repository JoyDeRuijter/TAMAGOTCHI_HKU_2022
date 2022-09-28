using System;
using System.Collections.Generic;
using System.Text;

namespace Joebidotchi
{
    internal class Joe
    {
        Dictionary<string, Stat> stats = new Dictionary<string, Stat>()
        {
            { "Hunger", new Stat { statName = "Hunger", statValue = 0f} },
            { "Thirst", new Stat { statName = "Thirst", statValue = 0f} },
            { "Boredom", new Stat { statName = "Boredom", statValue = 0f} },
            { "Loneliness", new Stat { statName = "Loneliness", statValue = 0f} },
            { "Stimulated", new Stat { statName = "Stimulated", statValue = 0f} },
            { "Energy", new Stat { statName = "Energy", statValue = 0f} }
        };


    }
}
