using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdemyAngular.API.Data;

namespace UdemyAngular.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get(string fileName)
        {
            //string fileName = "przeczytaj.txt";
            string filePath = "~\\testFiles\\" + fileName;

            Response.Headers.Add("Access-Control-Expose-Headers", "Content-Disposition");

            return File(filePath, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "arkusz.xlsx");
        }
    }
}