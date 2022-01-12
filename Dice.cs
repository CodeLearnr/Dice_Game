using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA19_DicePool
{
    class Dice
    {
        private int _randNoDie1;
        public int RandNoDie1 { get; set; } 
        public static int ADice(int side) 
        {
            Random rolledNum = new Random();
            return rolledNum.Next(1, side + 1);
        }

       
       



    } 
}
