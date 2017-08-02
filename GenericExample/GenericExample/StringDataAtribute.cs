using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericExample
{
    public class StringDataBaseAttribute : Attribute,IValid
    {
        public int Length { get; set; }
        public bool Required { get; set; }

        public StringDataBaseAttribute()
        {
            this.Required = true;
        } 

        public bool IsValid(String value)
        {
            return true;
        }

    }
}
