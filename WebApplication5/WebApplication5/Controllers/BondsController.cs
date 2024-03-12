using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BondsController : ControllerBase
    {
        private readonly string filesPath = @"C:\Users\Алексей\Desktop\Учеба\github\ParsingSaits\WebApplication5\WebApplication5\UploadedFiles\";
        [HttpGet("getBonds")]
        public List<BondsModel> Get()
        {
            string _bondsfilesPath = $@"{filesPath}\wb\";
            List<BondsModel> _optionsModel = new List<BondsModel>();
            string[] files = Directory.GetFiles(_bondsfilesPath);
            foreach (var _bonds in files)
            {
                BondsModel bonds = new BondsModel
                {
                    FileName = Path.GetFileName(_bonds),
                    Type = "wb",
                };
                _optionsModel.Add(bonds);
            }
            return _optionsModel;
        }
    }
}
