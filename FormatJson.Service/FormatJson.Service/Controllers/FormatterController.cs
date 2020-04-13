using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using FormatJson.Service.Data.Dto;
using FormatJson.Service.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace FormatJson.Service.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FormatterController : Controller
    {
        
        private readonly IJsonFormatter _formatter;

        public FormatterController(IJsonFormatter formatter)
        {
            _formatter = formatter;
        }

        [Route("json")]
        [HttpPost]
        public async Task<IActionResult> FormatJson([FromBody] RequestFilePath request)
        {

            var result = await _formatter.FormatInput(request.FilePath);
            
            if(result == null)
            {
                return NotFound("Invalid File Path.");
            }
            return Json(result, new JsonSerializerSettings { DefaultValueHandling = DefaultValueHandling.Ignore });
            
        }
    }
}
