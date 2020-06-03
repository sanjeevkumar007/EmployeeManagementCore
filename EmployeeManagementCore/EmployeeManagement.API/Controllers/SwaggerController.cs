using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("[controller]")]
    public class SwaggerController : Controller
    {
        [HttpGet]
        [Route("/Swagger")]
        public IActionResult GetSwagger()
        {

            string baseUrl = HttpContext.Request.GetDisplayUrl();
            string swaggerUrl = baseUrl + "/index.html";

            return Redirect(swaggerUrl);
            
        }
    }
}
