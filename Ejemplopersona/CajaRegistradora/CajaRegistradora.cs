using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaRegistradora
{

    public class TotalEventArgs : EventArgs //CLASE DE DATOS
    {
        int Id;
        decimal Total;

        public TotalEventArgs(int id, decimal total)
        {
            Id = id;
            Total = total;
        }

        public static implicit operator TotalEventArgs(TotalEventHandler v)
        {
            throw new NotImplementedException();
        }
    }

    public delegate void TotalEventHandler(object o, TotalEventArgs e);


    class Caja
    {
        public Decimal Total = 0;
        public Decimal Caja_Total = 0;
        public event TotalEventHandler _total;
        public int Id { get; set; }
      
        public virtual void OnTotal(TotalEventArgs e)
        {
            //PARA EVITAR QUE SI PASA EL SIGUIENTE IF Y EN EL MICROSEGUNDO SIGUIENTE SE ELIMINAN LOS SUSCRIPTORES, PETARÍA
            _total?.Invoke(this, e);
            Console.WriteLine("Evento llamado");
        }

        public void RecogerCambio(Caja c)
        {
         
            if (c.Total >= 200)
            {
                c.Total -= 200;
            }

        }
        public void AniadirTicket(Caja c)
        { 
            c.Total += 60;
        }

        public class Ticket
        {
            public int? Id { get; set; }
            public decimal? Total { get; set; }

            public Ticket (int? id, decimal? total)
                {
                    Id = id;
                    Total = total;
                }
        }
    }


    //SUSCRIPTOR, guardia de seguridad

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

            //EVENTO += TABULADOR TE AUTOCOMPLETA TODO EL EVENTO DESDE EL DELEGADO Y -0= DESUSCRIBE
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

