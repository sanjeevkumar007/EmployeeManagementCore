﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.API.Controllers
{
    [Route("[api/controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        [Route("/")]

        //public IActionResult Index()
        //{
        //    return View();
        //}

        public ContentResult  GetSwagger()
        {
            string baseUrl= HttpContext.Request.GetDisplayUrl();
            string swaggerUrl = baseUrl + "swagger/index.html"; 

            string link=$"<body style='background-color:#2C3539;'><h2><a style='text-decoration: none; color:#9BE301;' href={swaggerUrl}>Go to Swagger</a></h2></body>";


            return new ContentResult
            {
                ContentType = "text/html",
                Content = link
            }; 


        }
    }
}
