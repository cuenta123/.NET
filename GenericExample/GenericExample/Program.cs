using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class Program
    {
        static void Main(string[] args)
        {

            var person = new List<Person>()
            {
                new Person(){Id=1, Name="Pedro",Surname="Hurtado"},
                new Person(){Id=2, Surname="Lopez"},
            };

            //Validate persons
            List<Generic> listGeneric = Generic.ToGeneric(person);

            //insert into table(...) values (111,2)
            foreach (Generic generic in listGeneric)
            {
                var table = generic.type.Name;
                StringBuilder sql = new StringBuilder();
                sql.Append("Insert Into ");
                sql.Append(generic.type.Name);
                sql.Append(" (");
                var properties = generic.type.GetProperties().ToList();
                PropertyInfo property;            
                    //Escribe las propiedades   
                    for(int i = 0; i < properties.Count; i++)
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
            }
        }
    }

}
