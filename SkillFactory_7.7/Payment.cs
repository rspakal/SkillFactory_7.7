using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SF7._7
{
    internal class Payment <TMoney>
    {
        internal TMoney paymentAmount;

    }
    internal class PaymentRubble <TMoney> : Payment <TMoney>
    {
        public PaymentRubble()
        {
            Console.WriteLine("Im paying by rubbles");
        }

    }
    internal class PaymentEuro : Payment<Euro>
    {
        internal int currencyExchangeRate;
        public PaymentEuro()
        {
            Console.WriteLine("Im paying by euro");
        }
    }

}
