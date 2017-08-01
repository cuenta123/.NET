using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CajaRegistradora
{
    public class TotalEventArgs : EventArgs
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
}
