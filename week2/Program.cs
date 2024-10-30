namespace week2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("enter number of hours: ");
            int hours = Int32.Parse(Console.ReadLine());
             CalcaulateCharges(hours);
           void CalcaulateCharges(int hours)
            {
                double charges=2.00;
                if(hours<=3) 
                {
                    charges = 2.00;
                    Console.WriteLine("your charges are : " + charges);
                }
                else if(hours>3 && hours<24)
                {
                    charges = 2.00;
                    for(int i =0; i<=hours;i++)
                    {
                        charges += 0.50;
                        i++;
                    }
                    Console.WriteLine("your charges are : " + charges);
                }
                else if(hours == 24)
                {
                    charges = 10;
                    Console.WriteLine("your charges are : " + charges);

                }
            }
        }
    }
}
