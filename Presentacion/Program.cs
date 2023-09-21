using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UPC__;

namespace Presentacion
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var liquidacionGUI = new LiquidacionGUI();
            liquidacionGUI.Menu();
            Despedida();
        }

        private static void Despedida()
        {
            Console.Clear();
            Console.WriteLine("gracias por usar productos JOHNP");
            Console.ReadKey();

        }
    }
}
