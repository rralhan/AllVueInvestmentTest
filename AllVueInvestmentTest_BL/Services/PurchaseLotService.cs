using AllVueInvestmentTest_BL.Interfaces;
using AllVueInvestmentTest_BL.Models;
using AllVueInvestmentTest_DAL.Interfaces;
using AllVueInvestmentTest_DAL.Repositories;

namespace AllVueInvestmentTest_BL.Services
{
    public class PurchaseLotService : IPurchaseLotService
    {
        private readonly IPurchaseLotRepository _purchaseLotRepository;
        private readonly InvestmentCalculator _calculator;

        public PurchaseLotService(IPurchaseLotRepository purchaseLotRepository)
        {
            _purchaseLotRepository = purchaseLotRepository;
            _calculator = new InvestmentCalculator(_purchaseLotRepository);
        }

        public void AddPurchaseLot(PurchaseLot purchaseLot)
        {
            _purchaseLotRepository.InsertPurchaseLot(purchaseLot.ToDto());
        }

        public TransactionResult CalculateSale(int sharesSold, decimal salePricePerShare, string strategy)
        {
            return _calculator.Calculate(sharesSold, salePricePerShare, strategy);          
        }
    }
}
