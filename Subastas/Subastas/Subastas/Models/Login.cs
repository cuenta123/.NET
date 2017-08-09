using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Subastas.Models
    {
    public class Login: ErrorModel
        {
        public long Id {get; set; }
        [Required]
        public string Nick {get; set; }
        [Required]
        public string Contrasenia {get; set; }

            public  Login(string Nick, string Contrasenia, string Tipo,String MensajeError,bool Activado)
            {  
            this.Mensaje = MensajeError;
            this.Tipo = Tipo;
            this.Activado = Activado;
            this.Nick = Nick;
            this.Contrasenia = Contrasenia;
            }
        public Login(String Tipo,String MensajeError, bool Activado)
            {
            this.Mensaje = MensajeError;
            this.Tipo = Tipo;
            this.Activado = Activado;
            }

          public  Login(long Id, string Nick, string Contrasenia)
            {
            this.Id = Id;
            this.Nick = Nick;
            this.Contrasenia = Contrasenia;
            }

          public  Login(string Nick, string Contrasenia)
            {  

            this.Nick = Nick;
            this.Contrasenia = Contrasenia;
            }

           public Login(long Id)
            {  
            this.Id = Id;
           
            }
        public Login()
            {

            }
        }
    }