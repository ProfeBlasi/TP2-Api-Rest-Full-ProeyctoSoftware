using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ResponseGetLibros
    {
        public string Titulo { get; set; }
        public string Autor { get; set; }
        public string Editorial { get; set; }
        public string Edicion { get; set; }
        public int Stock { get; set; }
        public string Imagen { get; set; }
    }
}
