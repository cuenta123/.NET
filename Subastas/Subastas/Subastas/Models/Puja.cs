using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Puja
        {
        public long IdPuja {get; set; }
        public long IdUsuario {get; set; }
        public long IdArticulo {get; set; }
        public decimal PujaActual {get; set; }

        public Puja() { }
        public Puja(long IdPuja, long IdUsuario,long IdArticulo,decimal PujaActual) {
            this.IdPuja = IdPuja;
            this.IdUsuario = IdUsuario;
            this.IdArticulo = IdArticulo;
            this.PujaActual = PujaActual;
            }
        public Puja( long IdUsuario,long IdArticulo,decimal PujaActual) {
          
            this.IdUsuario = IdUsuario;
            this.IdArticulo = IdArticulo;
            this.PujaActual = PujaActual;
            }
        }
    }