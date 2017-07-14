using System;
using System.IO;

namespace ClientsConsApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Read File
            string line;
            try
            {

                string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);

                string file = dir + @"\TextFiles\people.in";
                StreamReader sr = new StreamReader(file);


                line = sr.ReadLine();

                while (line != null)
                {
                    //write the lie to console window
                    Console.WriteLine(line);
                    //Read the next line
                    line = sr.ReadLine();
                }

                //close the file
                sr.Close();
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
            }

        }
    }
}
