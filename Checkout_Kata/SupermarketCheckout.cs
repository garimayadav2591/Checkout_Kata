using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckoutKata
{
    public class SupermarketCheckout
    {
        private readonly Dictionary<char, (int unitPrice, (int quantity, int specialPrice) specialPrice)> _itemPrices;

        private readonly Dictionary<char, int> _scannedItems = new Dictionary<char, int>();

        public SupermarketCheckout(Dictionary<char, (int unitPrice, (int quantity, int specialPrice) specialPrice)> itemPrices)
        {
            _itemPrices = itemPrices;
        }

        public void Scan(char item)
        {
            if (!_itemPrices.ContainsKey(item))
                throw new ArgumentException($"Invalid item: {item}");

            if (!_scannedItems.ContainsKey(item))
                _scannedItems[item] = 0;

            _scannedItems[item]++;
        }

        public int CalculateTotal()
        {
            int total = 0;

            foreach (var scannedItem in _scannedItems)
            {
                char item = scannedItem.Key;
                int quantity = scannedItem.Value;
                int unitPrice = _itemPrices[item].unitPrice;
                int specialQuantity = _itemPrices[item].specialPrice.quantity;
                int specialPrice = _itemPrices[item].specialPrice.specialPrice;

                if (specialQuantity > 0 && quantity >= specialQuantity)
                {
                    int specialGroups = quantity / specialQuantity;
                    int remainingItems = quantity % specialQuantity;

                    total += specialGroups * specialPrice + remainingItems * unitPrice;
                }
                else
                {
                    total += quantity * unitPrice;
                }
            }

            return total;
        }
    }
}