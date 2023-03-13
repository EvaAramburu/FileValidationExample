using API.Enums;

namespace API.Models
{
    public class FileItem
    {
        // entidad del archivo a subir
        public int Id { get; set; }
        public string Name { get; set; }
        public byte[] Content { get; set; }
        public DateTime InsertDate { get; set; }
        public DateTime UpdateDate { get; set; }
        public FileExtensionEnum FileExtension { get; set; }
    }
}
