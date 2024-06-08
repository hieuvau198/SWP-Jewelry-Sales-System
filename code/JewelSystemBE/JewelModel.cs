namespace JewelSystemBE
{
    public class JewelModel
    {
        public string Name { get; set; }
        public IFormFile Picture { get; set; }

        public string PictureBase64 { get; set; }
        public string PictureUrl { get; set; }
    }
}
