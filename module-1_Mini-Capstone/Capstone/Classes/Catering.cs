using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
namespace Capstone.Classes
{
    /// <summary>
    /// This class should contain all the "work" for catering
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class Catering
    {
        private List<CateringItem> items = new List<CateringItem>();

        public List<CateringItem> FullList
        {
            get
            {
                return items;
            }
        }

        public void AddItem(string item)
        {
            try
            {
                string[] itemAdded = item.Split('|');
                CateringItem newItem = new CateringItem();
                newItem.Code = itemAdded[0];
                newItem.Name = itemAdded[1];
                newItem.Type = itemAdded[3];
                newItem.Price = decimal.Parse(itemAdded[2]);

                items.Add(newItem);
            }
            catch (IndexOutOfRangeException ex)
            {
                Console.WriteLine("Item manifest is formatted incorrectly. Please quit and fix before using.");
            }
            }

    }
}
