
using Microsoft.AspNetCore.Http;

namespace JewelDTO
{
    public class PictureModelDto
    {
        public string DtoName { get; set; }
        public string DtoType { get; set; }
        public string DtoPictureCode { get; set; }
        public IFormFile Picture { get; set; }
    }
}
