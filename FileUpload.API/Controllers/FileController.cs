using FileUpload.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FileUpload.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost("upload")]
        public ActionResult<FileUploadModel> UploadAttachments([FromForm] FileUploadModel files)
        {
            return this.Ok(files);
        }

        [HttpPost("upload-v2")]
        public IActionResult UploadAttachmentsV2(List<IFormFile> files)
        {
            var results = new List<object>();
            foreach (var file in files)
            {
                if (file.Length > 0)
                {
                    try
                    {
                        // Generate a unique filename
                        var filename = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);

                        // Save the file to disk
                        
                        // Add the file to result
                        results.Add(new { Name = file.FileName, Filename = filename });
                    }
                    catch (Exception ex)
                    {
                        // Handle any exceptions that occur during file upload
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Error uploading file: {ex.Message}");
                    }
                }
            }

            return Ok(results);
        }
    }
}
