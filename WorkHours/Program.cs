using WorkHours;
using System;

namespace WorkHours
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Starting process...");
            Payments payments = new Payments();
            payments.Process();
        }
    }
}
