using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private static string dateGet = DateTime.Now.ToShortDateString();
        public FileController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [HttpPost("upload")]
        public async Task<IActionResult> Upload()
        {
            if(Request.Form.Files.Count == 0)
            {
                return BadRequest("Нет файла!");
            }
            var file = Request.Form.Files[0];
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("Файл загружен");
        }
        [HttpPost("[action]")]
        public IActionResult UploadFiles(List<IFormFile> files)
        {
            //Если файлов нет, то вернуть ошибку
            if(files.Count == 0)
            {
                return BadRequest();
            }
            //Задаем путь, куда загружать файлы
            string dirPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
            //пробегаемся по коллекции файлов и добавляем их в папку
            foreach(var file in files)
            {
                string filePath = Path.Combine(dirPath, file.FileName);
                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    file.CopyTo(stream);
                }
            }
            return Ok("Файлы загружены!");
        }
        //Задаем метод http и указываем route адрес, передаем в метод название файла, который нужно скачать
        [HttpGet]
        [Route("DownloadFile")]
        public IActionResult DownloadFile(string fileName)
        {
            //Задаем путь, откуда смотреть файлы и в дальнейшем скачивать
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", fileName);
            var provider = new FileExtensionContentTypeProvider();
            //метод по которому будем скачивать файл, первым параметром идет путь к файлу, вторым - результат
            if(!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
    }
}
