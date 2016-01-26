using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Fallout3_computerhack
{
    class cWord
    {
        public string word { get; set; }
        public List<char> chars { get; set; }


        public int[] GetWordValue()
        {
            int[] charvalues = new int[26];

            foreach (char i in chars)
            {
                int place = (int)i - 97;
                charvalues[place]++;

            }

            return charvalues;
        }

        public cWord(string I = "")
        {
            word = I;
            chars = I.Select(c => c).ToList();
        }
    }
}
