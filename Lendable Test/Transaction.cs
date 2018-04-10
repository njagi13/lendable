using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lendable_Test
{
   public class Transaction
    {

        public string customer_id { get; set; }
        public int transaction_amount { get; set; }
        public DateTime transaction_date { get; set; }

        public int transaction_val { get; set; }

        public static Transaction FromCsv(string csvLine)
        {
            string[] values = csvLine.Split(',');
            Transaction transactions = new Transaction();
            transactions.customer_id = Convert.ToString(values[0]);
            transactions.transaction_amount = Convert.ToInt32(values[1]);
            transactions.transaction_date = Convert.ToDateTime(values[2]);
          
            return transactions;
        }
    }
}
