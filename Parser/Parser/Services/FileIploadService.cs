using Microsoft.AspNetCore.Mvc;
using Parser.Models;
using Parser.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Parser.Models;

namespace Parser.Services
{
    public class FileIploadService : IFileUploadService
    {
        IFileUploadRepository fileUploadRepository;

        public FileIploadService(IFileUploadRepository _fileUploadRepository)
        {
            fileUploadRepository = _fileUploadRepository;
        }

        public Task<ActionResult> getAll()
        {
            throw new NotImplementedException();
        }

        public async Task<ActionResult> getById(int id)
        {
            try
            {
                PageUploadTransaction result = await fileUploadRepository.getById(id);
                if (result != null)
                {
                    return new OkObjectResult(result);
                }
                else
                {
                    return new NotFoundResult();
                }
            }
            catch
            {
                return new ConflictResult();
            }

            throw new NotImplementedException();
        }

        public async Task<ActionResult> insert(PageUploadTransaction item)
        {
            try
            {
                item=await fileUploadRepository.Insert(item);
                return new OkObjectResult(item);
            }
            catch
            {
                return new ConflictResult();
            }

            throw new NotImplementedException();
        }
    }
}
