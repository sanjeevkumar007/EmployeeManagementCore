using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementMVCApi.Controllers
{
    public class SwaggerController : Controller
    {
        public IActionResult Index()
        {
            var route = HttpContext.Request.Host;
            string baseUrl = HttpContext.Request.GetEncodedUrl().Replace("Swagger","swagger");
            string swaggerUrl = baseUrl + "/index.html";
            return Redirect(swaggerUrl);
        }
    }
}
