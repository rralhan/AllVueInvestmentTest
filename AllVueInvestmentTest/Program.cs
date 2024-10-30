using AllVueInvestmentTest_BL.Interfaces;
using AllVueInvestmentTest_BL.Models;
using AllVueInvestmentTest_BL.Services;
using AllVueInvestmentTest_DAL.Repositories;

class Program
{
    static void Main()
    {
        var purchaseLotRepository = new PurchaseLotRepository();
        IPurchaseLotService purchaseLotService = new AllVueInvestmentTest_BL.Services.PurchaseLotService(purchaseLotRepository);

        Console.WriteLine("Enter 'A' to add a new purchase lot or 'C' to calculate a sale:");
        var option = Console.ReadLine().ToUpper();

        if (option == "A")
        {
            AddNewPurchaseLot(purchaseLotService);
        }
        else if (option == "C")
        {
            CalculateSale(purchaseLotService);
        }
    }

    private static void AddNewPurchaseLot(IPurchaseLotService service)
    {
        Console.WriteLine("Enter shares purchased:");
        int shares = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter cost per share:");
        decimal costPerShare = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter purchase date (YYYY-MM-DD):");
        DateTime purchaseDate = DateTime.Parse(Console.ReadLine());

        var newLot = new PurchaseLot(shares, costPerShare, purchaseDate);
        service.AddPurchaseLot(newLot);

        Console.WriteLine("Purchase lot added successfully.");
    }

    private static void CalculateSale(IPurchaseLotService service)
    {
        Console.WriteLine("Enter the number of shares sold:");
        int sharesSold = int.Parse(Console.ReadLine());

        Console.WriteLine("Enter the sale price per share:");
        decimal salePricePerShare = decimal.Parse(Console.ReadLine());

        Console.WriteLine("Enter strategy (FIFO/LIFO):");
        string strategy = Console.ReadLine().ToUpper();

        TransactionResult result = service.CalculateSale(sharesSold, salePricePerShare, strategy);

        Console.WriteLine($"\nResults for selling {sharesSold} shares at ${salePricePerShare} per share with {strategy} strategy:");
        Console.WriteLine($"Remaining Shares: {result.RemainingShares}");
        Console.WriteLine($"Cost Basis of Sold Shares (Per Share): ${result.CostBasisSoldShares:F2}");
        Console.WriteLine($"Cost Basis of Remaining Shares (Per Share): ${result.CostBasisRemainingShares:F2}");
        Console.WriteLine($"Profit from Sale: ${result.Profit:F2}");
    }
}
