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

        DateTime now = DateTime.Now;
        private string filePath = @"C:\Catering\cateringsystem.csv";
        string dataFile = @"C:\Catering\Log.txt";
        private Catering catering;

        private decimal fileBalance { get; set; } = 0.00m;

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
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Please quit and fix input file path.");
            }
        }
        public void AuditBalance(decimal money, decimal balance)
        {
            fileBalance += balance;

            try
            {
                using (StreamWriter dataOutput = new StreamWriter(dataFile, true))
                {

                    dataOutput.WriteLine($"{DateTime.Now} ADD MONEY: ${money} ${fileBalance}");


                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AuditProduct(CateringItem item, int amount)
        {
            fileBalance -= item.Price * amount;
            try
            {
                using (StreamWriter dataOutput = new StreamWriter(dataFile, true))
                {
                    dataOutput.WriteLine($"{DateTime.Now} {amount} {item.Name} {item.Code} ${amount * item.Price} ${fileBalance}");
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        public void AuditChange()
        {
            try
            {
                using (StreamWriter dataOutput = new StreamWriter(dataFile, true))
                {
                    dataOutput.WriteLine($"{DateTime.Now} GIVE CHANGE: ${fileBalance} $0.00");
                }
                fileBalance = 0;
            }
            catch (IOException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}







