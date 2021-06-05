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
        Dictionary<CateringItem, int> purchaseList = new Dictionary<CateringItem, int>();

        private decimal accountBalance = 0.00m;

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
                        done = true;
                        break;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        private string GetUserMenuChoice()
        {
            Console.WriteLine("(1) Display Catering Items");
            Console.WriteLine("(2) Order");
            Console.WriteLine("(3) Quit");
            string userInput = Console.ReadLine();
            Console.WriteLine("");

            return userInput;

        }
        public void DisplayList()
        {
            foreach (CateringItem i in catering.FullList)
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
                        SelectProducts();
                        break;

                    case "3":
                        CompleteTransaction();
                        return;

                    default:
                        Console.WriteLine("Please make a valid selection.");
                        Console.WriteLine();
                        break;
                }
            }
        }
        public string GetDisplayMenuChoice()
        {
            Console.WriteLine("(1) Add Money");
            Console.WriteLine("(2) Select Products");
            Console.WriteLine("(3) Complete Transaction");
            Console.WriteLine();
            Console.WriteLine("Current Account Balance: $" + accountBalance);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput;
        }

        public decimal AddMoney()
        {
            Console.WriteLine("How much money (in dollars) would you like to add?");

            try
            {
                int userInput = int.Parse(Console.ReadLine());

                if (accountBalance + userInput > 5000)
                {
                    Console.WriteLine("Cannot exceed $5,000 in account");
                    Console.WriteLine();
                    return accountBalance;
                }
                FileAccess.AuditBalance(userInput, (accountBalance + userInput));
                Console.WriteLine();
                return accountBalance += userInput;
            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter a valid Number");
                Console.WriteLine();
                return accountBalance;
            }

        }
        public void SelectProducts()
        {
            Console.WriteLine("What is the items product code?");
            string selectCode = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("What is the quantity you would like to purchase?");

            try
            {
                int selectQuantity = int.Parse(Console.ReadLine());
                Console.WriteLine();



                foreach (CateringItem i in this.catering.FullList)
                {
                    if (selectCode.ToLower() == i.Code.ToLower())
                    {
                        if (i.Ammount - selectQuantity >= 0)
                        {
                            FileAccess.AuditProduct(i, selectQuantity);
                            if (purchaseList.ContainsKey(i))
                            {
                                purchaseList[i] += selectQuantity;
                                i.Ammount -= selectQuantity;
                                return;
                            }
                            else
                            {
                                purchaseList.Add(i, selectQuantity);
                                i.Ammount -= selectQuantity;
                                return;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Sorry, insufficient amount of item.");
                            Console.WriteLine();
                            return;

                        }
                    }
                }

                Console.WriteLine("This item doesn't exist.");
                Console.WriteLine();
                return;

            }
            catch
            {
                Console.WriteLine();
                Console.WriteLine("Please Enter a valid input for item quantity");
                Console.WriteLine();
            }
        }
        public void CompleteTransaction()
        {
            decimal totalCost = 0;

            foreach (KeyValuePair<CateringItem, int> item in purchaseList)
            {
                totalCost += item.Key.Price * item.Value;
            }


            if (accountBalance < totalCost)
            {
                Console.WriteLine("Insufficient funds.");
                Console.WriteLine();
                return;
            }
            else
            {
                foreach (KeyValuePair<CateringItem, int> item in purchaseList)
                {
                    Console.WriteLine($"{item.Value} {item.Key.Type} {item.Key.Name} ${item.Key.Price} ${item.Key.Price * item.Value}");
                }
                Console.WriteLine();
                Console.WriteLine("Total: $" + totalCost);
                Console.WriteLine();

                decimal change = accountBalance - totalCost;
                Dictionary<string, decimal> money = new Dictionary<string, decimal>()
                {
                    {"Twenties,",20.00m },
                    {"Tens,",10.00m },
                    {"Fives,",5.00m },
                    {"Ones,",1.00m },
                    {"Quarters,",0.25m },
                    {"Dimes,",0.10m },
                    {"Nickles",0.05m },

                };
                Console.WriteLine();
                Console.WriteLine("Your change will be: ");

                foreach (KeyValuePair<string, decimal> i in money)
                {
                    int billCount = (int)(change / money[i.Key]);
                    Console.Write(billCount + " " + i.Key + " ");
                    change -= billCount * i.Value;
                }
                FileAccess.AuditChange();
                accountBalance = 0;
                Console.WriteLine();
                Console.WriteLine();
                return;
            }
        }
    }
}

