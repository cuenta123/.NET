using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class Generic
    {
        public Object Obj {get; set;}
        public Type type{get; set;}
        
        /// <summary>
        /// Convierte una lista de objetos a Object y devuelve
        /// </summary>
        /// <param name="list"></param>
        /// <returns></returns>
        public static List<Generic> ToGeneric(IEnumerable<Object> list)
        {
            return list.Select (c=> new Generic {Obj=c, type = c.GetType()}).ToList();
        }

        public static StringBuilder StringBuilderProperty(List<PropertyInfo> properties)
        {
           var sql = new StringBuilder();
            if ( properties != null)
            {
                PropertyInfo property;
                for (int i = 0; i < properties.Count; i++)
                {
                    property = properties.ElementAt(i);
                    if (property.ReflectedType.FullName.Equals("GenericExample.Person"))
                    {
                        sql.Append(property.Name + ",");
                        if (i == properties.Count - 1)
                        {
                            sql.Append(property + ")");
                        }
                    }
                }
                return sql;
            } 
             throw new Exception("La cadena o propiedad recibida es nula");
        }

        public static StringBuilder StringBuilderValues(List<PropertyInfo> properties, Generic generic)
        {
            var sql = new StringBuilder();
            if (properties!= null && generic!=null)
            {
                PropertyInfo property;
                sql.Append(" Values (");
                for (int i = 0; i < properties.Count; i++)
                {
                    property = properties.ElementAt(i);
                    sql.Append(property.GetValue(generic.Obj) + ",");
                    if (i == properties.Count - 1)
                    {
                        sql.Append(property + ")");
                    }
                }
                return sql;
            }

            throw new Exception("La cadena o propiedad recibida es nula");
        }
    }
}
    
