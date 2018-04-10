using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lendable_Test
{
    public class TransactionHandler
    {
        public void ReadTransactions(string path, int take)
        {
            List<Transaction> values = File.ReadAllLines(path)
                                       .Skip(1)
                                       .Select(v => Transaction.FromCsv(v))
                                       .OrderBy(o => o.customer_id).ThenBy(o => o.transaction_date)
                                       .ToList();

            DateTime lastDateTime = new DateTime();
            int defaultIncVal = 0;
            for (int i = 0; i < values.Count; i++)
            {
                
                double daysDiff = 0;
                if (i == 0)
                {
                    lastDateTime = values[0].transaction_date;
                    values[0].transaction_val = defaultIncVal;
                }
                else
                {
                    var previous = values[i - 1];
                    if (previous.customer_id != values[i].customer_id)
                    {
                        daysDiff = 0;
                    }
                    else
                    {
                        daysDiff = values[i].transaction_date.Date.Subtract(lastDateTime.Date).TotalDays;
                    }

                    int dateDiffInt = (int)Math.Floor(daysDiff);
                    if (dateDiffInt == 1)
                    {
                        values[i].transaction_val = defaultIncVal;
                    }
                    else
                    {
                        defaultIncVal = defaultIncVal + 1;
                        values[i].transaction_val = defaultIncVal;
                    }
                    lastDateTime = values[i].transaction_date;
                }
            }

            var seq = values;
            int count = seq.Count();
            var maxSeq = seq
                .Select((i, index) => new TransactionSequence
                {
                    Item = i,
                    Index = index,
                    PrevEqual = index == 0 || seq.ElementAt(index - 1).transaction_val == i.transaction_val,
                    NextEqual = index == count - 1 || seq.ElementAt(index + 1).transaction_val == i.transaction_val,
                })
                .Where(x => x.PrevEqual || x.NextEqual)
                .GroupBy(x => x.Item.transaction_val)
                .OrderByDescending(g => g.Count()).Take(take).ToList();
            Console.Write(string.Join(",", maxSeq.Select(i => i.FirstOrDefault().Item.customer_id).Distinct().ToList()));

            Console.ReadLine();
        }


    }
}
