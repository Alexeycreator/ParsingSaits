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
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload(IFormFile file, string _typeFile)
        {
            if (file.Length == 0 || file == null)
            {
                return BadRequest("Файла нет!");
            }
            if (string.IsNullOrEmpty(_typeFile))
            {
                return BadRequest("Тип файла не указан!");
            }
            string uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", _typeFile);
            if (!Directory.Exists(uploadDirectory))
            {
                Directory.CreateDirectory(uploadDirectory);
            }
            string filePath = Path.Combine(uploadDirectory, file.FileName);
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }
            return Ok("Файл загружен!");
        }
        //Задаем метод http и указываем route адрес, передаем в метод название файла, который нужно скачать
        [HttpGet]
        [Route("download")]
        public IActionResult DownloadFile(string fileName)
        {
            //Задаем путь, откуда смотреть файлы и в дальнейшем скачивать
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", fileName);
            var provider = new FileExtensionContentTypeProvider();
            //метод по которому будем скачивать файл, первым параметром идет путь к файлу, вторым - результат
            if (!provider.TryGetContentType(filePath, out var contentType))
            {
                contentType = "application/octet-stream";
            }
            var bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, contentType, Path.GetFileName(filePath));
        }
        //[HttpPost("[action]")]
        //public IActionResult UploadFiles(List<IFormFile> files)
        //{
        //    //Если файлов нет, то вернуть ошибку
        //    if(files.Count == 0)
        //    {
        //        return BadRequest();
        //    }
        //    //Задаем путь, куда загружать файлы
        //    string dirPath = Path.Combine(_webHostEnvironment.ContentRootPath, "UploadedFiles");
        //    //пробегаемся по коллекции файлов и добавляем их в папку
        //    foreach(var file in files)
        //    {
        //        string filePath = Path.Combine(dirPath, file.FileName);
        //        using (var stream = new FileStream(filePath, FileMode.Create))
        //        {
        //            file.CopyTo(stream);
        //        }
        //    }
        //    return Ok("Файлы загружены!");
        //}


        //[HttpPost]
        //[Route("upload")]
        //public async Task<IActionResult> Upload([FromForm] IFormFile file/*, [FromForm] string _typeFile)
        //{
        //    if(file.Length == 0 || file == null)
        //    {
        //        return BadRequest("Файла нет!");
        //    }
        //    //if (string.IsNullOrEmpty(_typeFile))
        //    //{
        //    //    return BadRequest("Тип файла не указан!");
        //    //}
        //    string uploadDir = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles"/*, _typeFile*/);
        //    if (!Directory.Exists(uploadDir))
        //    {
        //        Directory.CreateDirectory(uploadDir);
        //    }
        //    string filePath = Path.Combine(uploadDir, file.FileName);
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    return Ok("Файл загружен!");
        //}

        //[HttpPost]
        //[Route("upload")]
        //public async Task<IActionResult> Upload()
        //{
        //    //проверяем есть ли файл, если нет - выдает сообщение об этом
        //    if (Request.Form.Files.Count == 0)
        //    {
        //        return BadRequest("Нет файла!");
        //    }
        //    var file = Request.Form.Files[0];
        //    //создаем путь для файла, куда передаем название папки и имя файла
        //    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", file.FileName);
        //    //создаем потом, куда передаем путь и создаем файл в папке
        //    using (var stream = new FileStream(filePath, FileMode.Create))
        //    {
        //        await file.CopyToAsync(stream);
        //    }
        //    return Ok("Файл загружен");
        //}
    }
}
