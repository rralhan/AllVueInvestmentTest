using AllVueInvestmentTest_DAL.DTOs;
using AllVueInvestmentTest_DAL.Interfaces;


namespace AllVueInvestmentTest_BL
{
    public class InvestmentCalculator
    {
        private readonly IPurchaseLotRepository _purchaseLotRepository;
        public InvestmentCalculator(IPurchaseLotRepository purchaseLotRepository)
        {
            _purchaseLotRepository = purchaseLotRepository;
        }

        public Models.TransactionResult Calculate(int sharesSold, decimal salePricePerShare, string strategy = "FIFO")
        {
            var purchaseLots = _purchaseLotRepository.GetPurchaseLots();
        
            switch (strategy.ToUpper())
            {
                case "FIFO":
                    return CalculateFifo(purchaseLots, sharesSold, salePricePerShare);
                case "LIFO":
                    return CalculateLifo(purchaseLots, sharesSold, salePricePerShare);
                // Add other strategies as needed.
                default:
                    throw new ArgumentException("Unsupported strategy");
            }
        }

        private Models.TransactionResult CalculateFifo(List<PurchaseLot> purchaseLots, int sharesSold, decimal salePricePerShare)
        {
            purchaseLots = purchaseLots
                .OrderBy(lot => lot.PurchaseDate)
                .ToList();
            return CalculateTransactionResult(purchaseLots, sharesSold, salePricePerShare);

        }
        private Models.TransactionResult CalculateLifo(List<PurchaseLot> purchaseLots, int sharesSold, decimal salePricePerShare)
        {
            // LIFO calculation: start from the most recent lot
            purchaseLots = purchaseLots.OrderByDescending(lot => lot.PurchaseDate).ToList();
            return CalculateTransactionResult(purchaseLots, sharesSold, salePricePerShare);
        }

        private Models.TransactionResult CalculateTransactionResult(List<PurchaseLot> purchaseLots, int sharesSold, decimal salePricePerShare)
        {
            int remainingShares = sharesSold;
            decimal costBasisSoldShares = 0;
            int totalSoldShares = 0;
            decimal profit = 0;

            foreach (var lot in purchaseLots)
            {
                if (remainingShares <= 0) break;

                int sharesToSell = Math.Min(remainingShares, lot.Shares);
                costBasisSoldShares += sharesToSell * lot.CostPerShare;
                profit += sharesToSell * (salePricePerShare - lot.CostPerShare);

                remainingShares -= sharesToSell;
                totalSoldShares += sharesToSell;
                lot.Shares -= sharesToSell;
            }

            decimal avgCostRemainingShares = purchaseLots
                .Where(lot => lot.Shares > 0)
                .Select(lot => lot.CostPerShare)
                .DefaultIfEmpty(0)
                .Average();

           var dtoTransactionResult = new TransactionResult
            {
                RemainingShares = purchaseLots.Sum(lot => lot.Shares),
                CostBasisSoldShares = costBasisSoldShares / totalSoldShares,
                CostBasisRemainingShares = avgCostRemainingShares,
                Profit = profit
            };
            return Models.TransactionResult.FromDto(dtoTransactionResult);
        }
    }

}