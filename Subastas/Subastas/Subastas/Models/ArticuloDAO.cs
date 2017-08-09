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
    public class ArticuloDAO
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(Articulo articulo)
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
			command.CommandText= "AltaArticulo";

            //Parametros a utilizar
            SqlParameter ParametroCategoria = new SqlParameter();
	     	ParametroCategoria.Value= articulo.Categoria;
            ParametroCategoria.ParameterName="@Categoria";

            SqlParameter ParametroTitulo = new SqlParameter();
	     	ParametroTitulo.Value= articulo.Titulo;
			ParametroTitulo.ParameterName="@Titulo";

            SqlParameter ParametroDescripcion = new SqlParameter();
	     	ParametroDescripcion.Value= articulo.Descripcion;
			ParametroDescripcion.ParameterName="@Descripcion";

            SqlParameter ParametroStock = new SqlParameter();
	     	ParametroStock.Value= articulo.Stock;
			ParametroStock.ParameterName="@Stock";

            SqlParameter ParametroFecha = new SqlParameter();
	     	ParametroFecha.Value= articulo.Fecha;
			ParametroFecha.ParameterName="@Fecha";

            SqlParameter ParametroPrecioInicial= new SqlParameter();
	     	ParametroPrecioInicial.Value= articulo.PrecioInicial;
			ParametroPrecioInicial.ParameterName="@PrecioInicial";

            SqlParameter ParametroFechaFinal= new SqlParameter();
	     	ParametroFechaFinal.Value= articulo.FechaFinal;
			ParametroFechaFinal.ParameterName="@FechaFinal";
          
            SqlParameter ParametroActivo= new SqlParameter();
	     	ParametroActivo.Value= articulo.Activo;
			ParametroActivo.ParameterName="@Activo";

            SqlParameter ParametroFotoPrincipal= new SqlParameter();
	     	ParametroFotoPrincipal.Value= articulo.FotoPrincipal;
			ParametroFotoPrincipal.ParameterName="@FotoPrincipal";

            SqlParameter ParametroCompra = new SqlParameter();
	     	ParametroCompra.Value= articulo.Comprado;
			ParametroCompra.ParameterName="@Comprado";
          
            command.Parameters.Add(ParametroCategoria);
            command.Parameters.Add(ParametroTitulo);
            command.Parameters.Add(ParametroDescripcion);
			command.Parameters.Add(ParametroStock);
            command.Parameters.Add(ParametroFecha);
            command.Parameters.Add(ParametroPrecioInicial);
            command.Parameters.Add(ParametroFechaFinal);
            command.Parameters.Add(ParametroActivo);
            command.Parameters.Add(ParametroFotoPrincipal);
            command.Parameters.Add(ParametroCompra);

		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void AltaSinFoto(Articulo articulo)
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
			command.CommandText= "AltaArticuloSinFoto";

            //Parametros a utilizar
            SqlParameter ParametroCategoria = new SqlParameter();
	     	ParametroCategoria.Value= articulo.Categoria;
            ParametroCategoria.ParameterName="@Categoria";

            SqlParameter ParametroTitulo = new SqlParameter();
	     	ParametroTitulo.Value= articulo.Titulo;
			ParametroTitulo.ParameterName="@Titulo";

            SqlParameter ParametroDescripcion = new SqlParameter();
	     	ParametroDescripcion.Value= articulo.Descripcion;
			ParametroDescripcion.ParameterName="@Descripcion";

            SqlParameter ParametroStock = new SqlParameter();
	     	ParametroStock.Value= articulo.Stock;
			ParametroStock.ParameterName="@Stock";

            SqlParameter ParametroFecha = new SqlParameter();
	     	ParametroFecha.Value= articulo.Fecha;
			ParametroFecha.ParameterName="@Fecha";

            SqlParameter ParametroPrecioInicial= new SqlParameter();
	     	ParametroPrecioInicial.Value= articulo.PrecioInicial;
			ParametroPrecioInicial.ParameterName="@PrecioInicial";

            SqlParameter ParametroFechaFinal= new SqlParameter();
	     	ParametroFechaFinal.Value= articulo.FechaFinal;
			ParametroFechaFinal.ParameterName="@FechaFinal";
          
            SqlParameter ParametroActivo= new SqlParameter();
	     	ParametroActivo.Value= articulo.Activo;
			ParametroActivo.ParameterName="@Activo";

            SqlParameter ParametroFotoPrincipal= new SqlParameter();
	     	ParametroFotoPrincipal.Value= articulo.FotoPrincipal;
			ParametroFotoPrincipal.ParameterName="@FotoPrincipal";

            SqlParameter ParametroCompra = new SqlParameter();
	     	ParametroCompra.Value= articulo.Comprado;
			ParametroCompra.ParameterName="@Comprado";
          
            command.Parameters.Add(ParametroCategoria);
            command.Parameters.Add(ParametroTitulo);
            command.Parameters.Add(ParametroDescripcion);
			command.Parameters.Add(ParametroStock);
            command.Parameters.Add(ParametroFecha);
            command.Parameters.Add(ParametroPrecioInicial);
            command.Parameters.Add(ParametroFechaFinal);
            command.Parameters.Add(ParametroActivo);
            command.Parameters.Add(ParametroCompra);

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
			command.CommandText= "BajaArticulo";

            //Parametros a utilizar
			SqlParameter ParametroIdArticulo = new SqlParameter();
			ParametroIdArticulo.Value= Id;
			ParametroIdArticulo.ParameterName="@IdArticulo";
            command.Parameters.Add(ParametroIdArticulo);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(Articulo articulo)
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
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= articulo.IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroCategoria = new SqlParameter();
	     	ParametroCategoria.Value= articulo.Categoria;
            ParametroCategoria.ParameterName="@Categoria";

            SqlParameter ParametroTitulo = new SqlParameter();
	     	ParametroTitulo.Value= articulo.Titulo;
			ParametroTitulo.ParameterName="@Titulo";

            SqlParameter ParametroDescripcion = new SqlParameter();
	     	ParametroDescripcion.Value= articulo.Descripcion;
			ParametroDescripcion.ParameterName="@Descripcion";

            SqlParameter ParametroStock = new SqlParameter();
	     	ParametroStock.Value= articulo.Stock;
			ParametroStock.ParameterName="@Stock";

            SqlParameter ParametroFecha = new SqlParameter();
	     	ParametroFecha.Value= articulo.Fecha;
			ParametroFecha.ParameterName="@Fecha";

            SqlParameter ParametroPrecioInicial= new SqlParameter();
	     	ParametroPrecioInicial.Value= articulo.PrecioInicial;
			ParametroPrecioInicial.ParameterName="@PrecioInicial";

            SqlParameter ParametroFechaFinal= new SqlParameter();
	     	ParametroFechaFinal.Value= articulo.FechaFinal;
			ParametroFechaFinal.ParameterName="@FechaFinal";
          
            SqlParameter ParametroActivo= new SqlParameter();
	     	ParametroActivo.Value= articulo.Activo;
			ParametroActivo.ParameterName="@Activo";

            SqlParameter ParametroFotoPrincipal= new SqlParameter();
	     	ParametroFotoPrincipal.Value= articulo.FotoPrincipal;
			ParametroFotoPrincipal.ParameterName="@FotoPrincipal";

            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroCategoria);
            command.Parameters.Add(ParametroTitulo);
            command.Parameters.Add(ParametroDescripcion);
			command.Parameters.Add(ParametroStock);
            command.Parameters.Add(ParametroFecha);
            command.Parameters.Add(ParametroPrecioInicial);
		    command.Parameters.Add(ParametroFechaFinal);
            command.Parameters.Add(ParametroActivo);
            command.Parameters.Add(ParametroFotoPrincipal);

		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public void ModificacionFoto(long IdArticulo, String FotoPrincipal)
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
			command.CommandText= "ModificacionArticuloFoto";

            //Parametros a utilizar
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroFotoPrincipal= new SqlParameter();
	     	ParametroFotoPrincipal.Value= FotoPrincipal;
			ParametroFotoPrincipal.ParameterName="@FotoPrincipal";

            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroFotoPrincipal);

		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public void ModificacionActivarComprado(long IdArticulo)
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
			command.CommandText= "ActivarCompradoArticulo";

            //Parametros a utilizar
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

         
            command.Parameters.Add(ParametroIdArticulo);
            

		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public Articulo Consulta (long id)
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
			command.CommandText= "ConsultaArticulo";

			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value = id;
			ParametroId.ParameterName="@IdArticulo";

			command.Parameters.Add(ParametroId);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Articulo articulo = new Articulo();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                         
                        if (!reader.IsDBNull(0))
                           articulo.Categoria = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           articulo.Titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                           articulo.Descripcion = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            articulo.Stock = reader.GetInt32(3);
                        if (!reader.IsDBNull(4)) { 
                            articulo.Fecha = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5)) { 
                            articulo.PrecioInicial = reader.GetDecimal(5);
                        }               
                        if (!reader.IsDBNull(6)) { 
                            articulo.FechaFinal = reader.GetDateTime(6);
                        }   
                         if (!reader.IsDBNull(7)) { 
                            articulo.Activo = reader.GetBoolean(7);
                        }    
                         if (!reader.IsDBNull(8)) { 
                            articulo.FotoPrincipal = reader.GetString(8);
                        }   
                         if (!reader.IsDBNull(9)) { 
                            articulo.IdArticulo = reader.GetInt64(9);
                        }                   
                        articulo.Activado=false;
                        articulo.Tipo = "";
                        articulo.Mensaje ="";
                }
                }
            conexion.Dispose();
            return articulo;
            }

         public Articulo ConsultaUltimoArticulo ()
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
			command.CommandText= "ConsultaArticuloUltimo";

		
			SqlDataReader reader =  command.ExecuteReader();

			      Articulo articulo = new Articulo();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                         
                        if (!reader.IsDBNull(0))
                           articulo.IdArticulo = reader.GetInt64(0);                  
                }
                }
            conexion.Dispose();
            return articulo;
            }

         public List<Articulo> ConsultaAll()
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
			command.CommandText= "ConsultaAllArticuloMax5";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Articulo> ListadoArticulo = new List<Articulo>();
			Articulo articulo ;

                            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        articulo = new Articulo();
                        if (!reader.IsDBNull(0))
                           articulo.Categoria = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           articulo.Titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                           articulo.Descripcion = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            articulo.Stock = reader.GetInt32(3);
                        if (!reader.IsDBNull(4)) { 
                            articulo.Fecha = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5)) { 
                            articulo.PrecioInicial = reader.GetDecimal(5);
                        }               
                        if (!reader.IsDBNull(6)) { 
                            articulo.FechaFinal = reader.GetDateTime(6);
                        }   
                        if (!reader.IsDBNull(7)) { 
                            articulo.Activo = reader.GetBoolean(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                            articulo.FotoPrincipal = reader.GetString(8);
                        }  
                        if (!reader.IsDBNull(9)) { 
                            articulo.IdArticulo = reader.GetInt64(9);
                        }  
                          
                         ListadoArticulo.Add(articulo);                     
                }
                }
            conexion.Dispose();
            return ListadoArticulo;
            }

        public List<Articulo> ConsultaAllTodo()
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
			command.CommandText= "ConsultaAllArticulo";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Articulo> ListadoArticulo = new List<Articulo>();
			Articulo articulo ;

                            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        articulo = new Articulo();
                        if (!reader.IsDBNull(0))
                           articulo.Categoria = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           articulo.Titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                           articulo.Descripcion = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            articulo.Stock = reader.GetInt32(3);
                        if (!reader.IsDBNull(4)) { 
                            articulo.Fecha = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5)) { 
                            articulo.PrecioInicial = reader.GetDecimal(5);
                        }               
                        if (!reader.IsDBNull(6)) { 
                            articulo.FechaFinal = reader.GetDateTime(6);
                        }   
                        if (!reader.IsDBNull(7)) { 
                            articulo.Activo = reader.GetBoolean(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                            articulo.FotoPrincipal = reader.GetString(8);
                        }  
                        if (!reader.IsDBNull(9)) { 
                            articulo.IdArticulo = reader.GetInt64(9);
                        }  
                          
                         ListadoArticulo.Add(articulo);                     
                }
                }
            conexion.Dispose();
            return ListadoArticulo;
            }

        public List<Articulo> ConsultaAllNoActivo()
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
			command.CommandText= "ConsultaAllArticuloDesactivados";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Articulo> ListadoArticulo = new List<Articulo>();
			Articulo articulo;

                            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        articulo = new Articulo();
                        if (!reader.IsDBNull(0))
                           articulo.Categoria = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           articulo.Titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                           articulo.Descripcion = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            articulo.Stock = reader.GetInt32(3);
                        if (!reader.IsDBNull(4)) { 
                            articulo.Fecha = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5)) { 
                            articulo.PrecioInicial = reader.GetDecimal(5);
                        }               
                        if (!reader.IsDBNull(6)) { 
                            articulo.FechaFinal = reader.GetDateTime(6);
                        }   
                        if (!reader.IsDBNull(7)) { 
                            articulo.Activo = reader.GetBoolean(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                            articulo.FotoPrincipal = reader.GetString(8);
                        }  
                        if (!reader.IsDBNull(9)) { 
                            articulo.IdArticulo = reader.GetInt64(9);
                        }  
                          
                         ListadoArticulo.Add(articulo);                     
                }
                }
            conexion.Dispose();
            return ListadoArticulo;
            }

         public List<Articulo> ConsultaAllPaginado (int? Pagina)
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
			command.CommandText= "ConsultaAllArticulo";
				
			List<Articulo> ListadoArticulo = new List<Articulo>();
			SqlDataReader reader =  command.ExecuteReader();

			      Articulo articulo; 

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        articulo = new Articulo();
                        if (!reader.IsDBNull(0))
                           articulo.Categoria = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           articulo.Titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                           articulo.Descripcion = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            articulo.Stock = reader.GetInt32(3);
                        if (!reader.IsDBNull(4)) { 
                            articulo.Fecha = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5)) { 
                            articulo.PrecioInicial = reader.GetDecimal(5);
                        }               
                        if (!reader.IsDBNull(6)) { 
                            articulo.FechaFinal = reader.GetDateTime(6);
                        }   
                         if (!reader.IsDBNull(7)) { 
                            articulo.Activo = reader.GetBoolean(7);
                        }    
                         if (!reader.IsDBNull(8)) { 
                            articulo.FotoPrincipal = reader.GetString(8);
                        }   
                         if (!reader.IsDBNull(9)) { 
                            articulo.IdArticulo = reader.GetInt64(9);
                        }
                    ListadoArticulo.Add(articulo);
                    articulo.Activado=false;
                    articulo.Mensaje="";
                    articulo.Tipo="";                   
                }
                }

            conexion.Dispose();
        List<Articulo> ListadoParcialArticulo = new List<Articulo>(); 
            
            if((Pagina==1 || Pagina==null) && ListadoArticulo.Count>0) { 
                if(ListadoArticulo.Count>=21) { 
            for(int i=0; i<21; i++ )
                    {
                    ListadoParcialArticulo.Add(ListadoArticulo[i]);
                    }
                }
                else
                    {
                     for(int i=0; i<ListadoArticulo.Count; i++ )
                    {
                    ListadoParcialArticulo.Add(ListadoArticulo[i]);
                    }
                }
                    }
                
            else
                {
                if(ListadoArticulo.Count()>= (Pagina*21) && ListadoArticulo.Count>0) { 
                for(int? i= Pagina*10; i<Pagina*21; i++ )
                    {
                    ListadoParcialArticulo.Add(ListadoArticulo[(int)i]);
                    }
                }
                else
                    {
                    for(int? i= Pagina*10; i<ListadoArticulo.Count; i++ )
                    {
                    ListadoParcialArticulo.Add(ListadoArticulo[(int)i]);
                    }
                    }
                }
            return ListadoParcialArticulo;
            }

         public void DesactivarArticulo(long IdArticulo)
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
			command.CommandText= "DesactivarArticulo";

            //Parametros a utilizar
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            command.Parameters.Add(ParametroIdArticulo);
           
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }
       
        public void ActivarArticulo(long IdArticulo)
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
			command.CommandText= "ActivarArticulo";

            //Parametros a utilizar
            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            command.Parameters.Add(ParametroIdArticulo);
           
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public List<Articulo> ConsultaAllArticuloComprado()
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
			command.CommandText= "ConsultaAllArticuloComprado";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Articulo> ListadoArticulo = new List<Articulo>();
			Articulo articulo ;

                            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        articulo = new Articulo();
                        if (!reader.IsDBNull(0))
                           articulo.Categoria = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           articulo.Titulo = reader.GetString(1);
                        if (!reader.IsDBNull(2))
                           articulo.Descripcion = reader.GetString(2);
                        if (!reader.IsDBNull(3))
                            articulo.Stock = reader.GetInt32(3);
                        if (!reader.IsDBNull(4)) { 
                            articulo.Fecha = reader.GetDateTime(4);
                        }
                        if (!reader.IsDBNull(5)) { 
                            articulo.PrecioInicial = reader.GetDecimal(5);
                        }               
                        if (!reader.IsDBNull(6)) { 
                            articulo.FechaFinal = reader.GetDateTime(6);
                        }   
                        if (!reader.IsDBNull(7)) { 
                            articulo.Activo = reader.GetBoolean(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                            articulo.FotoPrincipal = reader.GetString(8);
                        }  
                        if (!reader.IsDBNull(9)) { 
                            articulo.IdArticulo = reader.GetInt64(9);
                        }  
                          
                         ListadoArticulo.Add(articulo);                     
                }
                }
            conexion.Dispose();
            return ListadoArticulo;
            }

        }
    }