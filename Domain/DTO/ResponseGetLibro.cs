using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.DTO
{
    public class ResponseGetLibro
    {
        public string titulo { get; set; }
        public string autor { get; set; }
        public string editorial { get; set; }
        public string edicion { get; set; }
        public int stock { get; set; }
        public string imagen { get; set; }
    }
}
