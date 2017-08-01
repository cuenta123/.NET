using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaRegistradora
{

    class Caja
    {
        public Decimal Total = 0;
        public Decimal Caja_Total = 0;
        public event TotalEventHandler _total;
        public int Id { get; set; }

        public virtual void OnTotal(TotalEventArgs e)
        {

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

            public Ticket(int? id, decimal? total)
            {
                Id = id;
                Total = total;
            }
        }
    }
}
