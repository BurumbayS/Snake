using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example3.Models
{
    [Serializable]
    public class Food : Drawer
    {
        public Food()
        {
            color = ConsoleColor.Green;
            sign = '@';
        }
    }
}
