using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CeasarLab1
{
    internal class FileIO
    {

        private Dictionary<char, int> letterCount;
        public String GetCount(String path)
        {

            letterCount = new Dictionary<char, int>();

            for (int x = 97; x <= 122; x++)
            {
                letterCount.Add((char)x, 0);
            }
            for (int x = 65; x <= 90; x++)
            {
                letterCount.Add((char)x, 0);
            }

            using (StreamReader sr = new StreamReader(path))
            {

                String line;

                while ((line = sr.ReadLine()) != null)
                {

                    foreach (char c in line)
                    {
                        if (c >= 97 && c <= 122 || (c >= 65 && c <= 90))
                        {
                            if (letterCount.ContainsKey(c))
                            {
                                letterCount[c]++;
                            }
                        }
                    }

                }

            }
            StringBuilder result = new StringBuilder();
            foreach (var c in letterCount)
            {
                result.AppendLine($"{c.Key}: {c.Value}");
            }

            return result.ToString();

        }


        public (char max, int maxCount, char Second, int SecondCount) MostUpperCaseOccurence()
        {
            var maxUppercaseValue = letterCount.Where(x => char.IsUpper(x.Key)).OrderByDescending(x => x.Value).FirstOrDefault();

            var SecondMaxUppercaseValue = letterCount.Where(x => char.IsUpper(x.Key)).OrderByDescending(x => x.Value).Skip(1).FirstOrDefault();

            return (maxUppercaseValue.Key, maxUppercaseValue.Value, SecondMaxUppercaseValue.Key, SecondMaxUppercaseValue.Value);


        }


        public (char max, int maxCount, char Second, int SecondCount) MostOccurenceLowerCase()
        {
            var maxLowercaseValue = letterCount.Where(x => char.IsLower(x.Key)).OrderBy(x => x.Value).Last();

            var SecondmaxLowercaseValue = letterCount.Where(x => char.IsLower(x.Key)).OrderByDescending(x => x.Value).Skip(1).FirstOrDefault();

            return (maxLowercaseValue.Key, maxLowercaseValue.Value, SecondmaxLowercaseValue.Key, SecondmaxLowercaseValue.Value);


        }

        public int CalculateShiftUppercase(char trainingMostFrequent, char scrambledMostFrequent)
        {
            return (scrambledMostFrequent - trainingMostFrequent + 26) % 26;


        }

        public int CalculateShiftLowerCase(char trainingMostFrequent, char scrambledMostFrequent)
        {
            return (scrambledMostFrequent - trainingMostFrequent + 26) % 26;


        }

        public string ReadFile(string fileName)
        {
            if (File.Exists(fileName))
            {

                return File.ReadAllText(fileName);
            }
            else
            {
                return string.Empty;
            }
        }

        public int CountLine(string path)
        {

            int linecounter = 0;

            using (StreamReader sr = new StreamReader(path))
            {

                while (sr.ReadLine() != null)
                {
                    linecounter++;
                }

            }
            return linecounter;

        }

        public int CountCharacters(string path)
        {
            int charcounter = 0;


            using (StreamReader sr = new StreamReader(path))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    foreach (char c in line)
                    {
                        charcounter++;
                       
                    }
                }

            }
            return charcounter;
        }

    }
}


