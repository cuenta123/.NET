using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    class Person: StringDataBaseAttribute
    {

        public int Id { get; set; }
        [StringDataBase(Length = 50)]
        public string Name { get; set; }
        [StringDataBase(Length = 15, Required = false)]
        public string Surname { get; set; }
        public void Save()
        {
            
        }
    }
}
