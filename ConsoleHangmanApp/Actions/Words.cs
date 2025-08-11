using System;

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
                "ekorre",
                "himmel",
                "jordgubbe",
                "katt",
                "lampa"
            };

            // Randomly select a word from the list
            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index];
        }

    }
}
