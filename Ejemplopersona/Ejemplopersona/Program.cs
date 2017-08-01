using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejemplopersona
{
    class Persona
    {
        String name;
      
        public static Persona operator != (Persona pepe, Persona juan)
        {
            return new Persona() { name = pepe.name + " " + juan.name + "No son hermanos" };
        }

        public static Persona operator == (Persona pepe, Persona juan)
        {
            return new Persona() { name = pepe.name + " " + juan.name + "Son hermanos" };
        }

        public override bool Equals(Object obj)
        {

            if (obj.GetType() != typeof(Persona))
            {
                return false;
            }

            Persona p = (Persona) obj;
            if (ReferenceEquals(this.name, p.name))
            {
                return true;
            }

            return false;      
        }

        static void Main(string[] args)
        {
            var Pepe = new Persona() {name ="pepe"};
            var Juan = new Persona() {name = "pepe"};
           
            Console.WriteLine(Pepe.Equals(Juan));
            Console.ReadLine();

        }
    }
}
