using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SQL
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name = "test.db";
            Console.WriteLine($"Попытка создать базу {name}");
            Console.WriteLine(); DBWork.MakeDB(name);
        }
    }
}
