using NUnit.Framework;
using Moq;

namespace PaymentSystem.Tests
{
    /// <summary>
    /// Klasa testowa dla OrderSerivce
    /// TestFixture oznacza, że zawiera testy NUnit
    /// </summary>
    [TestFixture]
    public class OrderServiceTests
    {
        private  Mock<IPaymentProcessor> _mockPaymentProcessor;
        private OrderService _orderService;

        /// <summary>
        /// Meotda SetUp jest automagicznie wywoływana przez NUnit przed każdym testem w tej klasie.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            _mockPaymentProcessor = new Mock<IPaymentProcessor>();

            _orderService = new OrderService(_mockPaymentProcessor.Object);
        }
        /// <summary>
        /// Test sprawdzajacy czyu metoda ProcessPayment jest wywoływana dokładnie raz
        /// </summary>
        [Test]
        public void PlaceOrder_WhenPaymentSucceeds_CallsProcessPaymentExacltyOnce()
        {
            decimal testAmount = 100.50m;
            string testCurrency = "PLN";

            _mockPaymentProcessor.Setup(p => p.ProcessPayment(It.IsAny<decimal>(), It.IsAny<string>()))
                .Returns(true);

            _orderService.PlaceOrder(testAmount, testCurrency);

            _mockPaymentProcessor.Verify(p => p.ProcessPayment(It.IsAny<decimal>(), It.IsAny<string>()), Times.Once);
        }
        /// <summary>
        /// Test sprawdzający, czy metoda ProcessPayment jest wywoływana z prawidłowymi parametrami,
        /// </summary>
        [Test]
        public void PlaceOrder_WhenPaymentSucceeds_CallsProcessPaymentWithCorrectParameters()
        {
            decimal expectedAmount = 299.99m;
            string expectedCurrency = "USD";

            _mockPaymentProcessor.Setup(p=>p.ProcessPayment(expectedAmount,expectedCurrency))
                .Returns(true);

            _orderService.PlaceOrder(expectedAmount, expectedCurrency);

            _mockPaymentProcessor.Verify(p => p.ProcessPayment(expectedAmount,expectedCurrency), Times.Once);
        }
        /// <summary>
        /// Test sprawdzający, czy metoda PlaceOrder zwraca 'true', gdy płatność (symulowana przez mocka) jest udana.
        /// </summary>
        [Test]
        public void PlaceOrder_ReturnsTrue_WhenPaymentIsSuccessful()
        {
            decimal amount = 50.00m;
            string currency = "EUR";
            _mockPaymentProcessor.Setup(p => p.ProcessPayment(amount, currency)).Returns(true);

            bool result = _orderService.PlaceOrder(amount, currency);

            Assert.That(result,Is.True);
        }
        /// <summary>
        /// Test sprawdzający, czy metoda PlaceOrder zwraca 'false', gdy płatność (symulowana przez mocka) jest nieudana.
        /// </summary>
        [Test]
        public void PlaceOrder_ReturnsFalse_WhenPaymentFails()
        {
            decimal amount = 75.00m;
            string currency = "GBP";
            _mockPaymentProcessor.Setup(p => p.ProcessPayment(amount, currency)).Returns(false);


            bool result = _orderService.PlaceOrder(amount, currency);

            Assert.That(result,Is.False);

        }
    }
}