using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text.RegularExpressions;

namespace cv4
{
    public class StringStatistics
    {
        private string input;
        public StringStatistics(string input)
        {
            this.input = input;
        }
        public int WordCount()
        {
            int wcount = input.Split().Length;
            return wcount;
        }
        public int LineCount()
        {
            int lcount = input.Split('\n').Length;
            return lcount;
        }
        public int SentenceCount()
        {
            string regex = @"(\.|\?|!)\s[A-Z]";
            MatchCollection matches = Regex.Matches(input, regex);
            int i = 0;
            string[] separators = new string[matches.Count];
            foreach(Match match in matches)
            {
                separators[i] = match.Value;
                i++;
            }
            return input.Split(separators, StringSplitOptions.None).Length;
        }
        public List<string> LongestWords()
        {
            string[] words = input.Split(new Char[] { ' ', '.', '?', '!', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var longest = words
                .OrderByDescending(w => w.Length)
                .FirstOrDefault();
            return words
                .Where(w => w.Length == longest.Length)
                .ToList();           
        }
        public List<string> ShortestWords()
        {
            string[] words = input.Split(new Char[] { ' ', '.', '?', '!', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
            var shortest = words
                .OrderBy(w => w.Length)
                .FirstOrDefault();
            return words
                .Where(w => w.Length == shortest.Length)
                .ToList();
        }
        public string[] CommonWords()
        {
            string[] words = input.ToLower().Split(new Char[] { ' ', '.', '?', '!', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries); // rozdelujem string na jednotlive slove a zaroven davam
                                                                                                                                         // vsetky slova na lower case aby sa napr Je=je
            var list = new List<string>();
            var nameGroup = words.GroupBy(x => x);        //zoskupujem slova do skupiny
            var maxCount = nameGroup.Max(g => g.Count());    //vyhladavam najcastejsie pouzite slovo
            var mostCommon = nameGroup.Where(x => x.Count() == maxCount).Select(x => x.Key).ToArray();  //vyberam najcastejsie pouzite slova a vkladam ich do Array ak by ich bolo viac nez jedno
            return mostCommon;
        }
        public List<string> AlphSort()
        {
            string[] words = input.Split(new Char[] { ' ', '.', '?', '!', ',', '\n','(',')' }, StringSplitOptions.RemoveEmptyEntries);
            var list = new List<string>();
            foreach(var i in words) //prechadzam cez jednotlive slova a pridavam ich do listu, ktory pomocou .Sort zoradim podla abecedy
            {
                list.Add(i);
            }
            list.Sort();
            return list;
        }
        public bool IsInfected()
        {
            string[] words = input.ToLower().Split(new Char[] { ' ', '.', '?', '!', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries); // rozdelujem string na jednotlive slove a zaroven davam
                                                                                                                                         // vsetky slova na lower case aby sa napr covid=Covid
            foreach (var j in words)
            {
                if (j == "covid" || j == "covid-19" || j == "sars-cov-2") return true;                
            }
            return false;
        }
    }
}
