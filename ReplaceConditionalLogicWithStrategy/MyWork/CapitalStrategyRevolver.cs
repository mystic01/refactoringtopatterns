namespace ReplaceConditionalLogicWithStrategy.MyWork
{
    public class CapitalStrategyRevolver : CapitalStrategy
    {
        public override double capital(Loan loan)
        {
            return (loan.OutstandingRiskAmount() * loan.Duration() * RiskFactorFor(loan))
                   + (loan.UnusedRiskAmount() * loan.Duration() * UnusedRiskFactorFor(loan));
        }
    }
}