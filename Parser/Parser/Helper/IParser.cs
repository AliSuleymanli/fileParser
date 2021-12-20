using Parser.Models;
using System.Collections.Generic;

namespace Parser.Helper
{
    public interface IParser
    {
        PageUploadTransaction readFromFileToList(string path);
    }
}