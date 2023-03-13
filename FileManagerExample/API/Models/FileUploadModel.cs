using API.Enums;
using FileManagerExample.ValidationAttributes;
using Microsoft.AspNetCore.Http;

namespace API.Models
{
    public class FileUploadModel
    {
        [ExtensionArchivo(TipoArchivo.Image)]

        [PesoArchivo(1024)]
        public IFormFile File { get; set; }
        public FileExtensionEnum FileExtension { get; set; }

    }

 
}
