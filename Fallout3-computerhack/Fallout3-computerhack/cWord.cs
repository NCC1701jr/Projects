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
        private string _word { get; set; }
//        public List<char> m_chars { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public int[] GetWordValue()
        {
            int[] charvalues = new int['Z'-'A'+ 1];

            foreach (char i in GetChars())
            {
                int place = (int)i - 'a';
                charvalues[place]++;
            }

            return charvalues;
        }

        public string GetWord()
        {
            return _word;
        }
        public void SetWord(string a_word)
        {
            _word = a_word.ToLower();
        }

        public List<char> GetChars()
        {
            return _word.Select(c => c).ToList();
        }

        public cWord(string a_word = "")
        {
            //m_word  = a_word.ToLower();
            SetWord(a_word);
//            m_chars = a_word.Select(c => c).ToList();
        }
    }
}
