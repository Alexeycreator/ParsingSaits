using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.IO;
using System.Threading.Tasks;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromForm] IFormFile file,[FromForm] string _typeFile)
        {
            //проверка на то, что файл есть и он не пустой, а также на то, что указан тип файла
            if (file.Length == 0 || file == null)
            {
                return BadRequest("Файла нет!");
            }
            if (string.IsNullOrEmpty(_typeFile))
            {
                return BadRequest("Тип файла не указан!");
            }
            //создание пути для загрузки файла, куда передаем название общей папки и тип файла, для дальнейшего разделения
            string uploadDirectory = Path.Combine(Directory.GetCurrentDirectory(), "UploadedFiles", _typeFile);
            if (!Directory.Exists(uploadDirectory))
            {
                //создаем директорию нужную
                Directory.CreateDirectory(uploadDirectory);
            }
            //передаем в эту директорию сам файл
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
    }
}
