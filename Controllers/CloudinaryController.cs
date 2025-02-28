using Microsoft.AspNetCore.Mvc;
using RunForLive.Services;

namespace RunForLive.Controllers;

[Route("cloudinary")] // Đặt route cho Controller
public class CloudinaryController : Controller
{
    private readonly CloudinaryService _cloudinaryService;
    private readonly ILogger<CloudinaryController> _logger;

    public CloudinaryController(CloudinaryService cloudinaryService, ILogger<CloudinaryController>logger)
    {
        _cloudinaryService = cloudinaryService;
        _logger = logger;
    }
    [HttpGet("test")]
    public IActionResult Index()
    {
        return View();
    }
    // [HttpPost("upload")]
    // public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    // {
    //     try
    //     {
    //         var imageUrl = await _cloudinaryService.UploadImageAsync(file);
    //         return Ok(new { Url = imageUrl });
    //     }
    //     catch (Exception ex)
    //     {
    //         return BadRequest(new { Message = ex.Message });
    //     }
    // }
    [HttpPost("upload")]
    public async Task<IActionResult> UploadImage([FromForm] IFormFile file)
    {
        string folderName = "event/img";
        if (file == null)
        {
            return BadRequest(new { Message = "File không được null." });
        }

        if (file.Length == 0)
        {
            return BadRequest(new { Message = "File rỗng, vui lòng chọn ảnh hợp lệ." });
        }

        try
        {
            var imageUrl = await _cloudinaryService.UploadImageAsync(file, folderName);
            var temp = "";
            // temp = Newtonsoft.Json.JsonConvert.DeserializeObject<string>(imageUrl);
            Console.WriteLine($"path: {imageUrl}");
            _logger.LogInformation("loger path: "+temp);
            return Ok(new { Url = imageUrl });
        }
        catch (Exception ex)
        {
            return BadRequest(new { Message = ex.Message });
        }
    }
    [HttpDelete("delete/{publicId}")]
    public async Task<IActionResult> DeleteImage(string publicId)
    {
        var isDeleted = await _cloudinaryService.DeleteImageAsync(publicId);
        if (isDeleted)
            return Ok(new { message = "Deleted successfully" });

        return BadRequest(new { message = "Failed to delete image" });
    }


}
