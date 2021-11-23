using System.ComponentModel;

namespace PaymentsPercents.Model
{
    public class DepositeModel
    {
        [DisplayName("Investment duration (months)")]
        public double InvestmentTerm { get; set; }

        [DisplayName("Interest rate (%)")]
        public double InterestRate { get; set; }

        [DisplayName("Investment amount ($)")]
        public double InvestmentAmount { get; set; }
    }
}
