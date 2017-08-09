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
    public class FotoDAO
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(Foto foto)
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
			command.CommandText= "AltaFoto";

            //Parametros a utilizar
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= foto.IdArticulo;
            ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroDireccion = new SqlParameter();
	     	ParametroDireccion.Value= foto.Direccion;
			ParametroDireccion.ParameterName="@Direccion";

            command.Parameters.Add(ParametroIdArticulo);
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
			command.CommandText= "BajaFoto";

            //Parametros a utilizar
			SqlParameter ParametroIdArticulo = new SqlParameter();
			ParametroIdArticulo.Value= Id;
			ParametroIdArticulo.ParameterName="@IdArticulo";
            command.Parameters.Add(ParametroIdArticulo);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(Foto foto)
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
			command.CommandText= "ModificacionFoto";

            //Parametros a utilizar
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= foto.IdArticulo;
            ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroDireccion = new SqlParameter();
	     	ParametroDireccion.Value= foto.Direccion;
			ParametroDireccion.ParameterName="@Direccion";

            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroDireccion);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public List<Foto> ConsultaAllById (long IdArticulo)
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
			command.CommandText= "ConsultaFoto";

			SqlParameter ParametroIdArticulo = new SqlParameter();
			ParametroIdArticulo.Value = IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

			command.Parameters.Add(ParametroIdArticulo);
			
			
			SqlDataReader reader =  command.ExecuteReader();
                    List<Foto> FotosSexys =new List<Foto>();
			      Foto foto; 

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                      foto = new Foto();
                        if (!reader.IsDBNull(0))
                           foto.Direccion = reader.GetString(0);

                    FotosSexys.Add(foto);
                }
                }
            conexion.Dispose();
            return FotosSexys;
            }

         public List<Foto> ConsultaAll()
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
			command.CommandText= "ConsultaAllFoto";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Foto> ListadoFoto = new List<Foto>();
			
			      Foto foto = new Foto();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           foto.Direccion = reader.GetString(0);

                    ListadoFoto.Add(foto);
                }
                }
            conexion.Dispose();
            return ListadoFoto;
            }
       
        }
    }