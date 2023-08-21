using CheckoutKata;

class Program
{
    static void Main(string[] args)
    {

        var itemPrices = new Dictionary<char, (int unitPrice, (int quantity, int specialPrice) specialPrice)>
        {
            { 'A', (50, (3, 130)) },
            { 'B', (30, (2, 45)) },
            { 'C', (20, (1, 20)) },
            { 'D', (15, (1, 15)) }
        };

        var checkout = new SupermarketCheckout(itemPrices);

        // Scan items
        checkout.Scan('A');
        checkout.Scan('A');
        checkout.Scan('B');
        checkout.Scan('C');
        checkout.Scan('A');
        checkout.Scan('B');
        checkout.Scan('D');

        // Calculate and display total
        int total = checkout.CalculateTotal();
        Console.WriteLine($"Total price: {total} pence");
    }
}