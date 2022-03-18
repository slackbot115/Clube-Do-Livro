using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClubeDoLivro.ConsoleApp
{
    internal class Reserva
    {
        public int validade = 2;
        public DateTime expiraEm = DateTime.MinValue;
        public Locador locador;
        public Revista revista;
    }
}
