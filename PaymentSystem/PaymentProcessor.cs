using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentSystem
{
    /// <summary>
    /// Konkretna implementacja interfejsu IPaymentProcessor
    /// </summary>
    public class PaymentProcessor : IPaymentProcessor
    {
        /// <summary>
        /// Implementacja metody przetwarzania płatności
        /// </summary>
        /// <param name="amount">Kwota od przetworzenia</param>
        /// <param name="currency">Waluta</param>
        /// <returns>Status powodzenia płatności</returns>
        public bool ProcessPayment(decimal amount, string currency)
        {
            Console.WriteLine($"Przetwarzanie płatności: {amount}, {currency}");

            //Prosta walidacja kwoty
            if (amount <= 0)
            {
                Console.WriteLine("Kwota płatności musi być dodatnia");
                return false;
            }
            Console.WriteLine($"Płatność na kwotę {amount} {currency} zakończenia sukcesem");
            return true;
        }
    }
}
