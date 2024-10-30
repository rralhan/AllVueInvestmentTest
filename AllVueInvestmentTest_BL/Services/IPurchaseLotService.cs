using AllVueInvestmentTest_BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


    namespace AllVueInvestmentTest_BL.Interfaces
    {
        public interface IPurchaseLotService
        {
            void AddPurchaseLot(PurchaseLot purchaseLot);
            TransactionResult CalculateSale(int sharesSold, decimal salePricePerShare, string strategy);
        }
    }


