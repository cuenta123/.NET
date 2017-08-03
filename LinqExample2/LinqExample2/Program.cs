using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqExample2
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> listA = new List<int>()
            {
                1,2,3
            };

            List<int> listB = new List<int>()
            {
                2,3
            };

            //Method Sintax
            var listCMethod = listA.Except(listB).ToList();
            //Query Sintax
            var listCSintax = (from num in listA.Except(listB) select num).ToList(); 


        }
    }
}
