using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrudSQL
{
    class SqlConexion
    {
        SqlConnection conexion = null;

       public SqlConexion(String DataSource)
        {
            conexion = new SqlConnection();
        }

        public void Open()
        {
            conexion.Open();
        }

        public void Close()
        {
            conexion.Close();
        }

        public SqlCommand CreateCommand()
        {
          return  conexion.CreateCommand();
        }
    }
}
