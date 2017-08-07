using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GenericExample;
using System.Data.SqlClient;

namespace CrudSQL
{
    class PizzeriaDao : ICreate, IGetSQL, IUpdate, IDelete
    {

        public bool CreateSQL(Generic entity)
        {
            SqlConexion conexion = null;
            SqlCommand command = null;

            if (entity == null)
            {
                throw new Exception("El objeto es nulo");
            }
           
            if ((Type) entity.GetType() != typeof(Pizzeria)) {

                throw new Exception("El objeto enviado es distinto al esperado");
            }

            try
            {
                 conexion = new SqlConexion(DataSourceListConexion.PizzeriaDataSource());
                 command = conexion.CreateCommand();


                //Definicion de procedimiento
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Insert Into Pizzeria (Id, Descripcion) Values(@Id, @Descripcion)";

                //Parametros a utilizar
                command.Parameters.Add(new SqlParameter("@Id", entity.type.GetProperties().GetValue(0)));
                command.Parameters.Add(new SqlParameter("@Descripcion", entity.type.GetProperties().GetValue(1)));


                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException)
            {              
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            catch (Exception)
            {        
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            finally
            {
                command.Dispose();
                conexion.Close();
            }

            return true;
        }

        public bool DeleteSQL(Guid idEntity)
        {
            SqlConexion conexion = null;
            SqlCommand command = null;

            if (idEntity == null)
            {
                throw new Exception("El objeto es nulo");
            }

            if ((Type)idEntity.GetType() != typeof(Pizzeria))
            {
                throw new Exception("El objeto enviado es distinto al esperado");
            }

            try
            {
                conexion = new SqlConexion(DataSourceListConexion.PizzeriaDataSource());
                command = conexion.CreateCommand();


                //Definicion de procedimiento
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Delete From Pizzeria  Where @Id = Id";

                //Parametros a utilizar
                command.Parameters.Add(new SqlParameter("@Id", idEntity));

                command.ExecuteNonQuery();
                conexion.Close();
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            finally
            {
                command.Dispose();
                conexion.Close();
            }

            return true;
        }

        public Generic GetSQL(Guid idEntity)
        {
            SqlConexion conexion = null;
            SqlCommand command = null;
            Pizzeria p = null;


            if (idEntity == null)
            {
                throw new Exception("El objeto es nulo");
            }

            if ((Type)idEntity.GetType() != typeof(Pizzeria))
            {
                throw new Exception("El objeto enviado es distinto al esperado");
            }

            try
            {
                conexion = new SqlConexion(DataSourceListConexion.PizzeriaDataSource());
                command = conexion.CreateCommand();


                //Definicion de procedimiento
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Select Descripcion From Pizzeria  Where @Id = Id";

                //Parametros a utilizar
                command.Parameters.Add(new SqlParameter("@Id", idEntity));

                SqlDataReader reader = command.ExecuteReader();

                p =  new Pizzeria();
                p.Id = Guid.Empty;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            p.Descripcion = reader.GetString(0);
                        }
                    }

                    conexion.Close();
                }
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            finally
            {
                command.Dispose();
                conexion.Close();
            }

           List<Generic> list = Generic.ToGeneric(p.GetList());
            return list.ElementAt(0);
         

        }

        public bool UpdateSQL(Generic entity)
        {

            SqlConexion conexion = null;
            SqlCommand command = null;
            Pizzeria p = null;


            if (entity == null)
            {
                throw new Exception("El objeto es nulo");
            }

            if ((Type)entity.GetType() != typeof(Pizzeria))
            {
                throw new Exception("El objeto enviado es distinto al esperado");
            }

            try
            {
                conexion = new SqlConexion(DataSourceListConexion.PizzeriaDataSource());
                command = conexion.CreateCommand();


                //Definicion de procedimiento
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = "Update From Pizzeria (Descripcion = @Descripcion) Where @Id = Id";

                //Parametros a utilizar
                command.Parameters.Add(new SqlParameter("@Descripcion", entity.type.GetProperties().GetValue(0)));

                SqlDataReader reader = command.ExecuteReader();

                p = new Pizzeria();
                p.Id = Guid.Empty;

                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (!reader.IsDBNull(0))
                        {
                            p.Descripcion = reader.GetString(0);
                        }
                    }

                    conexion.Close();
                }
            }
            catch (SqlException)
            {
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            catch (Exception)
            {
                throw new Exception("Error al intentar insertar el Objeto Pizzeria en la BD");
            }
            finally
            {
                command.Dispose();
                conexion.Close();
            }

            return true;
        }
    }
}
