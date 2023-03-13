using API.Models;
using System.Collections.Generic;

namespace API.IServices
{
    public interface IFileService
    {
        // post method 
        int InsertFile(FileItem fileItem);
        List<FileIdentifierModel> InsertFiles(List<FileItem> fileItemList);
        void DeleteFile(int id);
        FileItem GetFileById(int id);
        List<FileItem> GetFilesByCriteria(FileSearchCriteria fileSearchCriteria);
    }
}
