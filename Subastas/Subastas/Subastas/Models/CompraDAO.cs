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
    public class CompraDAO
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(Compra compra)
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
			command.CommandText= "AltaCompra";

            //Parametros a utilizar
             SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= compra.IdArticulo;
            ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroFecha = new SqlParameter();
	     	ParametroFecha.Value= compra.Fecha;
            ParametroFecha.ParameterName="@Fecha";

            SqlParameter ParametroIdUsuario = new SqlParameter();
	     	ParametroIdUsuario.Value= compra.IdUsuario;
			ParametroIdUsuario.ParameterName="@IdUsuario";
            
            SqlParameter ParametroPrecio = new SqlParameter();
	     	ParametroPrecio.Value= compra.Precio;
			ParametroPrecio.ParameterName="@Precio";

            
          
            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroFecha);
            command.Parameters.Add(ParametroIdUsuario);
			command.Parameters.Add(ParametroPrecio);
            
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
			command.CommandText= "BajaCompra";

            //Parametros a utilizar
			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value= Id;
			ParametroId.ParameterName="@Id";
            command.Parameters.Add(ParametroId);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(Compra compra)
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
			command.CommandText= "ModificacionCompra";

            //Parametros a utilizar

            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= compra.Id;
            ParametroId.ParameterName="@Id";

            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= compra.IdArticulo;
            ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroFecha = new SqlParameter();
	     	ParametroFecha.Value= compra.Fecha;
            ParametroFecha.ParameterName="@Fecha";

            SqlParameter ParametroIdUsuario = new SqlParameter();
	     	ParametroIdUsuario.Value= compra.IdUsuario;
			ParametroIdUsuario.ParameterName="@IdUsuario";

            SqlParameter ParametroPrecio = new SqlParameter();
	     	ParametroPrecio.Value= compra.Precio;
			ParametroPrecio.ParameterName="@Precio";
            
            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroFecha);
            command.Parameters.Add(ParametroIdUsuario);
            command.Parameters.Add(ParametroPrecio);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }

        public void ModificacionRetornoUser(long Id, long IdUsuario, long IdArticulo, decimal Precio)
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
			command.CommandText= "ModificacionRetornoUser";

            //Parametros a utilizar
            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= Id;
            ParametroId.ParameterName="@Id";

            SqlParameter ParametroIdUsuario = new SqlParameter();
	     	ParametroIdUsuario.Value= IdUsuario;
            ParametroIdUsuario.ParameterName="@IdUsuario";

            SqlParameter ParametroIdArticulo = new SqlParameter();
	     	ParametroIdArticulo.Value= IdArticulo;
			ParametroIdArticulo.ParameterName="@IdArticulo";

            SqlParameter ParametroPujaActual = new SqlParameter();
	     	ParametroPujaActual.Value= Precio;
			ParametroPujaActual.ParameterName="@Precio";           
          
            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroIdUsuario);
            command.Parameters.Add(ParametroIdArticulo);
            command.Parameters.Add(ParametroPujaActual);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }


        public Compra Consulta (int id)
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
			command.CommandText= "ConsultaCompra";

			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value = id;
			ParametroId.ParameterName="@Id";

			command.Parameters.Add(ParametroId);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Compra compra = new Compra();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           compra.IdUsuario = reader.GetInt64(0);

                        if (!reader.IsDBNull(1))
                           compra.IdArticulo = reader.GetInt64(1);

                        if (!reader.IsDBNull(2))
                          compra.Fecha = reader.GetDateTime(2);

                        if (!reader.IsDBNull(3)) { 
                           compra.Precio = reader.GetDecimal(3);
                        }
                       
                }
                }
            conexion.Dispose();
            return compra;
            }

         public List<Compra> ConsultaAll()
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
			command.CommandText= "ConsultaAllCompra";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Compra> ListadoCompra = new List<Compra>();
		    Compra compra;

                          if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       compra = new Compra();
                        if (!reader.IsDBNull(0))
                           compra.IdUsuario = reader.GetInt64(0);

                        if (!reader.IsDBNull(1))
                           compra.IdArticulo = reader.GetInt64(1);

                        if (!reader.IsDBNull(2)) { 
                           compra.Fecha = reader.GetDateTime(2);
                        }
                        if (!reader.IsDBNull(3)) { 
                           compra.Precio = reader.GetDecimal(3);
                        }
                        if (!reader.IsDBNull(4)) { 
                           compra.Id = reader.GetInt64(4);
                        }
                      ListadoCompra.Add(compra); 
                }
                }
            conexion.Dispose();
            return ListadoCompra;
            }
       //Consulta todas las compras hechas por el usuario
        public List<object> ConsultaAllByUser(long IdUsuario)
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

            SqlParameter ParametroIdUser = new SqlParameter();
            ParametroIdUser.Value = IdUsuario;
			ParametroIdUser.ParameterName="@IdUsuario";

            command.Parameters.Add(ParametroIdUser);

            command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "ConsultaAllCompraByUser";
            
            
            			
			SqlDataReader reader =  command.ExecuteReader();
            List<object> ListadoCompra = new List<object>();
		    Compra compra; 
            Articulo art;
                          if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        compra = new Compra();
                        art = new Articulo();
                        if (!reader.IsDBNull(0))
                           art.Titulo = reader.GetString(0);

                        if (!reader.IsDBNull(1)) { 
                           art.FotoPrincipal= reader.GetString(1);
                        }
                        if (!reader.IsDBNull(2)) { 
                           compra.Precio = reader.GetDecimal(2);
                        }
                        if (!reader.IsDBNull(3)) { 
                           compra.Fecha = reader.GetDateTime(3);
                        }

                      ListadoCompra.Add(compra); 
                      ListadoCompra.Add(art); 
                }
                }
            conexion.Dispose();
            return ListadoCompra;
            }

        public List<ArticuloCompraUsuario> ConsultaAllCompraArticuloUser()
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
			command.CommandText= "ConsultaAllCompraAndUsuarioAndArticulo";			
			SqlDataReader reader =  command.ExecuteReader();
            List<ArticuloCompraUsuario> ListadoCompra = new List<ArticuloCompraUsuario>();

           ArticuloCompraUsuario acu;

            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        acu = new ArticuloCompraUsuario();

                        if (!reader.IsDBNull(0))
                           acu.IdUsuario = reader.GetInt64(0);

                        if (!reader.IsDBNull(1))
                           acu.IdArticulo = reader.GetInt64(1);

                        if (!reader.IsDBNull(2)) { 
                           acu.Fecha = reader.GetDateTime(2);
                        }
                        if (!reader.IsDBNull(3)) { 
                           acu.Precio = reader.GetDecimal(3);
                        }
                        if (!reader.IsDBNull(4)) { 
                           acu.Id = reader.GetInt64(4);
                        }                    
                        if (!reader.IsDBNull(5)) { 
                           acu.Titulo = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6)) { 
                           acu.FotoPrincipal = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7)) { 
                           acu.Nombre = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                           acu.Apellidos = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9)) { 
                           acu.Telefono = reader.GetString(9);
                        }
                       if (!reader.IsDBNull(10)) { 
                           acu.Dni = reader.GetString(10);
                        }
                      ListadoCompra.Add(acu);
                      
                }
             }
            conexion.Dispose();
            return ListadoCompra;
            }
       
         public List<ArticuloCompraUsuario> ConsultaAllCompraArticuloUserByFecha(DateTime Fecha,DateTime FechaMax)
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
			command.CommandText= "ConsultaAllCompraAndUsuarioAndArticuloByFecha";
            
            SqlParameter ParametroFecha = new SqlParameter();
            ParametroFecha.Value = Fecha;
			ParametroFecha.ParameterName="@Fecha";

            SqlParameter ParametroFechaMax = new SqlParameter();
            ParametroFechaMax.Value = FechaMax;
			ParametroFechaMax.ParameterName="@FechaLimite";

            command.Parameters.Add(ParametroFecha);
            command.Parameters.Add(ParametroFechaMax);
            			
			SqlDataReader reader =  command.ExecuteReader();
            List<ArticuloCompraUsuario> ListadoCompra = new List<ArticuloCompraUsuario>();

           ArticuloCompraUsuario acu;

            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        acu = new ArticuloCompraUsuario();

                        if (!reader.IsDBNull(0))
                           acu.IdUsuario = reader.GetInt64(0);

                        if (!reader.IsDBNull(1))
                           acu.IdArticulo = reader.GetInt64(1);

                        if (!reader.IsDBNull(2)) { 
                           acu.Fecha = reader.GetDateTime(2);
                        }
                        if (!reader.IsDBNull(3)) { 
                           acu.Precio = reader.GetDecimal(3);
                        }
                        if (!reader.IsDBNull(4)) { 
                           acu.Id = reader.GetInt64(4);
                        }                     
                        if (!reader.IsDBNull(5)) { 
                           acu.Titulo = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6)) { 
                           acu.FotoPrincipal = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7)) { 
                           acu.Nombre = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                           acu.Apellidos = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9)) { 
                           acu.Telefono = reader.GetString(9);
                        }
                        if (!reader.IsDBNull(10)) { 
                           acu.Dni = reader.GetString(10);
                        }
                      ListadoCompra.Add(acu);                 
                }
             }
            conexion.Dispose();
            return ListadoCompra;
            }

        public List<ArticuloCompraUsuario> ConsultaAllCompraArticuloUserByNombre (String Nombre)
            {
        
            String cadenaconexion = null;
				
			Configuracion  conf = new Configuracion();
		    cadenaconexion = conf.LeerCadenaCompleta();
                
			SqlConnection conexion = null;
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "ConsultaAllCompraAndUsuarioAndArticuloByNombre";
            
            SqlParameter ParametroNombre = new SqlParameter();
            ParametroNombre.Value = Nombre;
			ParametroNombre.ParameterName="@Nombre";

            command.Parameters.Add(ParametroNombre);
                       			
			SqlDataReader reader =  command.ExecuteReader();
            List<ArticuloCompraUsuario> ListadoCompra = new List<ArticuloCompraUsuario>();

           ArticuloCompraUsuario acu;

            if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                        acu = new ArticuloCompraUsuario();

                        if (!reader.IsDBNull(0))
                           acu.IdUsuario = reader.GetInt64(0);

                        if (!reader.IsDBNull(1))
                           acu.IdArticulo = reader.GetInt64(1);

                        if (!reader.IsDBNull(2)) { 
                           acu.Fecha = reader.GetDateTime(2);
                        }
                        if (!reader.IsDBNull(3)) { 
                           acu.Precio = reader.GetDecimal(3);
                        }
                        if (!reader.IsDBNull(4)) { 
                           acu.Id = reader.GetInt64(4);
                        }    
                        if (!reader.IsDBNull(5)) { 
                           acu.Titulo = reader.GetString(5);
                        }
                        if (!reader.IsDBNull(6)) { 
                           acu.FotoPrincipal = reader.GetString(6);
                        }
                        if (!reader.IsDBNull(7)) { 
                           acu.Nombre = reader.GetString(7);
                        }
                        if (!reader.IsDBNull(8)) { 
                           acu.Apellidos = reader.GetString(8);
                        }
                        if (!reader.IsDBNull(9)) { 
                           acu.Telefono = reader.GetString(9);
                        }
                        if (!reader.IsDBNull(10)) { 
                           acu.Dni = reader.GetString(10);
                        }
                      ListadoCompra.Add(acu);         
                }
             }
            conexion.Dispose();
            return ListadoCompra;
            }
        }
    }