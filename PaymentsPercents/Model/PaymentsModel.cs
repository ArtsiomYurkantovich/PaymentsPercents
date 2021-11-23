using System.Collections.Generic;

namespace PaymentsPercents.Model
{
    public class PaymentsModel
    {
        public List<string> DatesList { get; set; }
        public List<double> AmountOfPaymenstInMonth { get; set; }
        public double MainDebt { get; set; }
        public List<double> MonthInterestPayments { get; set; }
        public List<double> CurrentDebtBalance { get; set; }
        public double SumInterestPayments { get; set; }
    }
}
