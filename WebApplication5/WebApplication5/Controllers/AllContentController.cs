using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AllContentController : ControllerBase
    {
        private readonly string filesPath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\WebApplication5\WebApplication5\UploadedFiles\";
        [HttpGet("getAllContent")]
        public List<AllContentModel> GetAll()
        {
            string _optionsfilesPath = $@"{filesPath}\jse\";
            string _bondsfilesPath = $@"{filesPath}\wb\";
            List<AllContentModel> _allContentModel = new List<AllContentModel>();
            if (_optionsfilesPath.Length > 0 || _bondsfilesPath.Length > 0)
            {
                string[] _optionsFiles = Directory.GetFiles(_optionsfilesPath);
                string[] _bondsFiles = Directory.GetFiles(_bondsfilesPath);
                var files = _optionsFiles.Concat(_bondsFiles);
                foreach (var _allContent in files)
                {
                    AllContentModel allContent = new AllContentModel
                    {
                        FileName = Path.GetFileName(_allContent),
                    };
                    _allContentModel.Add(allContent);
                }
                return _allContentModel;
            }
            else
            {
                return null;
            }
        }
    }
}
