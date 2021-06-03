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

        public void GenerateList()
        {
            try
            {
                using (StreamReader reader = new StreamReader(FileAccess.fullPath))
                {

                }
            }
        }

   
    }
}
