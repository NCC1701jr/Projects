using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Fallout3_computerhack
{
    public partial class Form1 : Form
    {
        cWordCollection words = new cWordCollection();
        //List<string> words = new List<string>();
        //List<char> letters2 = new List<char>();

        public Form1()
        {
            InitializeComponent();
            TrBgoodChar.Enabled = false;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (words.m_collection.Count == 0) { words.CharCount = TrBgoodChar.Maximum = textBox1.Text.Count(); }
            if (textBox1.Text != "" && words.CharCount == textBox1.Text.Count())
            {
                richTextBox1.Text += textBox1.Text + '\n';
                cWord a = new cWord(textBox1.Text);
                words.m_collection.Add(a);
                refreshList(words.ConvertToString());
                textBox1.Text = "";
            }
            else if (words.CharCount != textBox1.Text.Count())
            {
                MessageBox.Show("invalid number of char in your word!\nA word must have " 
                    + words.CharCount.ToString() 
                    + " char.\nFor example: " 
                    + words.m_collection.ElementAt(0).GetWord()
                    + "."
                    , "invalid input"
                    , MessageBoxButtons.OK);
            }
            if (words.m_collection.Count != 0)
            {
                //GetWordsValue();
                comboBox1.SelectedItem = words.GetBestGuess().GetWord();
                TrBgoodChar.Enabled = true;
            }
            else
            {
                richTextBox1.Text = "";
            }
        }

        /*private void GetWordsValue()
        {
            List<int> wordValues = new List<int>();
            wordValues = words.
            richTextBox1.Text = "";
            foreach (string i in words)
            {
                int a = 0;
                foreach (char t in i)
                {
                    a = a + GetCharValue(letters2).ElementAt<int>((int)t - 97);
                }
                wordValue.Add(a);
                richTextBox1.Text += i + '\n';
            }
            //richTextBox2.Text += '\n' + string.Join(",", wordValue.ToArray()) + '\n' + wordValue.Max().ToString() + '\n' + words.ElementAt<string>(wordValue.FindIndex(c => c == wordValue.Max()));
            //textBox2.Text = words.ElementAt<string>(wordValue.FindIndex(c => c == wordValue.Max()));
            comboBox1.SelectedIndex = comboBox1.Items.IndexOf(words.ElementAt<string>(wordValue.FindIndex(c => c == wordValue.Max())));
            BindingSource CBbinding = new BindingSource();
            CBbinding.DataSource = words;
            comboBox1.DataSource = CBbinding.DataSource;
            TrBgoodChar.Enabled = true;
        }*/

        /*private List<int> GetCharValue(List<char> letter)
        {
            List<char> abc = "abcdefghijklmnopqrstuvwxyz".Select(c => c).ToList();
            List<int> result = new List<int>();
            letter.Sort();


            foreach (Char t in abc)
            {
                List<char> u = new List<char>();
                u = letter.FindAll(v => v == t);
                result.Add(u.Count());
            }

            return result;
        }*/

        //used to show current trackbar selection in label
        private void TrBgoodChar_Scroll(object sender, EventArgs e)
        {
            label1.Text = TrBgoodChar.Value.ToString();
        }

        //makes sure "enter"-key can be used in textbox 1
        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button1.PerformClick();
                e.Handled = e.SuppressKeyPress = true;
            }
        }

        public void refreshList(List<string> list)
        {
            comboBox1.DataSource = null;
            comboBox1.Items.Clear();
            comboBox1.DataSource = list;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (button2.Text == "test solution")
            {
                //get needed info from form controlls

                int value = TrBgoodChar.Value;
                richTextBox2.Text += '\n' + value.ToString();
                //words.Remove(textBox2.Text);
                cWord word = new cWord();
                if ((string)comboBox1.SelectedItem == null)
                {
                    word.SetWord(comboBox1.Text);
                }
                else
                {
                    word.SetWord( (string)comboBox1.SelectedItem);
                }

                words.AppendSearch(word, value);

                /*
                if (words.Contains(word))
                {
                    words.Remove(word);
                }

                //get char list from word to check to and copy word list to append in

                //List<char> abc = textBox2.Text.Select(c => c).ToList();
                List<char> InputWord = word.Select(c => c).ToList();
                List<string> corr = new List<string>();
                corr = words.ToList<string>();

                //check every word in m_collection

                foreach (string i in words)
                {
                    //get char list from word to check and create bool list to find the good charsin good places
                    List<char> CheckWord = i.Select(c => c).ToList();
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

                    if (correction.FindAll(v => v == true).Count == value)
                    {

                    }

                    // if not word does not qualify than word is removes from m_collection

                    else
                    {
                        corr.Remove(i);
                    }
                }

                //appended list is merged with original list.

                words.Clear();
                words = corr.ToList<string>();

                //char values are redetermined

                letters2.Clear();
                foreach (string i in words)
                {
                    foreach (char t in i)
                    {
                        letters2.Add(t);
                    }
                }

                //word values are redetermined

                GetWordsValue();

                */

                //combobox is updated

                refreshList(words.ConvertToString());
            }

            //only used to change a word
            else if (button2.Text == "append word")
            {
                //word is removed and the mew one is added at the end of the list(arengment is of no concern.
                cWord WordToChange = new cWord((string)comboBox1.SelectedItem);
                cWord ChangeToWord = new cWord(textBox2.Text);

                words.ChangeWordTo(WordToChange, ChangeToWord);

                /*
                words.Remove(word);
                textBox1.Text = textBox2.Text;
                button1.PerformClick();
                letters2.Clear();
                foreach (string i in words)
                {
                    foreach (char t in i)
                    {
                        letters2.Add(t);
                    }
                }
                */
                
                refreshList(words.ConvertToString());
            }
        }


        // changes effect of button 2
        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                button2.Text = "test solution";
            }
            else
            {
                button2.Text = "append word";
            }
        }


        // makes sure "enter"-key can be used in textbox 2
        private void textBox2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                button2.PerformClick();
                e.Handled = e.SuppressKeyPress = true;
            }
        }
    }
}
