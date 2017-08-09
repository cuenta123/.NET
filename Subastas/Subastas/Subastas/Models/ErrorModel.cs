using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class ErrorModel
        {
        public bool Activado {get; set; } 
        public String Tipo {get; set; }
        public String Mensaje {get; set; }
        }
    }