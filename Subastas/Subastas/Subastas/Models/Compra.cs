using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Compra
        {
        public long Id {get; set; }
        public long IdArticulo {get; set;}
        public DateTime Fecha {get; set;}
        public long IdUsuario {get; set; }
        public decimal Precio {get; set; }

       public Compra()
            {

            }

        public Compra(long Id,long IdArticulo, DateTime Fecha, long IdUsuario, decimal Precio)
            {
            this.Id = Id;
            this.IdArticulo = IdArticulo;
            this.Fecha = Fecha;
            this.IdUsuario = IdUsuario;
            this.Precio = Precio;
            }

       public Compra(long IdArticulo, DateTime Fecha, long IdUsuario, decimal Precio)
            {
            
            this.IdArticulo = IdArticulo;
            this.Fecha = Fecha;
            this.IdUsuario = IdUsuario;
            this.Precio = Precio;

            }
        }
    }