using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        private readonly string filesPath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\WebApplication5\WebApplication5\UploadedFiles\";
        [HttpGet("getOptions")]
        public List<OptionsModel> Get()
        {
            string _optionsfilesPath = $@"{filesPath}\jse\";
            List<OptionsModel> _optionsModel = new List<OptionsModel>();
            string[] files = Directory.GetFiles(_optionsfilesPath);
            foreach(var _options in files)
            {
                OptionsModel options = new OptionsModel
                {
                    FileName = Path.GetFileName(_options),
                    Type = "jse",
                };
                _optionsModel.Add(options);
            }
            return _optionsModel;
        }
    }
}
