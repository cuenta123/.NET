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
    public class VehiculoDao
        {
         String cadenaconexion = null;
         SqlConnection conexion = null;
        
        public void Alta(Vehiculo vehiculo)
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
			command.CommandText= "AltaVehiculo";

            //Parametros a utilizar
           

            SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= vehiculo.Id;
			ParametroId.ParameterName="@Id";

            SqlParameter ParametroEstado = new SqlParameter();
	     	ParametroEstado.Value= vehiculo.Estado;
			ParametroEstado.ParameterName="@Estado";

            SqlParameter ParametroMarca = new SqlParameter();
	     	ParametroMarca.Value= vehiculo.Marca;
			ParametroMarca.ParameterName="@Marca";

            SqlParameter ParametroModelo = new SqlParameter();
	     	ParametroModelo.Value= vehiculo.Modelo;
			ParametroModelo.ParameterName="@Modelo";

            SqlParameter ParametroCombustible = new SqlParameter();
	     	ParametroCombustible.Value= vehiculo.Combustible;
			ParametroCombustible.ParameterName="@Combustible";

            SqlParameter ParametroKM = new SqlParameter();
	     	ParametroKM.Value= vehiculo.Km;
			ParametroKM.ParameterName="@KM";

            SqlParameter ParametroUbicacion= new SqlParameter();
	     	ParametroUbicacion.Value= vehiculo.Ubicacion;
			ParametroUbicacion.ParameterName="@Ubicacion";

            SqlParameter ParametroFPMatriculacion= new SqlParameter();
	     	ParametroFPMatriculacion.Value= vehiculo.FPMatriculacion;
			ParametroFPMatriculacion.ParameterName="@FPMatriculacion";

            SqlParameter ParametroColorExterior= new SqlParameter();
	     	ParametroColorExterior.Value= vehiculo.ColorExterior;
			ParametroColorExterior.ParameterName="@ColorExterior";

            SqlParameter ParametroColorInterior= new SqlParameter();
	     	ParametroColorInterior.Value= vehiculo.ColorInterior;
			ParametroColorInterior.ParameterName="@ColorInterior";

            SqlParameter ParametroEquipamiento= new SqlParameter();
	     	ParametroEquipamiento.Value= vehiculo.Equipamiento;
			ParametroEquipamiento.ParameterName="@Equipamiento";

           
            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroEstado);
            command.Parameters.Add(ParametroMarca);
            command.Parameters.Add(ParametroModelo);
			command.Parameters.Add(ParametroCombustible);
            command.Parameters.Add(ParametroKM);
            command.Parameters.Add(ParametroUbicacion);
            command.Parameters.Add(ParametroFPMatriculacion);
            command.Parameters.Add(ParametroColorExterior);
            command.Parameters.Add(ParametroColorInterior);
             command.Parameters.Add(ParametroEquipamiento);

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
			command.CommandText= "Baja";

            //Parametros a utilizar
			SqlParameter ParametroId = new SqlParameter();
			ParametroId.Value= Id;
			ParametroId.ParameterName="@Id";
            command.Parameters.Add(ParametroId);
		    command.ExecuteNonQuery();
            conexion.Dispose();

            }

        public void Modificacion(Vehiculo vehiculo)
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
			command.CommandText= "ModificarUsuario";

            //Parametros a utilizar
             SqlParameter ParametroId = new SqlParameter();
	     	ParametroId.Value= vehiculo.Id;
			ParametroId.ParameterName="@Id";

            SqlParameter ParametroEstado = new SqlParameter();
	     	ParametroEstado.Value= vehiculo.Estado;
			ParametroEstado.ParameterName="@Estado";

            SqlParameter ParametroModelo = new SqlParameter();
	     	ParametroModelo.Value= vehiculo.Modelo;
			ParametroModelo.ParameterName="@Modelo";

            SqlParameter ParametroCombustible = new SqlParameter();
	     	ParametroCombustible.Value= vehiculo.Combustible;
			ParametroCombustible.ParameterName="@Combustible";

            SqlParameter ParametroKM = new SqlParameter();
	     	ParametroKM.Value= vehiculo.Km;
			ParametroKM.ParameterName="@KM";

            SqlParameter ParametroUbicacion= new SqlParameter();
	     	ParametroUbicacion.Value= vehiculo.Ubicacion;
			ParametroUbicacion.ParameterName="@Ubicacion";

            SqlParameter ParametroFPMatriculacion= new SqlParameter();
	     	ParametroFPMatriculacion.Value= vehiculo.FPMatriculacion;
			ParametroFPMatriculacion.ParameterName="@FPMatriculacion";

            SqlParameter ParametroColorExterior= new SqlParameter();
	     	ParametroColorExterior.Value= vehiculo.ColorExterior;
			ParametroColorExterior.ParameterName="@ColorExterior";

            SqlParameter ParametroColorInterior= new SqlParameter();
	     	ParametroColorInterior.Value= vehiculo.ColorInterior;
			ParametroColorInterior.ParameterName="@ColorInterior";

            SqlParameter ParametroEquipamiento= new SqlParameter();
	     	ParametroEquipamiento.Value= vehiculo.Equipamiento;
			ParametroEquipamiento.ParameterName="@Equipamiento";

           
            command.Parameters.Add(ParametroId);
            command.Parameters.Add(ParametroEstado);
            command.Parameters.Add(ParametroModelo);
			command.Parameters.Add(ParametroCombustible);
            command.Parameters.Add(ParametroKM);
            command.Parameters.Add(ParametroUbicacion);
            command.Parameters.Add(ParametroFPMatriculacion);
            command.Parameters.Add(ParametroColorExterior);
            command.Parameters.Add(ParametroColorInterior);
             command.Parameters.Add(ParametroEquipamiento);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }


           public Vehiculo Consulta (int id)
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
			ParametroId.ParameterName="@Id";

			command.Parameters.Add(ParametroId);
			
			
			SqlDataReader reader =  command.ExecuteReader();

			      Vehiculo vehiculo = new Vehiculo();

                         if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           vehiculo.Estado = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                          vehiculo.Marca = reader.GetString(1);
                        if (!reader.IsDBNull(3))
                           vehiculo.Modelo = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                            vehiculo.Combustible = reader.GetString(4);
                        if (!reader.IsDBNull(5)) { 
                           vehiculo.Km = reader.GetInt32(5);
                        }
                        if (!reader.IsDBNull(6)) { 
                            vehiculo.Ubicacion = reader.GetString(6);
                        }     
                        if (!reader.IsDBNull(7)) { 
                            vehiculo.FPMatriculacion = reader.GetDateTime(7);
                        }   
                        if (!reader.IsDBNull(8)) { 
                            vehiculo.ColorExterior = reader.GetString(8);
                        }     
                         if (!reader.IsDBNull(9)) { 
                            vehiculo.ColorInterior = reader.GetString(9);
                        }  
                         if (!reader.IsDBNull(10)) { 
                            vehiculo.Equipamiento = reader.GetString(9);
                        }            
                }
                }
            conexion.Dispose();
            return vehiculo;
            }

         public List<Vehiculo> ConsultaAll()
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
			command.CommandText= "ConsultaAllVehiculo";			
			SqlDataReader reader =  command.ExecuteReader();
            List<Vehiculo> ListadoVehiculo = new List<Vehiculo>();
			Vehiculo vehiculo = new Vehiculo();

                          if (reader.HasRows)
                        {
                         while(reader.Read())
                        {
                       
                        if (!reader.IsDBNull(0))
                           vehiculo.Estado = reader.GetString(0);
                        if (!reader.IsDBNull(1))
                           vehiculo.Marca = reader.GetString(1);
                        if (!reader.IsDBNull(3))
                           vehiculo.Modelo = reader.GetString(3);
                        if (!reader.IsDBNull(4))
                           vehiculo.Combustible = reader.GetString(4);
                        if (!reader.IsDBNull(5)) { 
                           vehiculo.Km = reader.GetInt32(5);
                        }
                        if (!reader.IsDBNull(6)) { 
                           vehiculo.Ubicacion = reader.GetString(6);
                        }     
                        if (!reader.IsDBNull(7)) { 
                           vehiculo.FPMatriculacion = reader.GetDateTime(7);
                        }   
                        if (!reader.IsDBNull(8)) { 
                            vehiculo.ColorExterior = reader.GetString(8);
                        }     
                         if (!reader.IsDBNull(9)) { 
                            vehiculo.ColorInterior = reader.GetString(9);
                        }  
                         if (!reader.IsDBNull(10)) { 
                            vehiculo.Equipamiento = reader.GetString(9);
                        }            
                         ListadoVehiculo.Add(vehiculo);
                }
                }
            conexion.Dispose();
            return ListadoVehiculo;
            }
       
        }
    }