using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Models
{
    public class MainChunk
    {
        public MainChunk(string[] chunkBasicFieldValues, List<MainChunkDetail> chunkDetails) 
        {
            FinancialInstitution = chunkBasicFieldValues[0];
            FXSettlementDate = chunkBasicFieldValues[1];
            ReconciliationFileID = chunkBasicFieldValues[2];
            TransactionCurrency = chunkBasicFieldValues[3];
            ReconciliationCurrency = chunkBasicFieldValues[4];

            ChunkDetails = chunkDetails;
        }

        public MainChunk()
        {
                
        }

        public int Id { get; set; }
        public int PageUploadTransactionId { get; set; } 
        public string FinancialInstitution { get; set; }
        public string FXSettlementDate { get; set; }
        public string ReconciliationFileID { get; set; }
        public string TransactionCurrency { get; set; }
        public string ReconciliationCurrency { get; set; }
        public ICollection<MainChunkDetail> ChunkDetails { get; set; }
        public PageUploadTransaction PageUploadTransaction { get; set; } 

        [NotMapped]
        public MainChunkDetail total
        {
            get
            {
                MainChunkDetail Total = new MainChunkDetail();

                foreach (var detail in ChunkDetails)
                {
                    Total.TransactionAmountCredit += detail.TransactionAmountCredit;
                    Total.ReconciliationAmntCredit += detail.ReconciliationAmntCredit;
                    Total.FeeAmountCredit += detail.FeeAmountCredit;
                    Total.TransactionAmountDebit += detail.TransactionAmountDebit;
                    Total.ReconciliationAmntDebit += detail.ReconciliationAmntDebit;
                    Total.FeeAmountDebit += detail.FeeAmountDebit;
                    Total.CountTotal += detail.CountTotal;
                    Total.NetValue += detail.NetValue;
                }

                return Total;
            }   
        }
    }
}
