using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Usuario: InterfaceLogin
        {

             public long Id {get; set; }
             [Required]
             [StringLength(15,ErrorMessage ="El Nombre demasiado largo o corto escribe un nombre entre 1 y 15 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             public string Nombre {get; set; }
           //  [Required]
            // [StringLength(15,ErrorMessage ="Los Apellidos demasiado largo o corto escribe  entre 1 y 15 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             public string Apellidos {get; set; }
             [Required]
             [StringLength(50,ErrorMessage ="El Correo demasiado largo o corto escribe  entre 1 y 50 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             
             public string CorreoElectronico {get; set; }
             //[Required]
             //[StringLength(15,ErrorMessage ="El telefono demasiado largo o corto escribe  entre 1 y 15 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             public string Telefono {get; set; }
             [Required]
             [StringLength(15,ErrorMessage ="El movil demasiado largo o corto escribe  entre 1 y 15 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             public string Movil {get; set; }
            //[Required]
            //[StringLength(15,ErrorMessage ="El Pais demasiado largo o corto escribe entre 1 y 15 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             public string Pais {get; set; }
            //[Required]
            //[StringLength(15,ErrorMessage ="La provincia demasiado largo o corto escribe  entre 1 y 15 caracteres",ErrorMessageResourceName =null,ErrorMessageResourceType =null,MinimumLength =1)]
             public string Provincia {get; set; }
            //[Required]
            //[StringLength(10,ErrorMessage ="La localidad demasiado largo o corto escribe  entre 1 y 9 caracteres", ErrorMessageResourceName =null, ErrorMessageResourceType =null, MinimumLength =1)]
             public string Localidad{get; set; }
     
             public bool Activo {get; set; }
         
             public string Nick {get; set; }
           
             public bool Baneado {get; set; }
            //[Required]
           // [StringLength(9,ErrorMessage ="El dni demasiado largo o corto escribe  entre 1 y 9 caracteres", ErrorMessageResourceName =null, ErrorMessageResourceType =null, MinimumLength =1)]
             public string Dni {get; set; }
                [Required]
                public int CodPostal {get; set; }
                [Required]
                public String Direccion {get; set; }

         public string Tipo { get; set;}
         public String MensajeError {get; set; }
         public bool Activado {get; set; }


        public string Contrasenia {get;set;}

        public Usuario()
            {

            }

       public Usuario(long Id, string Nombre, string Apellidos, string CorreoElectronico, string Telefono,
            string Movil, string Pais, string Provincia, string Localidad, bool Activo, string Nick,bool Baneado,string Dni)
            {
            this.Id = Id;
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.CorreoElectronico = CorreoElectronico;
            this.Telefono = Telefono;
            this.Movil = Movil;
            this.Pais = Pais;
            this.Provincia = Provincia;
            this.Localidad = Localidad;
            this.Activo = Activo;
            this.Nick = Nick;
            this.Baneado = Baneado;
            this.Dni = Dni;
            }

         public Usuario(string Nombre, string Apellidos, string CorreoElectronico, string Telefono,
            string Movil, string Pais, string Provincia, string Localidad,bool Activo, string Nick, bool Baneado, string Dni)
            {
           
            this.Nombre = Nombre;
            this.Apellidos = Apellidos;
            this.CorreoElectronico = CorreoElectronico;
            this.Telefono = Telefono;
            this.Movil = Movil;
            this.Pais = Pais;
            this.Provincia = Provincia;
            this.Localidad = Localidad;
            this.Activo = Activo;
            this.Nick = Nick;
            this.Baneado = Baneado;
            this.Dni = Dni;
            }
        public Usuario (string Nombre, string CorreoElectronico, 
            string Movil, string Nick,bool Activo, int CodigoPostal, String Direccion, string Tipo,String MensajeError,bool Activado)
            {
           
            this.Nombre = Nombre;    
            this.CorreoElectronico = CorreoElectronico;       
            this.Movil = Movil;       
            this.Activo = Activo;
            this.Nick = Nick;
            this.CodPostal = CodigoPostal;
            this.Direccion = Direccion;
            this.Tipo = Tipo;
            this.MensajeError = MensajeError;
            this.Activado = Activado;
            }

        public Usuario(String Tipo, String Mensaje, bool Activado)
            {
            this.Tipo = Tipo;
            this.MensajeError = Mensaje;
            this.Activado = Activado;
            }

        }
    }