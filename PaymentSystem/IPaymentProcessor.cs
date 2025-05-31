// Plik: IPaymentProcessor.cs
namespace PaymentSystem
{
    /// <summary>
    /// Definiuje kontrakt dla procesorów płatności
    /// </summary>
    public interface IPaymentProcessor
    {
        /// <summary>
        /// Przetwarzanie płatności dla podanej kwoty
        /// </summary>
        /// <param name="amount">Kwota do zapłaty</param>
        /// <param name="currency">Waluta</param>
        /// <returns>True, jeśli płatność zakończyła się sukcesem</returns>
        bool ProcessPayment(decimal amount, string currency);
    }
}