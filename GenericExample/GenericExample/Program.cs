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
                new Person(){Id=1, Name="Pedro", Surname="Hurtado"},
                new Person(){Id=2, Surname="Lopez"},
            };

            //Validate persons
            List<Generic> listGeneric = Generic.ToGeneric(person);
            //insert into table(...) values (111,2)
          //  StringBuilder sql = new StringBuilder();
            
            //var table = listGeneric.ElementAt(0).type.Name;
            //var properties = listGeneric.ElementAt(0).type.GetProperties().ToList();

        

            foreach (Generic generic in listGeneric)
            {
                PropertyInfo property;
                //Escribe las propiedades               
                sql.Append(Generic.StringBuilderValues(properties,generic));
            }
        }
    }
}
