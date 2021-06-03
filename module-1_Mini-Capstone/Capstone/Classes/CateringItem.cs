using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    /// <summary>
    /// This represents a single catering item in your system
    /// </summary>
    /// <remarks>
    /// NO Console statements are allowed in this class
    /// </remarks>
    public class CateringItem
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Type { get; set; }
        public int Ammount { get; set; } = 50;
        public override string ToString()
        {
            return this.Code + " " + this.Name + " $" + this.Price + " " + this.Type + " #" + this.Ammount;
        }
    }
}
