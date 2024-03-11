using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class OptionsController : ControllerBase
    {
        [HttpGet]
        public List<OptionsModel> Get()
        {
            var optionsModel = new List<OptionsModel>();
            for (int i = 1; i < 10; i++)
            {
                var _optionsModel = new OptionsModel
                {
                    FileName = $"fileName {i}",
                };
                optionsModel.Add(_optionsModel);
            }
            return optionsModel;
        }
    }
}
