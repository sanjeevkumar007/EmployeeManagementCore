using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeControllerOd : ControllerBase
    {
        [HttpGet]
        [Route("/")]
        public ContentResult  GetSwagger()
        {
            string baseUrl= HttpContext.Request.GetDisplayUrl();
            string swaggerUrl = baseUrl + "swagger/index.html"; 

            string link="<h2><a href='"+swaggerUrl+"'>Go to Swagger</a></h2>";


            return new ContentResult
            {
                ContentType = "text/html",
                Content = link
            }; 


        }
    }
}
