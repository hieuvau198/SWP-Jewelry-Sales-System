using JewelSystemBE.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace JewelSystemBE.Controllers
{
    [Route("api/image")]
    [ApiController]
    public class ImagesController : ControllerBase
    {
        private readonly JewelDbContext _context;
        private readonly string _imagesPath;

        public ImagesController(JewelDbContext context, IWebHostEnvironment hostingEnvironment)
        {
            _context = context;
            _imagesPath = Path.Combine(Directory.GetCurrentDirectory(), "Images");
        }

        // Endpoint to get a specific image by ID
        

        // Endpoint to get a list of all image records
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ImageRecord>>> GetImages()
        {
            return await _context.ImageRecords.ToListAsync();
        }

        // Endpoint to upload an image
        
        [HttpGet("idOrName")]
        public async Task<IActionResult> GetImage(string idOrName)
        {
            var imageRecord = await _context.ImageRecords.FindAsync(idOrName);
            if (imageRecord == null)
            {
                imageRecord = await _context.ImageRecords.FirstOrDefaultAsync(x => x.FileName == idOrName);
                if (imageRecord == null)
                {
                    return NotFound();
                }
            }
            var filePath = Path.Combine(_imagesPath, imageRecord.Path);
            var image = System.IO.File.OpenRead(filePath);
            return File(image, "image/jpeg"); // Adjust MIME type as needed
        }
        [HttpGet("base/idOrName")]
        public async Task<IActionResult> GetImageBase64(string idOrName)
        {
            var imageRecord = await _context.ImageRecords.FindAsync(idOrName);
            if (imageRecord == null)
            {
                imageRecord = await _context.ImageRecords.FirstOrDefaultAsync(x => x.FileName == idOrName);
                if (imageRecord == null)
                {
                    return NotFound();
                }
            }

            var filePath = Path.Combine(_imagesPath, imageRecord.Path);
            byte[] imageBytes = await System.IO.File.ReadAllBytesAsync(filePath);
            string base64String = Convert.ToBase64String(imageBytes);

            return Ok(base64String);
        }

        [HttpPost("uploadForm")]
        public async Task<IActionResult> UploadImage(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("Invalid file.");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine(_imagesPath, fileName);

            try
            {
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await file.CopyToAsync(stream);
                }

                var imageRecord = new ImageRecord
                {
                    Id = Guid.NewGuid().ToString(), // Generate a unique identifier
                    FileName = fileName,
                    Path = fileName // Store only the file name in the database
                };

                _context.ImageRecords.Add(imageRecord);
                await _context.SaveChangesAsync();

                return Ok(imageRecord);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(500, "Internal server error");
            }
        }

        [HttpPost("upload")]
        public async Task<IActionResult> UploadImage([FromBody] ImageUploadRequest request)
        {
            if (request == null || string.IsNullOrEmpty(request.FileContentBase64) || string.IsNullOrEmpty(request.FileName))
            {
                return BadRequest("Invalid file.");
            }

            var fileName = Path.GetFileName(request.FileName);
            var filePath = Path.Combine(_imagesPath, fileName);

            try
            {
                var fileBytes = Convert.FromBase64String(request.FileContentBase64);
                await System.IO.File.WriteAllBytesAsync(filePath, fileBytes);

                var imageRecord = new ImageRecord
                {
                    Id = Guid.NewGuid().ToString(), // Generate a unique identifier
                    FileName = fileName,
                    Path = fileName // Store only the file name in the database
                };

                _context.ImageRecords.Add(imageRecord);
                await _context.SaveChangesAsync();

                return Ok(imageRecord);
            }
            catch (Exception ex)
            {
                // Log the exception (not shown here)
                return StatusCode(500, "Internal server error");
            }
        }
    }
}
