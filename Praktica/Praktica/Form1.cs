using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace Praktica
{
    public partial class Form1 : Form
    {
        private string filename;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {

                // получаем выбранный файл
                filename = openFileDialog1.FileName;
                // читаем файл в строку
                string fileText = File.ReadAllText(filename);
                char[] charsForEOL = { '#' };
                string resultat = "";
                textBox1.Text = fileText;

                while (fileText.Length > 0)
                {
                    for (int i = 0; i < fileText.Length; i++)
                    {
                        if (fileText.ntains(fileText[i]))
                        {
                            resultat += fileText.Substring(0, i) + "\n";
                            fileText = fileText.Substring(i + 1);
                            break;
                        }
                        if (i == fileText.Length)
                        {
                            resultat += fileText.Substring(0, fileText.Length) + "\n";
                            fileText = fileText.Substring(fileText.Length + 1);
                        }


                    }
                }

               /* do
                {
                    for (int i = 0; i < fileText.Length; i++)
                    {
                        if (charsForEOL.Contains(fileText[i]))
                        {
                            resultat += fileText.Substring(0, i) + "\n";
                            fileText = fileText.Substring(i + 1);
                            break;
                        }
                        if (i == fileText.Length)
                        {
                            resultat += fileText.Substring(0, fileText.Length) + "\n";
                            fileText = fileText.Substring(fileText.Length + 1);
                        }
                    }
                
                } while (fileText.Length > 0);

                resultat += fileText;

                textBox1.Text = resultat;

                /*for (int i = 0; i < fileText.Length; i++)
                    {

                        if (fileText[i] == '#')
                        {
                            fileText = fileText.Insert(i, "\n");
                            break;

                        }
                    }

                    textBox1.Text = fileText;
                    MessageBox.Show("Файл открыт");
                }*/

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                filename = saveFileDialog1.FileName;
                File.WriteAllText(filename, textBox1.Text);
            }
        }
    }
}
