using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Models
{
    public class MainChunkDetail
    {
        public MainChunkDetail(string[] chunkDetailFields)
        {
            SettlementCategory = chunkDetailFields[1];
            TransactionAmountCredit =Convert.ToDouble(chunkDetailFields[2]);
            ReconciliationAmntCredit = Convert.ToDouble(chunkDetailFields[3]);
            FeeAmountCredit = Convert.ToDouble(chunkDetailFields[4]);
            TransactionAmountDebit = Convert.ToDouble(chunkDetailFields[5]);
            ReconciliationAmntDebit = Convert.ToDouble(chunkDetailFields[6]);
            FeeAmountDebit = Convert.ToDouble(chunkDetailFields[7]);
            CountTotal = Convert.ToInt32(chunkDetailFields[8]);
            NetValue = Convert.ToDouble(chunkDetailFields[9]);
        }

        public MainChunkDetail()
        {

        }

        public int Id { get; set; }
        public int MainChunkId { get; set; } 
        public string SettlementCategory { get; set; }
        public double TransactionAmountCredit { get; set; }
        public double ReconciliationAmntCredit { get; set; }
        public double FeeAmountCredit { get; set; }
        public double TransactionAmountDebit { get; set; }
        public double ReconciliationAmntDebit { get; set; }
        public double FeeAmountDebit { get; set; }
        public int CountTotal { get; set; }
        public double NetValue { get; set; }
        public MainChunk MainChunk { get; set; } 

    }
}
