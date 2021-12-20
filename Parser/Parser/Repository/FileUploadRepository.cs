using Microsoft.EntityFrameworkCore;
using Parser.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Parser.Repository
{
    public class FileUploadRepository : IFileUploadRepository
    {
        FileParserContext context;

        public FileUploadRepository(FileParserContext _context)
        {
            context = _context;
        }

        public Task<IEnumerable<PageUploadTransaction>> getAll()
        {
            throw new NotImplementedException();
        }

        public async Task<PageUploadTransaction> getById(int id)
        {
            return await context.PageUploads.Where(p => p.Id == id).Include(pp => pp.MainChunks).ThenInclude(d => d.ChunkDetails).FirstOrDefaultAsync();

            throw new NotImplementedException();
        }

        public async Task<PageUploadTransaction> Insert(PageUploadTransaction newItem)
        {
            context.Add(newItem);
            await context.SaveChangesAsync();

            return newItem;

            throw new NotImplementedException();
        }
    }
}
