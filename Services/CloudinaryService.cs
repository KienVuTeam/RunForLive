using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using Microsoft.Extensions.Configuration;

namespace RunForLive.Services;

public class CloudinaryService
{
    private readonly Cloudinary _cloudinary;

    public CloudinaryService(IConfiguration configuration)
    {
        var account = new Account(
            configuration["Cloudinary:CloudName"],
            configuration["Cloudinary:ApiKey"],
            configuration["Cloudinary:ApiSecret"]
        );

        _cloudinary = new Cloudinary(account);
        _cloudinary.Api.Secure = true;
    }

    public async Task<string?> UploadImageAsync(IFormFile file, string folderPath)
    {
        if (file == null || file.Length == 0)
            return null;

        using var stream = file.OpenReadStream();
        var uploadParams = new ImageUploadParams()
        {
            File = new FileDescription(file.FileName, stream),
            PublicId = $"uploads/{Guid.NewGuid()}",
            Overwrite = true,
            Folder = folderPath //path
        };

        var uploadResult = await _cloudinary.UploadAsync(uploadParams);
        Console.WriteLine("path url services: "+ uploadResult.SecureUrl?.ToString());

        return uploadResult.SecureUrl?.ToString(); // Trả về URL ảnh
    }
    // delete
    public async Task<bool> DeleteImageAsync(string publicId)
    {
        var deleteParams = new DeletionParams(publicId);
        var result = await _cloudinary.DestroyAsync(deleteParams);
        return result.Result == "ok";
    }

}

