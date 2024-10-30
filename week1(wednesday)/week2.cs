using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace week1_wednesday_
{
    internal class week2
    {
        static void Main(String[] args)
        {
            Console.WriteLine("Enter Customer type: ");
            string customerType = Console.ReadLine().ToUpper();
            Console.WriteLine("please enter the amount:");
            double amount = double.Parse( Console.ReadLine());
            if( customerType == "R")
            {
                if (amount >= 250)
                {
                    double discountedAmount = amount * .25;
                    Console.WriteLine("discount percent : 25%");
                    Console.WriteLine("Discounted amount :\n$" + discountedAmount);
                    Console.WriteLine("Total is : $" + amount + discountedAmount);
                }
                else if(amount>=100 &&  amount<=250)
                {
                    double discountedAmount = amount * .10;
                    Console.WriteLine("dicount percent : 10%");
                    Console.WriteLine("Discounted amount :\n$" + discountedAmount);
                    Console.WriteLine("Total is : $" + amount + discountedAmount);
                }
                else
                {
                    Console.WriteLine("dicount percent : 0%");
                    //Console.WriteLine("Discounted amount :\n$" + discountedAmount);
                    Console.WriteLine("Total is : $" + amount );
                }
            }else if( customerType == "C") {
                if (amount >= 250)
                {
                    double discountedAmount = amount * .30;
                    Console.WriteLine("discount percent : 30%");
                    Console.WriteLine("Discounted amount :\n$" + discountedAmount);
                    Console.WriteLine("Total is : $" + amount + discountedAmount);
                }
                else if ( amount < 250)
                {
                    double discountedAmount = amount * .20;
                    Console.WriteLine("dicount percent : 20%");
                    Console.WriteLine("Discounted amount :\n$" + discountedAmount);
                    Console.WriteLine("Total is : $" + amount + discountedAmount);
                }
            }

        }
            
    }
}
