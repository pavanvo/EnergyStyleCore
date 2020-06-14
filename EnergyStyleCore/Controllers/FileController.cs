using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CustomPolicyProvider;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EnergyStyleCore.Controllers
{
    [RoleAuthorize("user")]
    public class FileController : Controller
    {
        [HttpPost]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            if (file != null)
            {
                // await Task.Delay(3000);
                if (file.Length > 0)
                {
                    var fileName = $"user/{Guid.NewGuid()}.jpg";
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                    using (var fileStream = new FileStream(filePath, FileMode.Create))
                    {
                        await file.CopyToAsync(fileStream);
                        return Ok(fileName);
                    }
                }
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Uploads(IFormFileCollection files)
        {
            if (files != null)
            {
                var result = new List<string>();
                foreach (var file in files)
                {
                    // await Task.Delay(3000);
                    if (file.Length > 0)
                    {
                        var fileName = $"user/{Guid.NewGuid()}.jpg";
                        var filePath = Path.Combine(Directory.GetCurrentDirectory(), @"wwwroot\images", fileName);
                        using (var fileStream = new FileStream(filePath, FileMode.Create))
                        {
                            await file.CopyToAsync(fileStream);
                            result.Add(fileName);
                        }
                    }
                }
                return Json(result);
            }
            return BadRequest();
        }
    }
}
