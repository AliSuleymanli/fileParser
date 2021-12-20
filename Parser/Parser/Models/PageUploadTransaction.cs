using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Models
{
    public class PageUploadTransaction
    {
        public int Id { get; set; }
        public ICollection<MainChunk> MainChunks { get; set; } 
    }
}
