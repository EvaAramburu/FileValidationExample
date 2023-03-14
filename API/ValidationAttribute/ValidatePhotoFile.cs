using API.Models;
using FileManagerExample.ValidationAttributes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Formatters;
using System.ComponentModel.DataAnnotations;
using System.Net.Mime;
using static System.Net.Mime.MediaTypeNames;

namespace API.ValidationAttributes
{
    public class ValidatePhotoFile : ValidationAttribute
    {
        private readonly double pesoArchivoKb;
        private readonly string[] tiposValidos;
        public ValidatePhotoFile(string[] tiposValidos)
        {
            this.tiposValidos = tiposValidos;
        }

        public ValidatePhotoFile(TipoArchivo tipoArchivo)
        {
            if (tipoArchivo == TipoArchivo.Image)
            {
                tiposValidos = new[] { "image/png", "image/jpeg" };
            }
        }
        public ValidatePhotoFile(FileUploadModel fileUploadModel) 
        {
            if (fileUploadModel.File.ContentType != MediaTypeNames.Image.Jpeg.ToString())
            {
                return new ValidationResult
                    ($"Los tipos válidos son + " +
                    $"{string.Join(",", tiposValidos)}");
            }
            if(fileUploadModel.File.Length / 1024 > pesoArchivoKb)
            {
                return new ValidationResult
               ($"El peso del archivo que enviaste es " +
               $"{fileUploadModel.File.Length }Kb " +
               $"y supera el máximo permitido de " +
               $"{pesoArchivoKb}Kb");
            }
        }
       
        
    }
}
