using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task1;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer timer = new Timer();

            MobilePhone mobilePhone = new MobilePhone();
            mobilePhone.Register(timer);

            Pager pager = new Pager();
            pager.Register(timer);

            Console.WriteLine("Start");
            timer.SimulateNewTimer( 4, "Hi");
        }
    }
}
