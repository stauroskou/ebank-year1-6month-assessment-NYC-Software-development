using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace assessement
{
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Form2 openform = new Form2();
            openform.Show();
            Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string path = Program.path;
            string text = File.ReadAllText(path);
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
                                int x = 0;
                                Int32.TryParse(textBox1.Text, out x);
                                int y = 0;
                                Int32.TryParse(a[5], out y);
                                if (x<0)
                                {
                                    MessageBox.Show("Positive amount only");
                                }
                                else
                                {
                                    x += y;
                                    string i = x.ToString();
                                    streamReader.Close();
                                    string text1 = File.ReadAllText(path);
                                    text1 = text1.Replace(a[0] + "," + a[1] + "," + a[2] + "," + a[3] + "," + a[4] + "," + a[5], a[0] + "," + a[1] + "," + a[2] + "," + a[3] + "," + a[4] + "," + i);
                                    File.WriteAllText(path, text1);
                                }
                                
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

                {



                }
                streamReader.Close();

            }
            

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {





        }
        //private void replace(string path, string word1, string word2)
        //{
        //    File.WriteAllText(path, File.ReadAllText(path).Replace(word1, word2));
        //}

        private void button3_Click(object sender, EventArgs e)
        {
            string path = Program.path;
            const Int32 BufferSize = 128;
            using (var fileStream = File.OpenRead(path))
            using (var streamReader = new StreamReader(fileStream, Encoding.UTF8, true, BufferSize))
            {
                String line;
                while ((line = streamReader.ReadLine()) != null)
                {
                    string[] a = null;
                    char[] splitchar = { ',' };
                    a = line.Split(splitchar);
                    if (a[0] == Form2.id1)
                    {
                        MessageBox.Show("Your Balance:" + a[5]+"EUR");
                    }
                }
                streamReader.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string path = Program.path;
            string text = File.ReadAllText(path);
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
                                int x = 0;
                                Int32.TryParse(textBox1.Text, out x);
                                int y = 0;
                                Int32.TryParse(a[5], out y);
                                
                                if (x < 0)
                                {
                                    MessageBox.Show("Positive amount only");
                                }
                                else if (x > y)
                                {
                                    MessageBox.Show("You dont have that amount of money");
                                }
                                else
                                {
                                    y -= x;
                                    string i = y.ToString();
                                    streamReader.Close();
                                    string text1 = File.ReadAllText(path);
                                    text1 = text1.Replace(a[0] + "," + a[1] + "," + a[2] + "," + a[3] + "," + a[4] + "," + a[5], a[0] + "," + a[1] + "," + a[2] + "," + a[3] + "," + a[4] + "," + i);
                                    File.WriteAllText(path, text1);
                                }

                                
                                
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

                {



                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form4 openform = new Form4();
            openform.Show();
            Visible = false;
        }
    }
}