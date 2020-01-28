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
    public partial class Form7 : Form
    {
        public Form7()
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
            const Int32 BufferSize1 = 128;
            using (var fileStream1 = File.OpenRead(path))
            using (var streamReader1 = new StreamReader(fileStream1, Encoding.UTF8, true, BufferSize1))
            {


                String line1;
                try
                {
                    while ((line1 = streamReader1.ReadLine()) != null)
                    {
                        try
                        {

                            string[] a;
                            char[] splitchar = { ',' };
                            a = line1.Split(splitchar);
                            if (a[0] == Form2.id1)
                            {
                                string text = File.ReadAllText(path);
                                //at least one speacial character
                                bool passSpecialchar = hasSpecialChar(textBox1.Text);
                                //at least one digit, one upper and one lower
                                bool DigitUpperLower = HasCapitalsDigitsLowers(textBox1.Text);
                                //Check if password contains the username, password and lastname
                                bool usernamepass = Contains(textBox1.Text, a[1]);
                                bool namepass = Contains(textBox1.Text, a[2]);
                                bool lastnamepass = Contains(textBox1.Text, a[3]);
                                //encrypt password
                                string encryption = Encrypt(textBox1.Text, 13);
                                streamReader1.Close();
                                if (textBox1.Text == textBox2.Text)
                                {
                                    if (passSpecialchar == true && DigitUpperLower == true && usernamepass == true && namepass == true && lastnamepass == true && textBox1.Text.Length>8 && textBox1.Text.Length <26 )
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

                                                        string[] a1;
                                                        char[] splitcha1r = { ',' };
                                                        a1 = line.Split(splitchar);
                                                        if (a[0] == Form2.id1)
                                                        {
                                                            
                                                            streamReader.Close();
                                                            string text1 = File.ReadAllText(path);
                                                            text1 = text1.Replace(a1[0] + "," + a1[1] + "," + a1[2] + "," + a1[3] + "," + a1[4] + "," + a1[5], a1[0] + "," + a1[1] + "," + a1[2] + "," + a1[3] + "," + encryption + "," + a1[5]);
                                                            File.WriteAllText(path, text1);
                                                            MessageBox.Show("Password Changed");
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
                                    else
                                    {
                                        MessageBox.Show("Please make sure that password meet the requirements ");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please confirm your new password!");
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


               
                
            }
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }
        public static bool hasSpecialChar(string str)
        {
            string specialChar = @"!”#$%&’()*+-/:;<=>?@[\]^_`{|}~";
            foreach (var item in specialChar)
            {
                if (str.Contains(item)) return true;
            }

            return false;
        }
        private bool HasCapitalsDigitsLowers(string str)
        {
            foreach (char c in str)
            {
                if (char.IsUpper(c) && char.IsLower(c) && char.IsDigit(c)) return false;
            }

            return true;
        }
        private bool Contains(string Text, string Word)
        {
            if (Text.Contains(Word))
                return false;
            return true;
        }
        public static char cipher(char ch, int key)
        {
            if (!char.IsLetter(ch))
            {

                return ch;
            }

            char d = char.IsUpper(ch) ? 'A' : 'a';
            return (char)((((ch + key) - d) % 26) + d);

        }

        static string Encrypt(string value, int shift)
        {
            string output = string.Empty;

            foreach (char ch in value)
                output += cipher(ch, shift);

            return output;
        }
        static string Decrypt(string value, int shift)
        {
            return Encrypt(value, 26 - shift);
        }

        
    }
}
