using Microsoft.AspNetCore.Mvc;
using LogicDeterminate;
using PaymentsPercents.Model;

namespace PaymentsPercents.Controllers
{
    public class DeterminateController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Payments(DepositeModel deposite, PaymentsModel payments)
        {
            Determinate determinate = new Determinate();
            payments.MainDebt = determinate.DeterminationMainPayment(deposite.InvestmentAmount, deposite.InvestmentTerm);

            payments.SumInterestPayments = determinate.DeterminationAccruedInterest(deposite.InvestmentTerm,
                  deposite.InterestRate, deposite.InvestmentAmount);

            payments.CurrentDebtBalance = determinate.RemainingDebts;
            payments.MonthInterestPayments = determinate.MonthAccruedInterest;
            payments.AmountOfPaymenstInMonth = determinate.AmountOfPaymentsInMonth;
            payments.DatesList = determinate.FindDate();
            return View(payments);
        }
    }
}
