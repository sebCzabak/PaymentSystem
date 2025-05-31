using System;

namespace PaymentSystem
{
    /// <summary>
    /// Serwis odpowiedzialny za logikę przetwarzania zmaówień
    /// </summary>
    public class OrderService
    {
        private readonly IPaymentProcessor _paymentProcessor;

        
        /// <summary>
        /// Konstruktor klasy OrderService
        /// </summary>
        /// <param name="paymentProcessor">Instancja procesora płatności</param>
        /// <exception cref="ArgumentNullException">wyrzucany, gdy paymentProcessor jest null'em</exception>
        public OrderService(IPaymentProcessor paymentProcessor)
        {
            _paymentProcessor = paymentProcessor ?? throw new ArgumentNullException(nameof(paymentProcessor));
        }

        
        public bool PlaceOrder(decimal amount, string currency)
        {
            Console.WriteLine($"Składanie zamówienia na kwotę: {amount} {currency}");

            
            bool paymentSuccessful = _paymentProcessor.ProcessPayment(amount, currency);

            if (paymentSuccessful)
            {
                Console.WriteLine("Zamówienie zostało pomyślnie złożone i opłacone.");

                return true;
            }
            else
            {
                Console.WriteLine("Nie udało się przetworzyć płatności. Zamówienie nie zostało złożone.");

                return false;
            }
        }
    }
}