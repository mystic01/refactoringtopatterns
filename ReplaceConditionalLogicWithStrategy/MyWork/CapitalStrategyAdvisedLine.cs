namespace ReplaceConditionalLogicWithStrategy.MyWork
{
    public class CapitalStrategyAdvisedLine : CapitalStrategy
    {
        public override double capital(Loan loan)
        {
            return loan.Commitment * loan.GetUnusedPercentage() * loan.Duration() * RiskFactorFor(loan);
        }
    }
}