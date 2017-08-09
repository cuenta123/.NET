using DataAccessService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Security;

namespace Multigas_Enertica.Models
    {
    public class NoticiasDAO
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        

        public Noticias Consulta (int id)
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
			command.CommandText= "ConsultaNoticias";

			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value = id;
			ParametroId.ParameterName="@Id";

			command.Parameters.Add(ParametroId);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			       Noticias noticia = new Noticias();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        if (!reader.IsDBNull(0))
                            noticia.IdNoticias = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           noticia.Titulo = reader.GetString(1);
                         if (!reader.IsDBNull(2))
                           noticia.Entrada = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                           noticia.Descripcion = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                            noticia.Principal = reader.GetBoolean(4);
                        if (!reader.IsDBNull(5)) { 
                            noticia.Destacado = reader.GetBoolean(5);
                        }
                        if (!reader.IsDBNull(6)) { 
                            noticia.Normal = reader.GetBoolean(6);
                        }
                        if (!reader.IsDBNull(7))
                           noticia.FotoPrincipal = reader.GetString(7);
                    }
                }
            conexion.Dispose();
            return noticia;
            }

         public List<Noticias> ConsultaAll ()
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
			command.CommandText= "ConsultaAllNoticias";			
			SqlDataReader reader =  command.ExecuteReader();
             List<Noticias> ListadoNoticias = new List<Noticias>();
			       Noticias noticia = new Noticias();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        if (!reader.IsDBNull(0))
                            noticia.IdNoticias = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           noticia.Titulo = reader.GetString(1);
                         if (!reader.IsDBNull(2))
                           noticia.FotoPrincipal= reader.GetString(2);
                        if (!reader.IsDBNull(3))
                           noticia.Entrada = reader.GetString(3);
                      
                      ListadoNoticias.Add(noticia);
                    }
                }
            conexion.Dispose();
            return ListadoNoticias;
            }

         public Noticias Principal ()
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
			command.CommandText= "PrincipalNoticias";	
            		
			SqlDataReader reader =  command.ExecuteReader();
             List<Noticias> ListadoNoticias = new List<Noticias>();
			       Noticias noticia = new Noticias();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        if (!reader.IsDBNull(0))
                            noticia.IdNoticias = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           noticia.Titulo = reader.GetString(1);
                         if (!reader.IsDBNull(2))
                           noticia.FotoPrincipal= reader.GetString(2);
                        if (!reader.IsDBNull(3))
                           noticia.Entrada = reader.GetString(3);
                      
                    
                    }
                }
            conexion.Dispose();
            return noticia;
            }

         public List<Noticias> DestacadoNoticias ()
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
			command.CommandText= "DestacadoNoticias";	
            		
			SqlDataReader reader =  command.ExecuteReader();
             List<Noticias> ListadoNoticias = new List<Noticias>();
			     long IdNoticias = -1;
                 string Titulo = null;
                 string FotoPrincipal = null;
                 string Entrada = null;

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        if (!reader.IsDBNull(0))
                         IdNoticias = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           Titulo = reader.GetString(1);
                         if (!reader.IsDBNull(2))
                           FotoPrincipal= reader.GetString(2);
                        if (!reader.IsDBNull(3))
                           Entrada = reader.GetString(3);
                      
                      ListadoNoticias.Add(new Noticias(IdNoticias,Titulo,Entrada,FotoPrincipal));
                    }
                }
            conexion.Dispose();
            return ListadoNoticias;
            }


        public List<Noticias> NormalNoticias ()
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
			command.CommandText= "NormalNoticias";	
            		
			SqlDataReader reader =  command.ExecuteReader();
                List<Noticias> ListadoNoticias = new List<Noticias>();
               long IdNoticias = -1;
                 string Titulo = null;
                 string FotoPrincipal = null;
                 string Entrada = null;

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        if (!reader.IsDBNull(0))
                         IdNoticias = reader.GetInt64(0);
                        if (!reader.IsDBNull(1))
                           Titulo = reader.GetString(1);
                         if (!reader.IsDBNull(2))
                           FotoPrincipal= reader.GetString(2);
                        if (!reader.IsDBNull(3))
                           Entrada = reader.GetString(3);
                      
                      ListadoNoticias.Add(new Noticias(IdNoticias,Titulo,Entrada,FotoPrincipal));
                    }
                }
            conexion.Dispose();
            return ListadoNoticias;
            }
        }

     
    }