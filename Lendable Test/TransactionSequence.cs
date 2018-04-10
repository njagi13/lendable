using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lendable_Test
{
   public class TransactionSequence
    {
        public bool PrevEqual { get; set; }
        public bool NextEqual { get; set; }
        public int   Index { get; set; }
        public Transaction Item { get; set; }
    }
}
