using API.IServices;
using API.Models;
using API.ValidationAttributes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using System;
using System.IO;
using System.Net.Mime;

namespace API.Controllers
{
    [ApiController]
    [Route("[controller]/[action]")]
    public class FileController
    {
        private readonly IFileService _fileService;
        private object fileUploadModel;

        public FileController(IFileService fileService)
        {
            _fileService = fileService;
        }

        [HttpPost(Name = "PostFile")]
        public int PostFile([FromForm] FileUploadModel fileUploadModel)
        {
            try
            {
                ValidatePhotoFile(fileUploadModel.File);
                var fileItem = new FileItem();
                fileItem.Id = 0;
                fileItem.Name = fileUploadModel.File.FileName;
                fileItem.InsertDate = DateTime.Now;
                fileItem.UpdateDate = DateTime.Now;
                fileItem.FileExtension = fileUploadModel.FileExtension;

                using (var stream = new MemoryStream())
                {
                    fileUploadModel.File.CopyTo(stream);
                    fileItem.Content = stream.ToArray();
                }

                return _fileService.InsertFile(fileItem);
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void ValidatePhotoFile(IFormFile file)
        {
            throw new NotImplementedException();
        }

        [HttpGet(Name = "GetFileById")]
        public FileStreamResult GetFileById(int id)
        { 
            try
            {
      
                var fileItem = _fileService.GetFileById(id);
                var stream = new MemoryStream(fileItem.Content);
                var mimeType = MediaTypeNames.Image.Jpeg.ToString();
                return new FileStreamResult(stream, new MediaTypeHeaderValue(mimeType))
                {
                    FileDownloadName = fileItem.Name
                };
            }
            catch (Exception)
            {
                throw;
            }
        }
       
    }
}
