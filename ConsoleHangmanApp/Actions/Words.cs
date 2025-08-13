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
                    "apple", "squirrel", "sky", "strawberry", "cat", "lamp", "dog", "house", "tree", "car",
                    "river", "mountain", "book", "chair", "table", "cup", "phone", "computer", "flower", "garden",
                    "school", "teacher", "student", "music", "guitar", "piano", "drum", "song", "dance", "movie",
                    "bread", "cheese", "milk", "coffee", "tea", "sugar", "salt", "pepper", "butter", "egg",
                    "shirt", "pants", "jacket", "shoes", "hat", "gloves", "scarf", "belt", "socks", "dress",
                    "clock", "watch", "door", "window", "roof", "wall", "floor", "ceiling", "light", "mirror",
                    "beach", "sand", "ocean", "wave", "sun", "moon", "star", "cloud", "rain", "snow",
                    "bread", "knife", "fork", "spoon", "plate", "bowl", "glass", "bottle", "napkin", "bag",
                    "road", "street", "bridge", "train", "bus", "bike", "truck", "plane", "ship", "boat",
                    "king", "queen", "prince", "princess", "castle", "knight", "sword", "shield", "dragon", "magic"
                };

            // Randomly select a word from the list
            Random random = new Random();
            int index = random.Next(words.Count);
            return words[index];
        }

    }
}
