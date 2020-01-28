using System;
using System.IO;
using System.Text;
using System.Windows.Forms;


namespace assessement
{

    public partial class Form2 : Form
    {
        public int count = 1;
        public static string id1;
        public Form2()
        {
            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 openform = new Form1();
            openform.Show();
            Visible = false;

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            System.Windows.Forms.Application.Exit();
            


        }


        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            string path = Program.path;
            string text = File.ReadAllText(path, Encoding.UTF8);
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
                    string password = Decrypt(a[4], 13);
                    if (textBox1.Text == a[1] && textBox2.Text == password)
                    {
                        
                        id1 = a[0];
                        Menu openform = new Menu();
                        openform.Show();
                        Visible = false;
                    }
                    else if (count < 3)
                    {
                        count++;
                    }
                    else
                    {
                        MessageBox.Show("Error message");
                        System.Windows.Forms.Application.Exit();
                    }

                }
                streamReader.Close();

            }
            




        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

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
