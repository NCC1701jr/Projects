using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fallout3_computerhack
{
    class cWordCollection
    {
        public cWordCollection()
        {
            m_collection = new List<cWord>();
        }

        public List<cWord> m_collection { get; set; }
        public int CharCount { get; set; }


        public bool AppendWord(cWord WordToChange, cWord ChangeToWord)
        {
            bool result = false;

            if (m_collection.Contains(WordToChange))
            {
                m_collection.Remove(WordToChange);
                m_collection.Add(ChangeToWord);
                result = true;
            }

            return result;
        }

        public List<string> ConvertToString()
        {
            List<string> result = new List<string>();

            foreach (cWord i in m_collection)
            {
                result.Add(i.word);
            }

            return result;
        }

        public void AppendSearch(cWord WordTried, int GoodChars)
        {
            if (m_collection.Contains(WordTried))
            {
                m_collection.Remove(WordTried);
            }

            //get char list from word to check to and copy word list to append in

            //List<char> abc = textBox2.Text.Select(c => c).ToList();
            List<char> InputWord = WordTried.chars;
            List<cWord> corr = new List<cWord>();
            corr = m_collection.ToList();

            //check every word in m_collection

            foreach (cWord i in m_collection)
            {
                //get char list from word to check and create bool list to find the good charsin good places
                List<char> CheckWord = i.chars;
                List<bool> correction = new List<bool>();
                int index = 0;

                //check which chars are on the same place. bool list will state true on index of match and false on index of non-match

                foreach (char t in InputWord)
                {
                    //correction.Add(ab.Contains(t));
                    correction.Add(CheckWord.ElementAt<char>(index) == t);
                    index++;
                }

                //if the amount of matched chars is the same as the correct value than word still qualifies.

                if (correction.FindAll(v => v == true).Count == GoodChars)
                {

                }

                // if not word does not qualify than word is removes from m_collection

                else
                {
                    corr.Remove(i);
                }
            }

            //appended list is merged with original list.

            m_collection.Clear();
            m_collection = corr.ToList<cWord>();
        }

        public cWord GetBestGuess()
        {
            cWord result = new cWord("");

            List<int> wordValues = GetWordValues();
            result = m_collection.ElementAt(wordValues.FindIndex(c => c == wordValues.Max()));

            return result;
        }

        private List<int> GetWordValues()
        {
            List<int> wordvalues = new List<int>();
            int[] charValues = new int[26];
            int[] WordValue = new int[26];

            foreach (cWord i in m_collection)
            {
                WordValue = i.GetWordValue();
                int count = 0;
                foreach (int t in charValues)
                {
                    charValues[count] = WordValue[count] + t;
                    count++;
                }
            }
            foreach (cWord i in m_collection)
            {
                int value = 0;
                foreach (char t in i.chars)
                {
                    value = value + charValues[(int)t - 97];
                }
                wordvalues.Add(value);
            }

            return wordvalues;
        }
    }
}
