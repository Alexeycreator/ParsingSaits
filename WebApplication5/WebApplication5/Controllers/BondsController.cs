using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BondsController : ControllerBase
    {
        [HttpGet]
        public List<BondsModel> Get(string type)
        {
            var bondsModel = new List<BondsModel>();
            for (int i = 1; i < 10; i++)
            {
                var _bondsModel = new BondsModel
                {
                    FileName = $"fileName {i}",
                };
                bondsModel.Add(_bondsModel);
            }
            return bondsModel;
        }
    }
}
