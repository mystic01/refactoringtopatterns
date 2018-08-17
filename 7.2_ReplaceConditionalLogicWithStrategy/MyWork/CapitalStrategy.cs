using System;

namespace ReplaceConditionalLogicWithStrategy.MyWork
{
    public abstract class CapitalStrategy
    {
        public abstract double capital(Loan loan);

        protected double RiskFactorFor(Loan loan)
        {
            return InitialCode.RiskFactor.GetFactors().ForRating(loan.RiskRating);
        }

        protected double UnusedRiskFactorFor(Loan loan)
        {
            return UnusedRiskFactors.GetFactors().ForRating(loan.RiskRating);
        }

        private long MILLIS_PER_DAY = 86400000;
        private long DAYS_PER_YEAR = 365;

        public virtual double duration(Loan loan)
        {
            return YearsTo(loan.Expiry, loan);
        }

        protected double YearsTo(DateTime? endDate, Loan loan)
        {
            DateTime? beginDate = (loan.Today == null ? loan.Start : loan.Today);
            return (double)((endDate?.Ticks - beginDate?.Ticks) / MILLIS_PER_DAY / DAYS_PER_YEAR);
        }
    }
}