using static System.Net.Mime.MediaTypeNames;
using System.Text.RegularExpressions;
using System.Diagnostics;

namespace ArrayExercise
{
    internal class Program
    {
        public static string readTextFromFile(string path)
        {
            return System.IO.File.ReadAllText(path);
        }

        public static string[] getAllWords(string text)
        {
            List<string> finalResult = new List<string>();
            string[] words = Regex.Split(text, @"\W+");
            for (int i = 0; i < words.Length; i++)
            {
                if (words[i].Length < 3)
                {
                    continue;
                }
                finalResult.Add(words[i]);
            }
            return finalResult.ToArray();
        }

        //The number of words
        public static int wordCounter(string[] arr)
        {
            int count = 0;
            foreach (var word in arr)
            {
                if (word.Length >= 3)
                {
                    count++;
                }
            }
            return count;
        }

        //The shortest word

        public static string shortestWord(string[] arr)
        {
            string shortestWord = "";

            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i].Length >= 3)
                {
                    if (String.IsNullOrEmpty(shortestWord) || arr[i].Length < shortestWord.Length)
                        shortestWord = arr[i];
                }
            }
            return shortestWord;
        }

        //The longest word
        public static string longestWord(string[] arr)
        {
            string longestWord = "";
            for (int i = 0; i < arr.Length; i++)
            {
                if (longestWord == "" || arr[i].Length > longestWord.Length)
                    longestWord = arr[i];
            }
            return longestWord;
        }

        //Average word length
        public static double averageWordLength(string[] arr)
        {
            int totalLength = 0;
            foreach (string word in arr)
            {
                totalLength += word.Length;
            }
            double averageLength = (double)totalLength / arr.Length;
            return averageLength;
        }

        //Founded word frequency
        public static Dictionary<string, int> foundedWordFrequency(string[] arr)
        {
            Dictionary<string, int> foundedWordFrequency = new Dictionary<string, int>();
            foreach (var word in arr)
            {
                if (word.Length >= 3)
                {
                    if (foundedWordFrequency.ContainsKey(word))
                    {
                        foundedWordFrequency[word]++;
                    }
                    else
                    {
                        foundedWordFrequency[word] = 1;
                    }
                }
            }
            return foundedWordFrequency;
        }

        //Five most common words

        public static string[] FiveMostCommonWords(string[] arr)
        {
            Dictionary<string, int> wordFrequency = foundedWordFrequency(arr);
            string[] fiveMostCommonWordsArr = new string[5];
            int count = 0;
            foreach (var word in wordFrequency)
            {
                if (fiveMostCommonWordsArr[count] == null)
                {
                    fiveMostCommonWordsArr[count] = word.Key;
                }
                else
                {
                    for (int i = 0; i < fiveMostCommonWordsArr.Length; i++)
                    {
                        if (wordFrequency[fiveMostCommonWordsArr[i]] < word.Value)
                        {
                            fiveMostCommonWordsArr[i] = word.Key;
                            break;
                        }
                    }
                }
                if (count < 4)
                {
                    count++;
                }
            }
            return fiveMostCommonWordsArr;
        }

        //Five least common words
        public static string[] FiveLeastCommonWords(string[] arr)
        {
            Dictionary<string, int> wordFrequency = foundedWordFrequency(arr);
            string[] topFiveLeastCommonWords = new string[5];
            int count = 0;
            foreach (var word in wordFrequency)
            {
                if (topFiveLeastCommonWords[count] == null)
                {
                    topFiveLeastCommonWords[count] = word.Key;
                }
                else
                {
                    for (int i = 0; i < topFiveLeastCommonWords.Length; i++)
                    {
                        if (wordFrequency[topFiveLeastCommonWords[i]] > word.Value)
                        {
                            topFiveLeastCommonWords[i] = word.Key;
                            break;
                        }
                    }
                }
                if (count < 4)
                {
                    count++;
                }
            }
            return topFiveLeastCommonWords;
        }



        static void Main(string[] args)
        {
            Console.WriteLine("Моля въведете пътя на книгата ви: ");
            string path = Console.ReadLine();
            string text = readTextFromFile(path);
            string[] words = getAllWords(text);
            Console.WriteLine();

            Stopwatch sw = new Stopwatch();
            sw.Start();

            Console.WriteLine("Броя на думите е: " + wordCounter(words));
            Console.WriteLine("Най - късата дума е: " + shortestWord(words));
            Console.WriteLine("Най - дългата дума е: " + longestWord(words));
            Console.WriteLine("Средната дължина на дума от текста е: " + averageWordLength(words));

            Console.WriteLine();
            string[] fiveMostCommonWords = FiveMostCommonWords(words);
            Console.WriteLine("Петте най - срещани думи са: ");
            for (int i = 0; i < fiveMostCommonWords.Length; i++)
            {
                Console.WriteLine(fiveMostCommonWords[i]);
            }
            Console.WriteLine();

            string[] fiveLeastCommonWords = FiveLeastCommonWords(words);
            Console.WriteLine("Петте най - малко срещани думи са: ");
            for (int i = 0; i < fiveLeastCommonWords.Length; i++)
            {
                Console.WriteLine(fiveLeastCommonWords[i]);
            }
            Console.WriteLine();

            sw.Stop();
            Console.WriteLine($"|| Execution time: {sw.ElapsedMilliseconds} ms.");
        }
    }
}