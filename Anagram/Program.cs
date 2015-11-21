using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Anagram
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] lines = System.IO.File.ReadAllLines(@"text.txt");
            Console.WriteLine("Reading from file succeed!");
            StringBuilder response = new StringBuilder();
            List<String> checkwords = lines.ToList<String>();
            List<String> checklist = lines.ToList<String>();
            for (int i = 0; i < checkwords.Count - 1; i++)
            {
                response.Append(checkwords[i]);
                for(int k = i+1;k<checklist.Count-1;k++)
                {
                    if (isAnagram(checkwords[i], checklist[k]))
                    {
                        response.Append(", " + checklist[k]);
                        checklist.RemoveAt(k);
                        checkwords.RemoveAt(k);
                        k--;
                    }                   
                }
                response.Append(";\n");
            }
            System.IO.File.WriteAllText(@"result.txt", response.ToString());
            Console.WriteLine("ready!");
            Console.ReadLine();
        }

       static  public bool isAnagram(string word1, string word2)
        {
            bool isAnagr = false;
            if (word1.Length == word2.Length)
                foreach (char c in word1)
                {
                    if (!word2.Contains(c))
                    {
                        isAnagr = false;
                        break;
                    }
                    else isAnagr = true;                    
                }
            return isAnagr;
        }
    }
}
