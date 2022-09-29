using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace Joebidotchi.Logic
{
    public class Joe
    {
        public int numOfDays;
        public string currentMood = "Biden_Neutral";

        private Mood[] moods =
        {
            new Mood("Happy"),
            new Mood("Neutral"),
            new Mood("Bored"),
            new Mood("Angry"),
            new Mood("Sad"),
            new Mood("Dead")
        };

        public Stat[] stats =
        {
            new Stat("Hunger", 0.01f, 0),
            new Stat("Thirst", 0.02f, 1),
            new Stat("Boredom", 0.005f, 2),
            new Stat("Loneliness", 0.03f, 3),
            new Stat("Overstimulated", 0.05f, 4),
            new Stat("Tired", 0.01f, 5)
        };

        public void CalculateCurrentMood()
        {
            float totalStat = 0f;
            foreach (Stat stat in stats)
                totalStat += stat.Value;

            if (totalStat == 6f) // If all stats are completely drained -> Biden is dead
                currentMood = moods[5].imgSrc;
            else if (totalStat >= 3.5f && totalStat < 6f)
            {
                if (stats[4].Value == 1f) // If the overstimulated stat is completely drained -> Biden is angry
                    currentMood = moods[3].imgSrc;
                else if (stats[2].Value == 1f) // If the boredom stat is completely drained -> Biden is bored
                    currentMood = moods[2].imgSrc;
                else if (stats[3].Value == 1f) // If the Loneliness stat is completely drained -> Biden is sad
                    currentMood = moods[4].imgSrc;
                else
                    currentMood = moods[4].imgSrc; // In all other cases -> Biden is sad
            }
            else if (totalStat >= 1.5f && totalStat < 3.5f)
                currentMood = moods[1].imgSrc;
            else
                currentMood = moods[0].imgSrc;
        }

        public void GetData()
        {
            if (Preferences.ContainsKey("NumOfDays"))
                numOfDays = Preferences.Get("NumOfDays", 1);

            if (Preferences.ContainsKey("CurrentMood"))
                currentMood = Preferences.Get("CurrentMood", "Biden_Neutral");
        }

        public void SaveData()
        {
            Preferences.Set("NumOfDays", numOfDays);
            Preferences.Set("CurrentMood", currentMood);
        }
    }
}
