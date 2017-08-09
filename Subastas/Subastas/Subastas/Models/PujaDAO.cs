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
    public class PujaDAO
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(Puja puja)
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
			command.CommandText= "AltaPuja";

            //Parametros a utilizar
            SqlParameter ParametroIdUsuario = new SqlParameter();
	     	ParametroIdUsuario.Value= puja.IdUsuario;
            ParametroIdUsuario.ParameterName="@IdUsuario";

            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= puja.IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroPujaActual = new SqlParameter();
	     	ParametroPujaActual.Value= puja.PujaActual;
			ParametroPujaActual.ParameterName="@PujaActual";           
          
            command.Parameters.Add(ParametroIdUsuario);
            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroPujaActual);
			
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
			command.CommandText= "BajaPuja";

            //Parametros a utilizar
			SqlParameter ParametroIdPuja = new SqlParameter();
			ParametroIdPuja.Value= Id;
			ParametroIdPuja.ParameterName="@IdPuja";
            command.Parameters.Add(ParametroIdPuja);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void BajaPorUsuario(long IdUsuario)
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
			command.CommandText= "BajaPujaByUser";

            //Parametros a utilizar
			SqlParameter ParametroIdUsuario = new SqlParameter();
			ParametroIdUsuario.Value= IdUsuario;
			ParametroIdUsuario.ParameterName="@IdUsuario";
            command.Parameters.Add(ParametroIdUsuario);

		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(Puja puja)
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
			command.CommandText= "ModificacionArticulo";

            //Parametros a utilizar
            SqlParameter ParametroIdUsuario = new SqlParameter();
	     	ParametroIdUsuario.Value= puja.IdUsuario;
            ParametroIdUsuario.ParameterName="@IdUsuario";

            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= puja.IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroPujaActual = new SqlParameter();
	     	ParametroPujaActual.Value= puja.PujaActual;
			ParametroPujaActual.ParameterName="@PujaActual";           
          
            command.Parameters.Add(ParametroIdUsuario);
            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroPujaActual);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        

        public Puja Consulta (int id)
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
			command.CommandText= "ConsultaPuja";

			SqlParameter ParametroIdPuja = new SqlParameter();
			ParametroIdPuja.Value = id;
			ParametroIdPuja.ParameterName="@IdPuja";

			command.Parameters.Add(ParametroIdPuja);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Puja puja = new Puja();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           puja.IdUsuario = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           puja.IdArticulo = reader.GetInt64(1);
                        if (!reader.IsDBNull(2))
                           puja.PujaActual = reader.GetDecimal(2);
                                    
                }
                }
            conexion.Dispose();
            return puja;
            }

         public List<Puja> ConsultaAll()
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
			command.CommandText= "ConsultaAllPuja";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Puja> ListadoPuja = new List<Puja>();
			Puja puja = new Puja();

                      

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           puja.IdUsuario = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           puja.IdArticulo = reader.GetInt64(1);
                        if (!reader.IsDBNull(2))
                           puja.PujaActual = reader.GetDecimal(2);
                             ListadoPuja.Add(puja);       
                }
                }
            conexion.Dispose();
            return ListadoPuja;
            }
        /// <summary>
        /// Captura Todas las pujas hechas por un usuario
        /// </summary>
        /// <returns></returns>
        public List<Puja> ConsultaAllPujasArticulosByIdUsuario()
            {
        
            String cadenaconexion = null;
			//consulta sql para autenticar, si es correcto el logeo creamos el ticket de autorizacion y si
			// retornamos a la vista de login
		    long IdArticuloTemporal = -1;
			Configuracion  conf = new Configuracion();
		    cadenaconexion = conf.LeerCadenaCompleta();
                
			SqlConnection conexion = null;
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "ConsultaPujaIdUsuario";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Puja> ListadoPuja = new List<Puja>();
			Puja puja = new Puja();

                      

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                      
                    
                           
                        if (!reader.IsDBNull(0))
                        { 
                           puja.IdArticulo = reader.GetInt64(1);
                              if(puja.IdArticulo ==IdArticuloTemporal)
                                {
                                    continue;
                                }
                              else
                                {
                                    IdArticuloTemporal = puja.IdArticulo;
                                }
                        }

                        if (!reader.IsDBNull(1))
                           puja.PujaActual = reader.GetDecimal(2);
                             ListadoPuja.Add(puja);       
                }
                }

            conexion.Dispose();
            return ListadoPuja;
            }

         public decimal ConsultaPrecio (long id)
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
			command.CommandText= "ConsultaPujaPrecio";

			SqlParameter ParametroIdPuja = new SqlParameter();
			ParametroIdPuja.Value = id;
			ParametroIdPuja.ParameterName="@IdArticulo";

			command.Parameters.Add(ParametroIdPuja);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Decimal puja = 0;

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {                
                        if (!reader.IsDBNull(0))
                           puja= reader.GetDecimal(0);                               
                }
                }
            conexion.Dispose();
            return puja;
            }
       //Consulta donde devuelve el ultimo usuario que ha pujado por ese articulo
        public long ConsultaPujaIdUsuario (long IdArticulo)
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
			command.CommandText= "ConsultaPujaIdUsuario";

			SqlParameter ParametroIdPuja = new SqlParameter();
			ParametroIdPuja.Value = IdArticulo;
			ParametroIdPuja.ParameterName="@IdArticulo";

			command.Parameters.Add(ParametroIdPuja);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      long iduser = 0;

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {               
                        if (!reader.IsDBNull(0))
                           iduser= reader.GetInt64(0);                               
                        }
                       }
            conexion.Dispose();
            return iduser;
            }

         public List<object> PujasUsuario (int id)
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
			command.CommandText= "ConsultaPujaByUser";

			SqlParameter ParametroIdUsuario = new SqlParameter();
			ParametroIdUsuario.Value = id;
			ParametroIdUsuario.ParameterName="@IdUsuario";

			command.Parameters.Add(ParametroIdUsuario);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Puja puja;
                  Articulo art;
                  List<object> listadopuja = new List<object>();
            
                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {                
                          art = new Articulo();
                          puja = new Puja();       
                        if (!reader.IsDBNull(0))
                           puja.IdUsuario = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           art.IdArticulo = reader.GetInt64(1);
                        if (!reader.IsDBNull(2)) { 
                           puja.PujaActual = reader.GetDecimal(2);
                        }   
                        if (!reader.IsDBNull(3)) { 
                           art.FotoPrincipal = reader.GetString(3);
                        }  
                        if (!reader.IsDBNull(4)) { 
                           art.Titulo = reader.GetString(4);
                        }  

                        listadopuja.Add(puja);  
                        listadopuja.Add(art);     
                        }
                         
                        }
            conexion.Dispose();
            return listadopuja;
            }

        }
    }
    