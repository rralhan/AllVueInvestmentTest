namespace AllVueInvestmentTest_BL.Models
{
    public class PurchaseLot
    {
        public int Shares { get; }
        public decimal CostPerShare { get; }
        public DateTime PurchaseDate { get; }

        public PurchaseLot(int shares, decimal costPerShare, DateTime purchaseDate)
        {
            Shares = shares;
            CostPerShare = costPerShare;
            PurchaseDate = purchaseDate;
        }

        // A static method to map from DAL to BLL
        public static PurchaseLot FromDto(AllVueInvestmentTest_DAL.DTOs.PurchaseLot dto)
        {
            return new PurchaseLot(dto.Shares, dto.CostPerShare, dto.PurchaseDate);
        }

        // Optionally, to map back to DAL if needed
        public AllVueInvestmentTest_DAL.DTOs.PurchaseLot ToDto()
        {
            return new AllVueInvestmentTest_DAL.DTOs.PurchaseLot(Shares, CostPerShare, PurchaseDate);
        }
    }
}
