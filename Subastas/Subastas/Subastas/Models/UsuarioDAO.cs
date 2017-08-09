using DataAccessService;
using Subastas.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Subastas.Models
    {
    public class UsuarioDao
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(Usuario tablausuarios)
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
			command.CommandText= "AltaUsuario";

            //Parametros a utilizar
            SqlParameter ParametroNombre = new SqlParameter();
	     	ParametroNombre.Value= tablausuarios.Nombre;
			ParametroNombre.ParameterName="@Nombre";

            SqlParameter ParametroCorreoElectronico = new SqlParameter();
	     	ParametroCorreoElectronico.Value= tablausuarios.CorreoElectronico;
			ParametroCorreoElectronico.ParameterName="@CorreoElectronico";

            SqlParameter ParametroMovil = new SqlParameter();
	     	ParametroMovil.Value= tablausuarios.Movil;
			ParametroMovil.ParameterName="@Movil";

            SqlParameter ParametroActivo= new SqlParameter();
	     	ParametroActivo.Value= tablausuarios.Activo;
			ParametroActivo.ParameterName="@Activo";

            SqlParameter ParametroNick= new SqlParameter();
	     	ParametroNick.Value= tablausuarios.Nick;
			ParametroNick.ParameterName="@Nick";

            SqlParameter ParametroBaneado= new SqlParameter();
	     	ParametroBaneado.Value= false;
			ParametroBaneado.ParameterName="@Baneado";

            SqlParameter ParametroCodPostal= new SqlParameter();
	     	ParametroCodPostal.Value= tablausuarios.CodPostal;
			ParametroCodPostal.ParameterName="@CodPostal";

            SqlParameter ParametroDireccion= new SqlParameter();
	     	ParametroDireccion.Value= tablausuarios.Direccion;
			ParametroDireccion.ParameterName="@Direccion";
          
            command.Parameters.Add(ParametroNombre);
            command.Parameters.Add(ParametroCorreoElectronico);
			command.Parameters.Add(ParametroMovil); 
            command.Parameters.Add(ParametroActivo);
            command.Parameters.Add(ParametroNick);
            command.Parameters.Add(ParametroBaneado);
            command.Parameters.Add(ParametroCodPostal);
            command.Parameters.Add(ParametroDireccion);
          
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
			command.CommandText= "BajaUsuario";

            //Parametros a utilizar
			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value= Id;
			ParametroId.ParameterName="@Id";
            command.Parameters.Add(ParametroId);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(Usuario tablausuarios)
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
			command.CommandText= "ModificacionUsuario";

            //Parametros a utilizar
            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= tablausuarios.Id;
			ParametroId.ParameterName="@Id";

            SqlParameter ParametroNombre = new SqlParameter();
	     	ParametroNombre.Value= tablausuarios.Nombre;
			ParametroNombre.ParameterName="@Nombre";

            SqlParameter ParametroApellidos = new SqlParameter();
	     	ParametroApellidos.Value= tablausuarios.Apellidos;
			ParametroApellidos.ParameterName="@Apellidos";

            SqlParameter ParametroCorreoElectronico = new SqlParameter();
	     	ParametroCorreoElectronico.Value= tablausuarios.CorreoElectronico;
			ParametroCorreoElectronico.ParameterName="@CorreoElectronico";

            SqlParameter ParametroTelefono = new SqlParameter();
	     	ParametroTelefono.Value= tablausuarios.Telefono;
			ParametroTelefono.ParameterName="@Telefono";

            SqlParameter ParametroMovil = new SqlParameter();
	     	ParametroMovil.Value= tablausuarios.Movil;
			ParametroMovil.ParameterName="@Movil";

            SqlParameter ParametroPais= new SqlParameter();
	     	ParametroPais.Value= tablausuarios.Pais;
			ParametroPais.ParameterName="@Pais";

            SqlParameter ParametroProvincia= new SqlParameter();
	     	ParametroProvincia.Value= tablausuarios.Provincia;
			ParametroProvincia.ParameterName="@Provincia";

            SqlParameter ParametroLocalidad= new SqlParameter();
	     	ParametroLocalidad.Value= tablausuarios.Localidad;
			ParametroLocalidad.ParameterName="@Localidad";

            SqlParameter ParametroActivo= new SqlParameter();
	     	ParametroActivo.Value= tablausuarios.Activo;
			ParametroActivo.ParameterName="@Activo";

             SqlParameter ParametroNick= new SqlParameter();
	     	ParametroNick.Value= tablausuarios.Activo;
			ParametroNick.ParameterName="@Nick";

            SqlParameter ParametroBaneado= new SqlParameter();
	     	ParametroBaneado.Value= tablausuarios.Baneado;
			ParametroBaneado.ParameterName="@Baneado";

            SqlParameter ParametroDni= new SqlParameter();
	     	ParametroBaneado.Value= tablausuarios.Dni;
			ParametroBaneado.ParameterName="@Dni";

            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroNombre);
            command.Parameters.Add(ParametroApellidos);
            command.Parameters.Add(ParametroTelefono);
			command.Parameters.Add(ParametroMovil);
            command.Parameters.Add(ParametroPais);
            command.Parameters.Add(ParametroProvincia);
            command.Parameters.Add(ParametroLocalidad);
            command.Parameters.Add(ParametroActivo);
			command.Parameters.Add(ParametroNick);
            command.Parameters.Add(ParametroBaneado);
            command.Parameters.Add(ParametroDni);

		    command.ExecuteNonQuery();
            conexion.Dispose();
            }
             public Usuario Consulta (long id)
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
			command.CommandText= "ConsultaUsuario";

			SqlParameter ParametroIdUsuario = new SqlParameter();
			ParametroIdUsuario.Value = id;
			ParametroIdUsuario.ParameterName="@IdUsuario";

			command.Parameters.Add(ParametroIdUsuario);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Usuario usuario = new Usuario();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           usuario.Nombre = reader.GetString(0);

                        if (!reader.IsDBNull(1))
                           usuario.Apellidos = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                           usuario.CorreoElectronico = reader.GetString(2);
                        
                        if (!reader.IsDBNull(3))
                           usuario.Telefono = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                           usuario.Movil = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                           usuario.Pais = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                           usuario.Provincia = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                           usuario.Localidad =  reader.GetString(7);
                        if (!reader.IsDBNull(8))
                           usuario.Activo = reader.GetBoolean(8);
                }
                }
            conexion.Dispose();
            return usuario;
            }

         public List<Usuario> ConsultaAll()
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
			command.CommandText= "ConsultaAllUsuario";
            			
			SqlDataReader reader =  command.ExecuteReader();
            List<Usuario> ListadoUsuario = new List<Usuario>();
		    Usuario usuario = new Usuario();

                         
                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           usuario.Nombre = reader.GetString(0);

                        if (!reader.IsDBNull(1))
                           usuario.Apellidos = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                           usuario.CorreoElectronico = reader.GetString(2);
                        
                        if (!reader.IsDBNull(3))
                           usuario.Telefono = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                           usuario.Movil = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                           usuario.Pais = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                           usuario.Provincia = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                           usuario.Localidad =  reader.GetString(7);
                        if (!reader.IsDBNull(8))
                           usuario.Activo = reader.GetBoolean(8);
                }
                }
            conexion.Dispose();
            return ListadoUsuario;
            }

        public long ConsultaSacaIdByNick (string Nick)
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
			command.CommandText= "ConsultaUsuarioNickById";

			SqlParameter ParametroIdUsuario = new SqlParameter();
			ParametroIdUsuario.Value = Nick;
			ParametroIdUsuario.ParameterName="@Nick";

			command.Parameters.Add(ParametroIdUsuario);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			  long id = 0;
                
                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           id = reader.GetInt64(0);
                         }
                         }
        
            conexion.Dispose();
           return id;


       }

        public bool Activo(long IdUser)
            {
            string  Nick;
            bool retorno = false;
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
			command.CommandText= "ConsultaUsuarioActivo";

			SqlParameter ParametroIdUsuario = new SqlParameter();
			ParametroIdUsuario.Value = IdUser;
			ParametroIdUsuario.ParameterName="@IdUsuario";

			command.Parameters.Add(ParametroIdUsuario);
			
			
			SqlDataReader reader =  command.ExecuteReader();
                
                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       retorno= true;
                        if (!reader.IsDBNull(0))
                          Nick = reader.GetString(0);
                         }
                         }
        
            conexion.Dispose();
         

            return retorno;
            }
         public Usuario ConsultaBaneado (long id)
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
			command.CommandText= "ConsultaBaneado";

			SqlParameter ParametroIdUsuario = new SqlParameter();
			ParametroIdUsuario.Value = id;
			ParametroIdUsuario.ParameterName="@IdUsuario";

			command.Parameters.Add(ParametroIdUsuario);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Usuario usuario = new Usuario();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           usuario.Nombre = reader.GetString(0);

                        if (!reader.IsDBNull(1))
                           usuario.Apellidos = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                           usuario.CorreoElectronico = reader.GetString(2);
                        
                        if (!reader.IsDBNull(3))
                           usuario.Telefono = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                           usuario.Movil = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                           usuario.Pais = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                           usuario.Provincia = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                           usuario.Localidad =  reader.GetString(7);
                        if (!reader.IsDBNull(8))
                           usuario.Activo = reader.GetBoolean(8);
                    }
                }
            conexion.Dispose();
            return usuario;
            }

        public List<Usuario> ConsultaAllBaneado()
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
			command.CommandText= "ConsultaAllUsuarioBaneado";
            			
			SqlDataReader reader =  command.ExecuteReader();
            List<Usuario> ListadoUsuario = new List<Usuario>();
		    Usuario usuario = new Usuario();

                         
                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           usuario.Nombre = reader.GetString(0);

                        if (!reader.IsDBNull(1))
                           usuario.Apellidos = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                           usuario.CorreoElectronico = reader.GetString(2);
                        
                        if (!reader.IsDBNull(3))
                           usuario.Telefono = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                           usuario.Movil = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                           usuario.Pais = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                           usuario.Provincia = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                           usuario.Localidad =  reader.GetString(7);
                        if (!reader.IsDBNull(8))
                           usuario.Activo = reader.GetBoolean(8);
                }
                }
            conexion.Dispose();
            return ListadoUsuario;
            }

         public List<Usuario> ConsultaAllNoActivos()
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
			command.CommandText= "ConsultaAllUsuarioSinActivar";
            			
			SqlDataReader reader =  command.ExecuteReader();
            List<Usuario> ListadoUsuario = new List<Usuario>();
		    Usuario usuario; 

                         
                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        usuario  = new Usuario();
                        if (!reader.IsDBNull(0))
                           usuario.Nombre = reader.GetString(0);

                        if (!reader.IsDBNull(1))
                           usuario.Apellidos = reader.GetString(1);

                        if (!reader.IsDBNull(2))
                           usuario.CorreoElectronico = reader.GetString(2);
                        
                        if (!reader.IsDBNull(3))
                           usuario.Telefono = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                           usuario.Movil = reader.GetString(4);
                        if (!reader.IsDBNull(5))
                           usuario.Pais = reader.GetString(5);
                        if (!reader.IsDBNull(6))
                           usuario.Provincia = reader.GetString(6);
                        if (!reader.IsDBNull(7))
                           usuario.Localidad =  reader.GetString(7);
                        if (!reader.IsDBNull(8))
                           usuario.Activo = reader.GetBoolean(8);
                        if (!reader.IsDBNull(9))
                           usuario.Id = reader.GetInt64(9);
                        ListadoUsuario.Add(usuario);
                }
                }
            conexion.Dispose();
            return ListadoUsuario;
            }

        public void ActivarUser(long IdUser)
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
			command.CommandText= "ActivarUsuario";

            //Parametros a utilizar
            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= IdUser;
			ParametroId.ParameterName="@IdUsuario"; 
            command.Parameters.Add(ParametroId);
           

		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        }
    }