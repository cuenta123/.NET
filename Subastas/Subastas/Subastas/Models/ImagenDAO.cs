using DataAccessService;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Multigas_Enertica.Models
    {
    public class ImagenDAO
        {
        String cadenaconexion = null;
        SqlConnection conexion = null;

        public void Consulta(int id) { 

            Configuracion  conf = new Configuracion();
			cadenaconexion = conf.LeerCadenaCompleta();
			SqlCommand command = null;

			//Crear y abrir la conexion
			conexion = new SqlConnection(cadenaconexion);
			conexion.Open();
			command = conexion.CreateCommand();

            //Definicion de procedimiento
			command.CommandType= System.Data.CommandType.StoredProcedure;
			command.CommandText= "ConsultaImagen";

            //Parametros a utilizar

            SqlParameter ParametroId = new SqlParameter();
		//	ParametroId.Value= tablacalendario.Usuario;
			ParametroId.ParameterName="@Id";

            SqlParameter ParametroRol = new SqlParameter();
			//ParametroId.Value= tablacalendario.Usuario;
			ParametroId.ParameterName="@Rol";

			command.Parameters.Add(ParametroId);
			
		    command.ExecuteNonQuery();
            conexion.Dispose();
            }
            }

    }