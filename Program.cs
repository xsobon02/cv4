using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cv4
{
    class Program
    {
        static void Main(string[] args)
        {
            string testovaciText = "Toto je retezec predstavovany nekolika radky,\n"
                                 + "ktere jsou od sebe oddeleny znakem LF (Line Feed).\n"
                                 + "Je tu i nejaky ten vykricnik! Pro ucely testovani i otaznik?\n"
                                 + "Toto je jen zkratka zkr. ale ne konec vety. A toto je\n"
                                 + "posledni veta! covid";
            StringStatistics a = new StringStatistics(testovaciText);
            Console.WriteLine("Number of words : " + a.WordCount());
            Console.WriteLine("Number of lines : " + a.LineCount());
            Console.WriteLine("Number of sentences : " + a.SentenceCount());
            Console.WriteLine("Longest Words : " + String.Join(", ", a.LongestWords()));
            Console.WriteLine("Shortest Words : " + String.Join(", ", a.ShortestWords()));
            Console.WriteLine("Most Common word : " + String.Join(", ", a.CommonWords()));
            Console.WriteLine("Sorted words : " + String.Join(", ", a.AlphSort()));
            Console.WriteLine("Is infected : " + a.IsInfected());
            Console.ReadLine();
 

        }
    }
}
