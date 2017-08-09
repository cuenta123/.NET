using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class ArticuloCompraUsuario
        {

       //Todo de Articulo
       public string Titulo {get; set;}    
       public string FotoPrincipal {get; set; }
       
        //Todo de Compra
        public long Id {get; set; }
        public long IdArticulo {get; set;}
        public DateTime Fecha {get; set;}
        public long IdUsuario {get; set; }
        public decimal Precio {get; set; }

        //Todo de Usuario
       
        public string Nombre {get; set; }
        public string Apellidos {get; set; }
        public string Telefono {get; set; }
        public string Dni {get; set; }

        public ArticuloCompraUsuario()
            {

            }

       public ArticuloCompraUsuario(long Id, long IdArticulo, DateTime Fecha, long IdUsuario, 
           Decimal Precio,
           string Nombre,string Apellidos, string Telefono, string Titulo, string FotoPrincipal,
           string Dni)
            {

            this.Id = Id;
            this.IdArticulo = IdArticulo;
            this.Fecha = Fecha;
            this.Precio = Precio;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.Telefono = Telefono;
            this.Titulo = Titulo;
            this.FotoPrincipal = FotoPrincipal;
            this.Dni = Dni;
            }

  
        
   
    }
    }