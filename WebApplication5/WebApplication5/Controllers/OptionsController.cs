using Microsoft.AspNetCore.Mvc;
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
                    Type = $"type {i}",
                    FileName = $"fileName {i}",
                    DataStream = $"dataStream {i}",
                };
                optionsModel.Add(_optionsModel);
            }
            return optionsModel;
        }
        [HttpGet("{id}")]
        public OptionsModel Get(string id)
        {
            return new OptionsModel
            {
                Type = $"type {id}",
                FileName = $"fileName {id}",
                DataStream = $"dataStream {id}",
            };
        }
    }
}
