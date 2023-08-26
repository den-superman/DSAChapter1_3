using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DSAChapter1_3
{
    public class Core
    {
        public static Dictionary<string, int> CalculateWords(string file)
        {
            try
            {
                string text = File.ReadAllText(file);
                string[] words = text.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', ';', ':', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<string, int> wordFrequency = new Dictionary<string, int>();

                foreach (string word in words)
                {
                    string normalizedWord = word.ToLower();
                    if (!wordFrequency.ContainsKey(normalizedWord))
                    {
                        wordFrequency[normalizedWord] = 0;
                    }
                    wordFrequency[normalizedWord]++;
                }

                return wordFrequency;
            }
            catch (IOException e)
            {
                return null;
                Console.WriteLine("An error occurred while reading the file: " + e.Message);
            }
            
        }
    }
}
