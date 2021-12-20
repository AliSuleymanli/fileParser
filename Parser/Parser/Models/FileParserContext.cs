using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Models
{
    public class FileParserContext :DbContext
    {
        public FileParserContext(DbContextOptions<FileParserContext> options) : base(options) { }

        public DbSet<PageUploadTransaction> PageUploads { get; set; }
        public DbSet<MainChunk> MainChunks { get; set; }
        public DbSet<MainChunkDetail> MainChunkDetails { get; set; }
    }

    
}
