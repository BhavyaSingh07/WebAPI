using NZWalksAPI.Data;
using NZWalksAPI.Models.Domain;

namespace NZWalksAPI.Repositories
{
    public class LocalImageRepository : IImageRespository
    {
        private readonly IWebHostEnvironment _webHostenvironment;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly NZWalksDbContext _dbContext;
        public LocalImageRepository(IWebHostEnvironment webHostEnvironment, IHttpContextAccessor httpContextAccessor, NZWalksDbContext dbContext)
        {
            this._webHostenvironment = webHostEnvironment;
            this._httpContextAccessor = httpContextAccessor;
            this._dbContext = dbContext;
        }
        public async Task<Image> UploadAsync(Image image)
        {
            var localFilePath = Path.Combine(_webHostenvironment.ContentRootPath, "Images", $"{image.FileName}{image.FileExtension}");

            //upload image to local path
            using var stream = new FileStream(localFilePath, FileMode.Create);
            await image.File.CopyToAsync(stream);

            //https://localhost:1234/images/image.jpg
            var urlFilePath = $"{_httpContextAccessor.HttpContext.Request.Scheme}://{_httpContextAccessor.HttpContext.Request.Host}{_httpContextAccessor.HttpContext.Request.PathBase}/Images/{image.FileName}{image.FileExtension}";

            image.FilePath = urlFilePath;

            //adding image to Db
            await _dbContext.Images.AddAsync(image);
            await _dbContext.SaveChangesAsync();

            return image;
        }
    }
}
