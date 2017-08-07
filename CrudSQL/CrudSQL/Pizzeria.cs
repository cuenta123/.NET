using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;
using System.Collections;

namespace CrudSQL
{
    class Pizzeria { 
        [Required]
        public Guid Id { get; set; }
        [Required]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "La cadena debe estar entre 3 y 50 caracteres")]
        public String Descripcion { get; set; }

      


        public Pizzeria()
        {
            Id = Guid.NewGuid();
        }

    public IEnumerable<Pizzeria> GetList()
    {
        return new List<Pizzeria>();
    }
}
}
