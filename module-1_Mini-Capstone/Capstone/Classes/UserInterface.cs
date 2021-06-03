using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This class provides all user communications, but not much else.
    /// All the "work" of the application should be done elsewhere
    /// </summary>
    /// <remarks>
    /// ALL instances of Console.ReadLine and Console.WriteLine in your application should be in this class
    /// </remarks>
    public class UserInterface
    {
        private decimal accountBalance = 0;

        private Catering catering;
        public FileAccess FileAccess { get; set; }
        public UserInterface()
        {
            this.catering = new Catering();
            this.FileAccess = new FileAccess(catering);
            FileAccess.GenerateList();
        }

        public void RunInterface()
        {
            bool done = false;

            while (!done)
            {
                string userInput = GetUserMenuChoice();
                switch (userInput.ToLower())
                {
                    case "1":
                        DisplayList();
                        break;

                    case "2":
                        DisplayPurchaseMenu();
                        break;

                    case "3":

                        break;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
            }
        }
        private string GetUserMenuChoice()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            Console.WriteLine("");
            string userInput = Console.ReadLine();
            Console.WriteLine("");

            return userInput;

        }
        public void DisplayList()
        {
            foreach (CateringItem i in catering.Ughhhh)
            {
                Console.WriteLine(i);
            }
            Console.WriteLine();
        }

        public void DisplayPurchaseMenu()
        {
            

            

            bool keepGoing = true;
            while (keepGoing)
            {
                string userInput = GetDisplayMenuChoice();

                switch (userInput.ToLower())
                {
                    case "1":
                        AddMoney();
                        break;

                    case "2":
                        //SelectProducts();
                        break;

                    case "3":
                        keepGoing = false;
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        break;
                }
            }
        }
        public string GetDisplayMenuChoice()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine("Current Account Balance: $" + accountBalance);
            Console.WriteLine();
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput;
        }

        public decimal AddMoney()
        {
            Console.WriteLine("How much money (in dollars) would you like to add?");
            int userInput = int.Parse(Console.ReadLine());
            
            if (accountBalance + userInput > 5000)
            {
                Console.WriteLine("Cannot exceed $5,000 in account");
                Console.WriteLine();
                return accountBalance;
            }
            return accountBalance += userInput;
            
        }
    }
}

