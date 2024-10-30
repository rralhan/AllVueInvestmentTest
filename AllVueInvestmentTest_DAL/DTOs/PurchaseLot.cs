namespace AllVueInvestmentTest_DAL.DTOs
{
    public class PurchaseLot
    {
        public int Shares { get; set; }
        public decimal CostPerShare { get; set; }
        public DateTime PurchaseDate { get; set; }

        public PurchaseLot(int shares, decimal costPerShare, DateTime purchaseDate)
        {
            Shares = shares;
            CostPerShare = costPerShare;
            PurchaseDate = purchaseDate;
        }
    }

    

}
