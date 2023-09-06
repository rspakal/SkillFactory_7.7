using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    internal abstract class Money
    {
        internal int amount; 
        public Money(int amount) { }
    }
    internal class Rubble : Money
    {
        public Rubble (int amount) : base (amount) { }
    }
    internal class Euro : Money
    {
        public Euro(int amount) : base(amount) { }
    }
}
