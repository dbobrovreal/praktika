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

namespace Proekt
{
    public partial class Form1 : Form
    {
        private string outfile;
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // получаем выбранный файл
                string filename = openFileDialog1.FileName;
                // читаем файл в строку
                string fileText = File.ReadAllText(filename);
                string token = "";
                outfile = "";
                
                for (int i = 0; i < fileText.Length; i++)
                {
                    if(fileText[i] == '#')
                    {
                        outfile += token;
                        outfile += " ";
                        token = "";
                        token = "#";
                        continue;
                    }
                    if (fileText[i] != ',')
                    {
                        token += fileText[i];
                    }
                    else
                    {
                        if (token == "#EXTINF:-1")
                        {

                            outfile += "\n";
                            outfile += token;
                            outfile += " ";
                            outfile += "group-title=\"Эфирные HD\", ";
                            token = "";

                        }
                        else
                        {
                            outfile += token;
                            outfile += " ";
                            token = "";
                        }
                    }
                }
                textBox1.Text = outfile;
                //textBox1.Text = fileText;
                MessageBox.Show("Файл открыт");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                outfile = saveFileDialog1.FileName;
                File.WriteAllText(outfile, textBox1.Text);
            }
        }
    }
}
