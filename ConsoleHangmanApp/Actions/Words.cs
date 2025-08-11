using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleHangmanApp.Actions
{
    public class Words
    {

        public static string GetRandomWord()
        {
            List<string> words;

            words = new List<string>
            {
                "äpple",
                "bäck",
                "cykel",
                "dator",
                "ekorre",
                "fjäder",
                "grusväg",
                "himmel",
                "isflak",
                "jordgubbe"
            };

            // Randomly select a word from the list
            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index];
        }

    }
}
