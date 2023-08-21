using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using System.Collections.Generic;


namespace CheckoutKata
{
    public class SupermarketCheckoutTests
    {
        private Dictionary<char, (int unitPrice, (int quantity, int specialPrice) specialPrice)> _itemPrices;

        [SetUp]
        public void Setup()
        {
            _itemPrices = new Dictionary<char, (int unitPrice, (int quantity, int specialPrice) specialPrice)>
        {
            { 'A', (50, (3, 130)) },
            { 'B', (30, (2, 45)) },
            { 'C', (20, (1, 20)) },
            { 'D', (15, (1, 15)) }
        };
        }

        [Test]
        public void Scan_ValidItem_CalculatesTotalPrice()
        {
            var checkout = new SupermarketCheckout(_itemPrices);
            checkout.Scan('A');

            // Act
            int total = checkout.CalculateTotal();

            // Assert
            Assert.AreEqual(50, total);
        }

        [Test]
        public void CalculateTotal_SpecialPriceApplies_CalculatesCorrectTotal()
        {
            var checkout = new SupermarketCheckout(_itemPrices);
            checkout.Scan('A');
            checkout.Scan('A');
            checkout.Scan('A'); // Total: 130

            checkout.Scan('B');
            checkout.Scan('B'); // Total: 175 (2 for 45)

            checkout.Scan('C');
            checkout.Scan('D'); // Total: 210

            int total = checkout.CalculateTotal();

            Assert.AreEqual(210, total);
        }


    }
}
