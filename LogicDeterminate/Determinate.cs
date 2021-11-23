using System;
using System.Collections.Generic;

namespace LogicDeterminate
{
    public class Determinate
    {
        private double InvestmentTerm { get; set; }
        private double RemainingDebt { get; set; }
        private double MainPayment { get; set; }
        public List<double> RemainingDebts = new List<double>();
        public List<double> MonthAccruedInterest = new List<double>();
        public List<double> AmountOfPaymentsInMonth = new List<double>();
        private List<string> DataList = new List<string>();


        public double DeterminationAccruedInterest(double investmentTerm,
            double interestRate, double investmentAmount)
        {
            var amountOfAccruedInterest = 0.0;
            MainPayment = DeterminationMainPayment(investmentAmount, investmentTerm);

            for (int i = 0; i < InvestmentTerm; i++)
            {
                RemainingDebt = DeterminationCurrentDebtBalance(investmentAmount, MainPayment, i);
                RemainingDebts.Add(RemainingDebt);

                var accruedInterestInMonth = Math.Round((RemainingDebt * ((interestRate / 100) / 12)), 2);
                MonthAccruedInterest.Add(accruedInterestInMonth);

                var amountOfPayment = Math.Round((accruedInterestInMonth + MainPayment), 2);
                AmountOfPaymentsInMonth.Add(amountOfPayment);

                amountOfAccruedInterest += accruedInterestInMonth;
            }

            return amountOfAccruedInterest;
        }

        private double DeterminationCurrentDebtBalance(double investmentAmount, double mainPayment, double numberOfContributionsPaid)
        {
            var remainingDebt = Math.Round((investmentAmount - (mainPayment * numberOfContributionsPaid)), 2);
            return remainingDebt;
        }

        public double DeterminationMainPayment(double investmentAmount, double investmentTerm)
        {
            InvestmentTerm = investmentTerm;
            var mainPayment = Math.Round((investmentAmount / InvestmentTerm), 2);
            return mainPayment;
        }

        public List<string> FindDate()
        {
            DateTime time = DateTime.Now;
            for (int i = 0; i < InvestmentTerm; i++)
            {
                var newTime = time.AddMonths(i);
                DataList.Add(newTime.ToString("dd MMMM yyyy"));
            }
            return DataList;
        }
    }
}
