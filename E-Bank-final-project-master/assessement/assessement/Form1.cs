using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace assessement
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void Label1_Click(object sender, EventArgs e)
        {

        }
        private void TextBox5_TextChanged(object sender, EventArgs e)
        {

        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
        private void TextBox2_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            string path = Program.path; 
            File.AppendAllText(path, "");
            //random amount of money from 0 to 100000
            string randommoney1 = randommoney();
            //encrypt password
            string encryption = Encrypt(textBox4.Text, 13);
            //unique id
            string ID = generateID();
            //
            bool unique = uniquename(textBox1.Text, path);
            bool validate = validation(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text);
            if (textBox1.Text.Length < 6 || textBox1.Text.Length > 20 || textBox2.Text.Length <= 3 || textBox3.Text.Length <= 3 || textBox4.Text.Length <= 8 || textBox4.Text.Length > 25 || !validate)
            {
                PasswordError();
            }
            else if (!unique)
            {
                nameExists();
            }
            else
            {
                appendlines(ID, textBox1.Text, textBox2.Text, textBox3.Text, encryption, randommoney1, path);
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            System.Windows.Forms.Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Form2 openform = new Form2();
            openform.Show();
            Visible = false;
        }
        private static bool is_only_eng_letters_and_digits(string str)
        {
            foreach (char ch in str)
            {
                if (!(ch >= 'A' && ch <= 'Z') && !(ch >= 'a' && ch <= 'z') && !(ch >= '0' && ch <= '9'))
                {
                    return false;
                }
            }
            return true;
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
        private bool IsFirstNumber(string str)
        {
            try
            {
                if (!char.IsNumber(str[0]))
                    return true;
                return false;

            }
            catch (Exception)
            {

                MessageBox.Show("Please fill username box");
                return true;
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Character length must be greater than 8 and less than 26 \n There must be at least one capital letter \n There must be at least one small letter \n There must be at least one Digit" +
                " \n There must be at least one symbol of the following (!”#$%&’()*+-/:;<=>?@[\\]^_`{|}~ )\nThere should be no data from the user's name, surname, username ");
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
        public static bool panumber(string str)
        {
            string specialChar = @"1234567890";
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
            string text1 = Text.ToUpper();
            string word1 = Word.ToUpper();
            if (text1.Contains(word1))
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
        public string generateID()
        {
            return Guid.NewGuid().ToString().GetHashCode().ToString("x");
        }
        private bool uniquename(string str, string path)
        {
            try
            {
                string text = File.ReadAllText(path, Encoding.UTF8);
                if (text.Contains(str))
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                MessageBox.Show("Error");
                return false;
            }
        }
        public void appendlines(string ID, string text1, string text2, string text3, string encry, string money, string path)
        {
            string content = ID + "," + text1 + "," + text2 + "," + text3 + "," + encry + "," + money;
            File.AppendAllText(path, content + "\n");
            Form2 openform = new Form2();
            openform.Show();
            Visible = false;
        }
        public void PasswordError()
        {
            MessageBox.Show("Username must be between 7 and 19 character \n Fill every space \n Username must start with letter" +
                    " \n Only latin characters are allowed \n Firt name must be more than 3 characters \n Last name must be more than 3 characters" +
                                                                              " \n First name and Last name must contain only letters");
        }
        public void nameExists()
        {
            MessageBox.Show("Username already exist");
            
        }
        public string randommoney()
        {
            //random amount of money from 0 to 100000
            Random r = new Random();
            int money = r.Next(100001);
            string randommoney = money.ToString();
            return randommoney;
        }
        public bool validation(string text1, string text2, string text3, string text4)
            {
              if (!is_only_eng_letters_and_digits(text1) || !firstnameandlastname(text2) || !firstnameandlastname(text3) || !IsFirstNumber(text1) || !hasSpecialChar(text4) || !HasCapitalsDigitsLowers(text4)
                  || !Contains(text4, text1) || !Contains(text4, text2) || !Contains(text4, text3))
              {
                  return false;
              }
              else
              {
                  return true;
              }

        }
    }
}
