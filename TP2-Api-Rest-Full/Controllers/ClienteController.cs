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
    public class ClienteController : ControllerBase
    {
        private readonly IClienteService _service;
        public ClienteController(IClienteService service)
        {
            _service = service;
        }

        [HttpPost]
        public IActionResult RegistrarCliente(ResponseCreateCliente cliente)
        {
            try
            {
                return new JsonResult(_service.RegistrarCliente(cliente)) { StatusCode = 201 };
            }
            catch (System.Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult GetCliente([FromQuery] string dni, [FromQuery] string nombre, [FromQuery] string apellido)
        {
            try
            {
                return new JsonResult(_service.GetCliente(dni,nombre,apellido)) { StatusCode = 200 };
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
