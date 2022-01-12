using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LA19_DicePool
{
    class PoolOfDices
    {
        //int NoOfDice { get; set; }
        //int sum = 0;
        public static void RollDice() 
        {
            char c; //To add or remove die.
            char c2 = 'Y'; //To play more or exit game.
            do
            {
                int sum = 0;
                
                Console.Write("How many dice would you like to roll?:   ");
                int noOfDice = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine($"\nYou picked {noOfDice} dice to roll.\n");

                Console.WriteLine("What are the sides of the dice: 4, 6, 8, 10, 12, or 20? " +
                                   "\nSeparate each die with ',' or space :");

                char[] chr = { ' ', ',' };
                string[] sideStr = Console.ReadLine().Split(chr);
                int[] sideArr = new int[sideStr.Length];
                int[] rolledNumArr = new int[sideArr.Length];
                int j = 0;

                for (int i = 0; i < sideStr.Length; i++)
                {
                    sideArr[i] = Int32.Parse(sideStr[i]);

                    int randNum = Dice.ADice(sideArr[i]);
                    rolledNumArr[j] = randNum;
                    //Console.Write(rolledNumArr[j]); // to made as comment
                    j++;
                    Console.WriteLine($"Your {sideArr[i]} sided dice rolled a " + randNum);

                    sum += randNum;
                }
                Console.WriteLine($"\nYou've rolled a total of {sum}.");

                Console.Write("\nDo you want to add or remove a dice? [Y/N]?:   ");
                c = Convert.ToChar(Console.ReadLine().ToUpper());

                if (c == 'Y')
                {
                    Console.Write("\nEnter 1 to add a die or 2 to remove a dice:   ");
                    int s = Convert.ToInt16(Console.ReadLine());
                    if (s == 1)
                    {
                        int a1 = Add();
                        Console.WriteLine("\nYour rolled number is: " + a1);
                        sum += a1;
                        Console.WriteLine("Your new total is: " + sum);
                    }
                    else if (s == 2)
                    {
                        int diceToRemove = Remove();
                        rolledNumArr = rolledNumArr.Where((source, index) => index != diceToRemove).ToArray();
                        int newSum = rolledNumArr.Sum();

                        Console.WriteLine($"Your new total after die #{diceToRemove} has been removal is: {newSum}");
                    }
                    
                }
                else if (c == 'N')
                {
                     break;
                }
                Console.Write("\nAnother round of dice game? [Y/N]?   ");
                c2 = Convert.ToChar(Console.ReadLine().ToUpper());

            } while (c2 != 'N');

            Console.WriteLine("\n===  Thank you for playing. Hit any key to exit.  ===");
            Console.ReadKey();

        }
       public static int Add()
       {
            Console.Write("What is the side of the dice you'd like to add?: ");
            int a = Convert.ToInt32(Console.ReadLine());
            return Dice.ADice(a); 
       }
       public static int Remove()
        {
            Console.Write("Which order# of die would you like to remove?: ");
            int r = Convert.ToInt32(Console.ReadLine());
            return r-1;
        }
    }
}
