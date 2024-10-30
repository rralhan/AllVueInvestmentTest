namespace AllVueInvestmentTest_DAL.DTOs
{
    public class TransactionResult
    {
        public int RemainingShares { get; set; }
        public decimal CostBasisSoldShares { get; set; }
        public decimal CostBasisRemainingShares { get; set; }
        public decimal Profit { get; set; }
    }
}
