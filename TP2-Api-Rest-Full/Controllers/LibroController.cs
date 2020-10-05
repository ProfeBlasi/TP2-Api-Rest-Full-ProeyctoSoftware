    using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP2_Api_Rest_Full.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibroController : ControllerBase
    {
        private readonly ILibroService _service;
        public LibroController(ILibroService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult GetLibros([FromQuery] bool stock,[FromQuery] string autor,[FromQuery] string titulo)
        {
            try
            {
                return new JsonResult(_service.GetLibros(stock,autor,titulo)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
