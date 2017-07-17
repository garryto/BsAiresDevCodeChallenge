using System;
using System.Collections.Generic;
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

               
                string fileInput = Resources.InputFile; 


                StreamReader sr = new StreamReader(fileInput);


                line = sr.ReadLine();

                List<People> linkedIncontacts = new List<People>();

                while (line != null)
                {

                    People person = new People(line);
                    linkedIncontacts.Add(person);
                    
                    line = sr.ReadLine();
                }

               
                IComparer<People> comparer = new MyOrderingPeopleCriteria();
                linkedIncontacts.Sort(comparer);


               
                sr.Close();


                try
                {

                  
                    string fileOutput = Resources.OutputFile; 

                    StreamWriter sw = new StreamWriter(fileOutput);
                  
                    for (int i=0; i<100;i++)
                    {
                        sw.WriteLine(linkedIncontacts[i].Id);
                        // sw.WriteLine(linkedIncontacts[i].Id + " " + linkedIncontacts[i].Ranking + " " + linkedIncontacts[i].CurrentRole + " " 
                        //+ linkedIncontacts[i].Country + " " +  linkedIncontacts[i].Industry);

                    }


                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                    Console.ReadLine();
                }
               
               // Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine("Exception: " + e.Message);
                Console.ReadLine();
            }

        }
    }
}
