using System;
using System.IO;
using System.Windows.Forms;

namespace assessement
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {

            //String path = @"C:\Users\Stauroskou\Desktop\Assessment.csv";
            //string array = "ID,USERNAME,FIRSTNAME,LASTNAME \n";
            //File.Create(path);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form2());

        }
        public static string path = "UserData.csv";
        
    }
}
