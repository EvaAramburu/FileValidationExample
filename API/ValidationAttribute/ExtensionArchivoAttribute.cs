using System.ComponentModel.DataAnnotations;

namespace FileManagerExample.ValidationAttributes
{
    public class ExtensionArchivoAttribute : ValidationAttribute
    {
        private readonly string[] tiposValidos;
        public ExtensionArchivoAttribute(string[] tiposValidos) 
        {
            this.tiposValidos = tiposValidos;
        }

        public ExtensionArchivoAttribute(TipoArchivo tipoArchivo)
        {
            if(tipoArchivo == TipoArchivo.Image)
            {
                tiposValidos = new[] { "image/png", "image/jpeg" };
            }
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formfile = value as IFormFile;
            if (formfile != null)
            {
                if (!tiposValidos.Contains(formfile.ContentType))
                {
                    return new ValidationResult($"Los tipos válidos son + {string.Join(",", tiposValidos)}");
                }
            }
            return ValidationResult.Success;
        }
    }
}
