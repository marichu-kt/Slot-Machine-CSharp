using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Slot_Machine_CSharp_UFV
{
    internal class Program
    {
        static void Main(string[] args)
        {
            SlotMachine slotMachine = new SlotMachine();
            slotMachine.MenuPrincipal();
            Console.ReadKey();
        }
    }
}
