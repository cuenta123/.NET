using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Articulo:ErrorModel 
        {
       public long IdArticulo {get; set; }
       public string Categoria {get; set; }
       public string Titulo {get; set;}
       public string Descripcion {get; set; }
       public int Stock {get; set; }
       public DateTime Fecha {get; set; }
       public decimal PrecioInicial {get; set; }
       public DateTime FechaFinal {get; set; } 
       public Boolean Activo {get; set; } 
       public string FotoPrincipal {get; set; }
       public Boolean Comprado {get; set; }
       public List<Articulo> ListadoArticulo {get; set; }

       
        public Articulo()
            {

            }
        
        public Articulo(long IdArticulo,String Tipo, String MensajeError, bool Activo)
            {
            this.IdArticulo = IdArticulo;
            this.Tipo = Tipo;
            this.Mensaje = MensajeError;
            this.Activado = Activo;
            }

        public Articulo(String Tipo, String MensajeError, bool Activo)
            {
            this.Tipo = Tipo;
            this.Mensaje = MensajeError;
            this.Activado = Activo;
            }

       public Articulo(long IdArticulo,String Categoria, String Titulo, String Descripcion, int Stock, DateTime Fecha, 
           decimal PrecioInicial, DateTime FechaFinal, Boolean Activo,string FotoPrincipal, bool Comprado)
            {

            this.IdArticulo = IdArticulo;
            this.Categoria = Categoria;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Stock = Stock;
            this.Fecha = Fecha;
            this.PrecioInicial = PrecioInicial;
            this.FechaFinal = FechaFinal;
            this.Activo = Activo;
            this.FotoPrincipal = FotoPrincipal;
            this.Comprado = Comprado;
            }

       public Articulo(String Categoria, String Titulo, String Descripcion, int Stock, DateTime Fecha, decimal PrecioInicial,
           DateTime FechaFinal, Boolean Activo,string FotoPrincipal, bool Comprado)
            {

            this.Categoria = Categoria;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Stock = Stock;
            this.Fecha = Fecha;
            this.PrecioInicial = PrecioInicial;
            this.FechaFinal = FechaFinal;
            this.Activo = Activo;
            this.FotoPrincipal = FotoPrincipal;
            this.Comprado = Comprado;

            }
        public Articulo(String Categoria, String Titulo, String Descripcion, int Stock, DateTime Fecha, decimal PrecioInicial,
           DateTime FechaFinal, Boolean Activo,string FotoPrincipal, bool Comprado, String Tipo, String MensajeError, bool Activado)
            {

            this.Categoria = Categoria;
            this.Titulo = Titulo;
            this.Descripcion = Descripcion;
            this.Stock = Stock;
            this.Fecha = Fecha;
            this.PrecioInicial = PrecioInicial;
            this.FechaFinal = FechaFinal;
            this.Activo = Activo;
            this.FotoPrincipal = FotoPrincipal;
            this.Comprado = Comprado;
            this.Tipo = Tipo;
            this.Mensaje = MensajeError;
            this.Activado = Activo;

            }
    public Articulo (List<Articulo> Articulo)
        {

        }

        
    }
    }