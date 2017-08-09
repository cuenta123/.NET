using DataAccessService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Multigas_Enertica.Models
    {
    public class UsuariosDao
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(T_Usuarios tablausuarios)
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
			command.CommandText= "Crear_Usuarios";

            //Parametros a utilizar
            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= tablausuarios.Id;
			ParametroId.ParameterName="@Id";

            SqlParameter ParametroNombre = new SqlParameter();
	     	ParametroNombre.Value= tablausuarios.Nombre;
			ParametroNombre.ParameterName="@Nombre";

            SqlParameter ParametroPass = new SqlParameter();
	     	ParametroPass.Value= tablausuarios.Pass;
			ParametroPass.ParameterName="@Pass";

            SqlParameter ParametroRol = new SqlParameter();
	     	ParametroRol.Value= tablausuarios.Rol;
			ParametroRol.ParameterName="@Rol";

            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroNombre);
            command.Parameters.Add(ParametroPass);
            command.Parameters.Add(ParametroRol);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Baja(int Id)
            {
            //El objeto Configuracion puede ser estático...
            // y cadena de conexion puede ir al principio no es necesario que esté leyendo
            // cada vez que ejecutamos la consulta...

            Configuracion  conf = new Configuracion();
			cadenaconexion = conf.LeerCadenaCompleta();
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

            //Definicion de procedimiento
			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "Borrar_Usuarios";

            //Parametros a utilizar
			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value= Id;
			ParametroId.ParameterName="@Id";
            command.Parameters.Add(ParametroId);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(T_Usuarios tablausuarios)
            {

            Configuracion  conf = new Configuracion();
			cadenaconexion = conf.LeerCadenaCompleta();
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

            //Definicion de procedimiento
			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "Modificar_Usuarios";

            //Parametros a utilizar
            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= tablausuarios.Id;
			ParametroId.ParameterName="@Id";

            SqlParameter ParametroNombre = new SqlParameter();
	     	ParametroNombre.Value= tablausuarios.Nombre;
			ParametroNombre.ParameterName="@Nombre";

            SqlParameter ParametroPass = new SqlParameter();
	     	ParametroPass.Value= tablausuarios.Pass;
			ParametroPass.ParameterName="@Pass";

            SqlParameter ParametroRol = new SqlParameter();
	     	ParametroRol.Value= tablausuarios.Rol;
			ParametroRol.ParameterName="@Rol";

            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroNombre);
            command.Parameters.Add(ParametroPass);
            command.Parameters.Add(ParametroRol);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public Boolean Login (T_Usuarios tablausuarios)
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
			command.CommandText= "Login_Usuarios";

			SqlParameter ParametroNombre= new SqlParameter();
			ParametroNombre.Value = tablausuarios.Nombre;
			ParametroNombre.ParameterName="@Nombre";

			SqlParameter ParametroPass = new SqlParameter();
	     	ParametroPass.Value =tablausuarios.Pass;
			ParametroPass.ParameterName="@Pass";

			command.Parameters.Add(ParametroNombre);
			command.Parameters.Add(ParametroPass);
			
			int resultado = (int) command.ExecuteScalar();

			if (resultado==1)
			{
			//Con WindowsFormAuthentication puedo crear un ticket de autentificacion
			FormsAuthentication.SetAuthCookie(tablausuarios.Nombre, true);
			//conseguir cookie o ticket de autorizacion
		    //HttpCookie micookie = FormsAuthentication.GetAuthCookie(usuario,true);
            //Hashea la contraseña
      
                return true;
                }
            else
                return false;
            }
        }
    }