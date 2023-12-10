using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace advanded_csharp_database
{
    public interface ITransfrom<out T>
    {
        T Transfrom();
    }
}
