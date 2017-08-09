using DataAccessService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace Subastas.Models
    {
    public class LoginDAO
        {
       
         String cadenaconexion = null;
         SqlConnection conexion = null;

         public void Alta(Login tablausuarios)
            {
            //Falta Implementar Dispose y liberacion de recursos
            
            Configuracion  conf = new Configuracion();
			cadenaconexion = conf.LeerCadenaCompleta();
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

            //Definicion de procedimiento
			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "AltaLogin";

            //Parametros a utilizar
           
            SqlParameter ParametroNick = new SqlParameter();
	     	ParametroNick.Value= tablausuarios.Nick;
			ParametroNick.ParameterName="@Nick";

            SqlParameter ParametroContrasenia = new SqlParameter();
	     	ParametroContrasenia.Value= tablausuarios.Contrasenia;
			ParametroContrasenia.ParameterName="@Contrasenia";

           
            command.Parameters.Add(ParametroNick);
            command.Parameters.Add(ParametroContrasenia);

		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

         public Boolean Login (Login logeo)
            {
           
            String cadenaconexion = null;
			//consulta sql para autenticar, si es correcto el logeo creamos el ticket de autorizacion y si
			// retornamos a la vista de login
		
			Configuracion  conf = new Configuracion();
		    cadenaconexion = conf.LeerCadenaCompleta();
                
			SqlConnection conexion = null;
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "ConsultaLogin";
         
			SqlParameter ParametroNick= new SqlParameter();
			ParametroNick.Value = logeo.Nick;
			ParametroNick.ParameterName="@Nick";

			SqlParameter ParametroContrasenia = new SqlParameter();
	     	ParametroContrasenia.Value =logeo.Contrasenia;
			ParametroContrasenia.ParameterName="@Contrasenia";

			command.Parameters.Add(ParametroNick);
			command.Parameters.Add(ParametroContrasenia);
		
			int resultado = (int) command.ExecuteScalar();

			if (resultado>0)
			{
			//Con WindowsFormAuthentication puedo crear un ticket de autentificacion
			FormsAuthentication.SetAuthCookie(logeo.Nick, true);
       
			//conseguir cookie o ticket de autorizacion
		    //HttpCookie micookie = FormsAuthentication.GetAuthCookie(usuario,true);
            //Hashea la contraseña        
                return true;
                }
            else
                return false;
            }
        public bool  ConsultaSiExisteNick (string Nick)
            {
        
            String cadenaconexion = null;
			//consulta sql para autenticar, si es correcto el logeo creamos el ticket de autorizacion y si
			// retornamos a la vista de login
		
			Configuracion  conf = new Configuracion();
		    cadenaconexion = conf.LeerCadenaCompleta();
                
			SqlConnection conexion = null;
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "ConsultaSiExisteUser";

			SqlParameter ParametroNick = new SqlParameter();
			ParametroNick.Value = Nick;
			ParametroNick.ParameterName="@Nick";

			command.Parameters.Add(ParametroNick);
			
			SqlDataReader reader =  command.ExecuteReader();

			      Usuario usuario = new Usuario();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           usuario.Nombre = reader.GetString(0);
                            }
                            conexion.Dispose();
                            return true;
                            }
                        else
                            {
                            conexion.Dispose();
                            return false;
                            }
           
            }
      
    }
    }