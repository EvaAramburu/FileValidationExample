using System.ComponentModel.DataAnnotations;

namespace FileManagerExample.ValidationAttributes
{
    public class PesoArchivoAttribute : ValidationAttribute
    {
        private readonly double pesoArchivoKb; 

        public PesoArchivoAttribute(double pesoArchivoKb)
        {
            this.pesoArchivoKb = pesoArchivoKb;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var formfile = value as IFormFile;
            if (formfile != null)
            {
                if(formfile.Length / 1024 > pesoArchivoKb)
                {
                    return new ValidationResult($"El peso del archivo que enviaste es {formfile.Length/1024}Kb y supera el máximo permitido de {pesoArchivoKb}Kb");
                }
            }
            return ValidationResult.Success;
        }
    }
}
