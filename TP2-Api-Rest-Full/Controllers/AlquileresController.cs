using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.DTO;
using Domain.Interfaces.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace TP2_Api_Rest_Full.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlquileresController : ControllerBase
    {
        private readonly IAlquileresService _service;
        public AlquileresController(IAlquileresService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult RegistrarProceso(ResponseCreateAlquileres alquileres)
        {
            try
            {
                return new JsonResult(_service.RegistrarProceso(alquileres)) { StatusCode = 201 };
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }

    
}
