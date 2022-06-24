using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StockMarket
{
    public class Investor
    {
        public Investor(string fullName, string emailAddress, decimal moneyToInvest, string brokerName)
        {
            Portfolio = new List<Stock>();
            FullName = fullName;
            EmailAddress = emailAddress;
            MoneyToInvest = moneyToInvest;
            BrokerName = brokerName;
        }

        public List<Stock> Portfolio { get; set; }

        public string FullName { get; set; }

        public string EmailAddress { get; set; }

        public decimal MoneyToInvest { get; set; }

        public string BrokerName { get; set; }

        public int Count => Portfolio.Count;

        public void BuyStock(Stock stock)
        {
            if (stock.MarketCapitalization > 10000 && MoneyToInvest >= stock.PricePerShare)
            {
                MoneyToInvest -= stock.PricePerShare;
                Portfolio.Add(stock);
            }
        }

        public string SellStock(string companyName, decimal sellPrice)
        {
            if (!Portfolio.Any(s => s.CompanyName == companyName))
            {
                return $"{companyName} does not exist.";
            }

            if (Portfolio.Find(s => s.CompanyName == companyName).PricePerShare > sellPrice)
            {
                return $"Cannot sell {companyName}.";
            }

            Portfolio.Remove(Portfolio.Find(s => s.CompanyName == companyName));
            MoneyToInvest += sellPrice;
            return $"{companyName} was sold.";
        }

        public Stock FindStock(string companyName)
        {
            return Portfolio.FirstOrDefault(s => s.CompanyName == companyName);
        }

        public Stock FindBiggestCompany()
        {
            return Portfolio.OrderByDescending(s => s.MarketCapitalization).FirstOrDefault();
        }

        public string InvestorInformation()
        {
            StringBuilder result = new StringBuilder();
            result.AppendLine($"The investor {FullName} with a broker {BrokerName} has stocks:");

            foreach (var stock in Portfolio)
            {
                result.AppendLine(stock.ToString());
            }

            return result.ToString();
        }
    }
}
