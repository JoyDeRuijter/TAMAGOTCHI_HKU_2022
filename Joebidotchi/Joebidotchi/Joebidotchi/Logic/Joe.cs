using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Joebidotchi.Logic
{
    public class Joe
    {
        private Timer timer;
        public bool isDead;
        public int numOfDays;
        public string currentMood = "Biden_Neutral";
        public string currentDialogue = "America's a Nation, that can be defined in a single word:";
        private int dialogueIndex = 0;

        public Joe()
        {
            timer = new Timer();
            SetTimer(timer, 4000);
        }

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
            new Stat("Hunger", 0.001f, 0),
            new Stat("Thirst", 0.002f, 1),
            new Stat("Boredom", 0.0009f, 2),
            new Stat("Loneliness", 0.003f, 3),
            new Stat("Overstimulated", 0.0009f, 4),
            new Stat("Tired", 0.004f, 5)
        };

        private DialogueLine[] dialogueLines =
        {
            new DialogueLine('A', 0, "America's a Nation, that can be defined in a single word:"),
            new DialogueLine('A', 1, ".. awdsmfafoothimaaafootafootwhscuseme"),
            new DialogueLine('A', 2, ".. foothills of the Himalayas with xi jinping"),
            new DialogueLine('B', 0, "If you're a toov, if you're a toos- ah- eh-"),
            new DialogueLine('B', 1, ".. if you're a family, that's a two-er or a wage earner"),
            new DialogueLine('B', 2, ".. each of the parents, one making 30 grand, one making 40 or 50"),
            new DialogueLine('B', 3, ".. maybe that's a little more than well yeah, they need the money"),
            new DialogueLine('C', 0, "Imagine had the tobacco industry been immune to prostitute"),
            new DialogueLine('D', 0, "Y'know the rapidly rising uhh uhhm in with uhh inability to focus"),
            new DialogueLine('E', 0, "And here comes the train that he tried to make sure"),
            new DialogueLine('E', 1, ".. didn't continue to gowopgrun, naww that's the commuter eh"),
            new DialogueLine('E', 2, ".. alright... aw... that's wha- But folks look!"),
            new DialogueLine('F', 0, "I'm the environment"),
            new DialogueLine('G', 0, "That saves billions of gallons of gasoline, I mean bill- billions"),
            new DialogueLine('G', 1, ".. of uh 2 point, 2.3 billion dollars worth of, excuse me"),
            new DialogueLine('G', 2, ".. 500 billion dollars in savings, and 2 point something"),
            new DialogueLine('G', 3, ".. billion metric tons of C02 going in the air!"),
            new DialogueLine('H', 0, "Hey everyone, I'm Joe Biden's husband"),
            new DialogueLine('I', 0, "My grandpa was name andrew-th.. th-vinnegar"),
            new DialogueLine('I', 1, ".. as kitchen table I learned... eh.."),
            new DialogueLine('I', 2, ".. I used to say joe ain't nobody is better than you"),
            new DialogueLine('I', 3, ".. but you're no better than anybody else"),
            new DialogueLine('J', 0, "I get hot I got alot hairy legs, that turn that.. that.. that.."),
            new DialogueLine('J', 1, ".. turn turn turn um.. um.. blonde in the sun."),
            new DialogueLine('J', 2, ".. and the kid used to come up and reach in the pool"),
            new DialogueLine('J', 3, ".. and rub my leg down, so straight and then watch the hair"),
            new DialogueLine('J', 4, ".. mm come back up again and look at so I learned about roaches "),
            new DialogueLine('J', 5, ".. I learned about kids jumping on my lap"),
            new DialogueLine('J', 6, ".. and I love kids jumping on my lap"),
            new DialogueLine('K', 0, "Bleghh, I'm dead. Press the resetbutton to restart")
        };

        public void CalculateCurrentMood()
        {
            float totalStat = 0f;
            foreach (Stat stat in stats)
                totalStat += stat.Value;

            if (totalStat == 6f)// If all stats are completely drained -> Biden is dead
            { 
                currentMood = moods[5].imgSrc;
                isDead = true;
            }
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

        public void SetCurrentDialogue()
        {
            if (!isDead)
                currentDialogue = dialogueLines[dialogueIndex].Dialogue;
            else
                currentDialogue = dialogueLines[dialogueLines.Length - 1].Dialogue;
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

        private void SetTimer(Timer _timer, double _interval)
        {
            _timer.Enabled = true;
            _timer.Interval = _interval;
            _timer.AutoReset = true;
            _timer.Elapsed += OnTimerElapsed;
            _timer.Start();
        }

        public void OnTimerElapsed(object sender, ElapsedEventArgs args)
        {
            Device.BeginInvokeOnMainThread(() =>
            {
                if(dialogueIndex + 1 < dialogueLines.Length )
                    dialogueIndex++;
                else
                    dialogueIndex = 0;

                SetCurrentDialogue();
            });
        }

        public void OnReset()
        {
            numOfDays = 0;
            currentMood = "Biden_Happy";
            isDead = false;

            foreach (Stat stat in stats)
            {
                stat.Value = 0f;
            }

            foreach (Stat stat in stats)
                stat.SaveData();

            SaveData();
        }
    }
}
