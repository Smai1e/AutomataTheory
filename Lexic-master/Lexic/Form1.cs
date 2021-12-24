using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Lexic
{
    public partial class Form1 : Form
    {

        MyHashSet items = new MyHashSet();
        public Form1()
        {
            InitializeComponent();
        }

        Dictionary<string, string> parts = new Dictionary<string, string>();
        private List<string> lex = new List<string>();

        private void Write(string subText, enumType type)
        {
            if (subText.Length > 0)
                items.push(new Item(subText, type));
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lex.Clear();
            parts = new Dictionary<string, string>();
            enumType type = enumType.Try;

            int i = 0;
            string subText = "";
            foreach (char s in textBox1.Text + " ")
            {
                if (Lexema.IsTry(subText) &&
                    (s == ' '))
                {
                    type = enumType.Try;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.IsCatch(subText) &&
                    (s == ' '))
                {
                    type = enumType.Catch;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.IsArithmOperator(subText) &&
                    (s == ' ' || s == '(' || Char.IsDigit(s) || Char.IsLetter(s)))
                {
                    type = enumType.Oper;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.IsEquals(subText) &&
                    (s == ' ' || s == '(' || Char.IsDigit(s) || Char.IsLetter(s)))
                {
                    type = enumType.Equals;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.IsNumber(subText) &&
                    (s == ' ' || s == ';' || s == ')'))
                {
                    type = enumType.Number;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.CanBeVariable(subText) &&
                    (s == ' ' || s == '<' || s == '>' || s == ';' ||
                    s == '+' || s == '-' || s == '*' || s == '/'))
                {
                    type = enumType.Variable;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.IsSemicolon(subText))
                {
                    type = enumType.Semicolon;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (Lexema.IsBracket(subText) && s == ' ')
                {
                    type = enumType.Bracket;
                    Write(subText, type);

                    i++;
                    parts.Add(i.ToString() + " " + subText, type.ToString());
                    lex.Add($"<{type}>");
                    subText = "";
                }
                else if (subText == Environment.NewLine || subText == " ")
                {
                    subText = "";
                }

                subText += s;
            }

            string[] pr;
            textBox2.Clear();
            dataGridView1.Rows.Clear();
            foreach (KeyValuePair<string, string> pair in parts)
            {
                pr = pair.Key.Split(' ');
                dataGridView1.Rows.Add(pr[0], pr[1], $"<{pair.Value}>");
            }

            string buf = string.Empty;
            foreach (string s in lex)
            {
                buf += s;
            }
            textBox2.Text = buf;


            richTextBox1.SelectAll();
            richTextBox1.SelectionAlignment = HorizontalAlignment.Center;
            if (Syntax.Check(lex))
            {
                richTextBox1.Text = "Success";
                richTextBox1.SelectionStart = 0;
                richTextBox1.SelectionLength = buf.Length;
                richTextBox1.SelectionColor = Color.Green;
            }
            else
            {
                richTextBox1.Text = "Error";
                richTextBox1.SelectionStart = 0;
                richTextBox1.SelectionLength = buf.Length;
                richTextBox1.SelectionColor = Color.Red;
            }






        }
    }
}
