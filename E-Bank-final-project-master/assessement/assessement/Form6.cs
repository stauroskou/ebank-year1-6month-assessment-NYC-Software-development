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

namespace assessement
{
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 openform = new Form4();
            openform.Show();
            Visible = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Program.path;
            string text = File.ReadAllText(path);
            bool lastname = firstnameandlastname(textBox2.Text);
            if (textBox1.Text == textBox2.Text && textBox1.Text.Length >3)
            {
                if (lastname == true)
                {
                    const Int32 BufferSize = 128;
                    using (var fileStream = File.OpenRead(path))
                    using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
                    {


                        String line;
                        try
                        {
                            while ((line = streamReader.ReadLine()) != null)
                            {
                                try
                                {

                                    string[] a;
                                    char[] splitchar = { ',' };
                                    a = line.Split(splitchar);
                                    if (a[0] == Form2.id1)
                                    {
                                        //int x = 0;
                                        //Int32.TryParse(textBox1.Text, out x);
                                        //int y = 0;
                                        //Int32.TryParse(a[5], out y);
                                        //x += y;
                                        //string i = x.ToString();
                                        streamReader.Close();
                                        string text1 = File.ReadAllText(path);
                                        text1 = text1.Replace(a[0] + "," + a[1] + "," + a[2] + "," + a[3] + "," + a[4] + "," + a[5], a[0] + "," + a[1] + "," + a[2] + "," + textBox1.Text + "," + a[4] + "," + a[5]);
                                        File.WriteAllText(path, text1);
                                        MessageBox.Show("Surname changed");
                                        Form4 openform = new Form4();
                                        openform.Show();
                                        Visible = false;

                                    }
                                }
                                catch (Exception)
                                {


                                }
                            }

                        }
                        catch (Exception)
                        {


                        }
                    }
                }



            }
            else
            {

                  MessageBox.Show("Please confirm your new surname!");
            }
        }
        private static bool firstnameandlastname(string str)
        {
            foreach (char ch in str)
            {
                if (!(ch >= 'A' && ch <= 'Z') && !(ch >= 'a' && ch <= 'z'))
                {
                    return false;
                }
            }
            return true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
