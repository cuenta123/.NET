using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaRegistradora
{

    class Program
    {
        static void Main(string[] args)
        {
            var caja = new Caja();
            caja.Total += caja.Caja_Total;

            //Prueba del funcionamiento
            caja.AniadirTicket(caja);
            caja.AniadirTicket(caja);
            caja.AniadirTicket(caja);
            caja.AniadirTicket(caja);

            if (caja.Total >= 200)
            {
                //Llamar al evento OnTotal
                caja.OnTotal(new TotalEventArgs(1, caja.Caja_Total));
                //Llamar al método restar, para utilizar la misma referencia al objeto
                //para restar se pasa por el metodo RecogerCambio
                caja.RecogerCambio(caja);
            }

            Console.ReadLine();
          
        }

    }
}

