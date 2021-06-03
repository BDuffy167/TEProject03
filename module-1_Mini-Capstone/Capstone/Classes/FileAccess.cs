using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain any and all details of access to files
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class FileAccess
    {
        // All external data files for this application should live in this directory.
        // You will likely need to create this directory and copy / paste any needed files.

        private string filePath = @"C:\Catering\cateringsystem.csv";
        private Catering catering;
        public FileAccess(Catering catering)
        {
            this.catering = catering;
        }


        public void GenerateList()
        {
            try
            {
                using (StreamReader reader = new StreamReader(filePath))
                {
                    while (!reader.EndOfStream)
                    {
                        string item = reader.ReadLine();
                        
                        catering.AddItem(item);
                    }

                }
            }
            catch
            {

            }
        }

    }
}







