using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class SQLInsert : SQL
    {
        StringBuilder sql;

        public void StringConstructor(List<Generic> listGeneric)
        {
            if (listGeneric == null)
            {
                throw new ArgumentNullException("Lista de generica nula");
            }
            var table = listGeneric.ElementAt(0).type.Name;
           

            sql = new StringBuilder();
            sql.Append("Insert Into ");
            sql.Append(table);
            sql.Append(" (");

            StringBuilderProperty(listGeneric);
            StringBuilderValues(listGeneric);
        }

        private void StringBuilderProperty( List<Generic> listGeneric)
        {

                int contador=0;
                foreach(var property in listGeneric)
                {
                        PropertyInfo[] properties = listGeneric.ElementAt(contador).type.GetProperties();
                        sql.Append(properties + ",");
                        if (contador == listGeneric.Count()-1)
                        {
                            sql.Append(properties + ")");
                        }
                contador++;
                }
        }

        private void StringBuilderValues(List<Generic> listGeneric)
        {

            int contador = 0;
            sql.Append(" Values (");

            foreach (var property in listGeneric)
            {
                PropertyInfo[] propertyinfo = listGeneric.ElementAt(contador).type.GetProperties();
                sql.Append(propertyinfo + ",");
                if (contador == listGeneric.Count() - 1)
                {
                    sql.Append(propertyinfo + ")");
                }
            }
        }

      
    }
}
