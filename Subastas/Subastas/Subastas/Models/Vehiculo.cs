using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Vehiculo
        {
        public long Id {get; set; }
        public string Estado {get; set;}
        public string Marca {get; set; }
        public string Modelo {get; set;}
        public string Combustible {get; set; }
        public int Km {get; set; }
        public string Ubicacion {get; set; }
        public DateTime FPMatriculacion {get; set; } 
        public string ColorExterior {get; set; }
        public string ColorInterior {get; set; }
        public string Equipamiento {get; set; }
        public DateTime FechaPuja {get; set; }
        public int Puja {get; set; }
        public long IdUsuarioPuja {get; set; }


        public Vehiculo()
            {

            }
       public Vehiculo(long Id, string Estado, string Marca, string Modelo, string Combustible, int Km, string Ubicacion,
           DateTime FPMatriculacion, string ColorExterior, string ColorInterior, string Equipamiento)
            {
            
            this.Id = Id;
            this.Estado = Estado;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Combustible = Combustible;
            this.Km = Km;
            this.Ubicacion = Ubicacion;
            this.FPMatriculacion = FPMatriculacion;
            this.ColorExterior = ColorExterior;
            this.ColorInterior = ColorInterior;
            this.Equipamiento = Equipamiento;
         
            }

        public Vehiculo( string Estado, string Marca, string Modelo, string Combustible, int Km, string Ubicacion,
           DateTime FPMatriculacion, string ColorExterior, string ColorInterior, string Equipamiento)
            {
             
            this.Estado = Estado;
            this.Marca = Marca;
            this.Modelo = Modelo;
            this.Combustible = Combustible;
            this.Km = Km;
            this.Ubicacion = Ubicacion;
            this.FPMatriculacion = FPMatriculacion;
            this.ColorExterior = ColorExterior;
            this.ColorInterior = ColorInterior;
            this.Equipamiento = Equipamiento;
           
            }
        }

    }