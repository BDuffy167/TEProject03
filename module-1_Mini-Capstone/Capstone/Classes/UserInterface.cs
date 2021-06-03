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
        private Catering catering = new Catering();
        public FileAccess FileAccess { get; set; }
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

        }
    }
}
