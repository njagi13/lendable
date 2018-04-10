using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lendable_Test
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                TransactionHandler handler = new TransactionHandler();
                handler.ReadTransactions("G:\\Project\\ex\\Lendable Coding Assessment - Reliable Customers\\transaction_data_3.csv", 3);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
                Console.ReadLine();
            }
        }
    }
}
