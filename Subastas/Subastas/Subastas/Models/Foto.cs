using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Foto
        {
        public long Id {get; set; }
        public long IdArticulo {get; set; }
        public string Direccion {get; set; }

        public Foto()
            {

            }

         public Foto(long Id,long IdArticulo, string Direccion)
            {
            this.Id = Id;
            this.IdArticulo = IdArticulo;
            this.Direccion = Direccion;
            }

        public Foto(long IdArticulo, string Direccion)
            {
            this.IdArticulo = IdArticulo;
            this.Direccion = Direccion;
            }
        }
    }