using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ResponseCreateCliente
    {
        public string DNI { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Email { get; set; }
    }
}
