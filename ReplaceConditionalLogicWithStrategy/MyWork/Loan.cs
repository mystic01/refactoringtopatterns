using System;
using System.Collections.Generic;

namespace ReplaceConditionalLogicWithStrategy.MyWork
{
    public class Loan
    {
        private double _commitment = 1.0;
        private DateTime? _expiry;
        private DateTime? _maturity;
        private double _outstanding;
        private IList<Payment> _payments = new List<Payment>();
        private DateTime? _today = DateTime.Now;
        private DateTime _start;
        private double _riskRating;
        private double _unusedPercentage;
        private readonly CapitalStrategy _capitalStrategy;

        private Loan(double commitment, double notSureWhatThisIs, DateTime start, DateTime? expiry, DateTime? maturity,
            int riskRating, CapitalStrategy capitalStrategy)
        {
            this._expiry = expiry;
            this._commitment = commitment;
            this._today = null;
            this._start = start;
            this._maturity = maturity;
            this._riskRating = riskRating;
            this._unusedPercentage = 1.0;
            _capitalStrategy = capitalStrategy;
        }

        public double Commitment
        {
            set { _commitment = value; }
            get { return _commitment; }
        }

        public DateTime? Expiry
        {
            set { _expiry = value; }
            get { return _expiry; }
        }

        public DateTime? Maturity
        {
            set { _maturity = value; }
            get { return _maturity; }
        }

        public double RiskRating
        {
            set { _riskRating = value; }
            get { return _riskRating; }
        }

        public IList<Payment> Payments
        {
            set { _payments = value; }
            get { return _payments; }
        }

        public DateTime? Today
        {
            set { _today = value; }
            get { return _today; }
        }

        public DateTime Start
        {
            set { _start = value; }
            get { return _start; }
        }

        public static Loan NewTermLoan(double commitment, DateTime start, DateTime maturity, int riskRating)
        {
            return new Loan(commitment, commitment, start, null,
                            maturity, riskRating, new CapitalStrategyTermLoan());
        }

        public static Loan NewRevolver(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            return new Loan(commitment, 0, start, expiry,
                            null, riskRating, new CapitalStrategyRevolver());
        }

        public static Loan NewAdvisedLine(double commitment, DateTime start, DateTime expiry, int riskRating)
        {
            if (riskRating > 3) return null;
            Loan advisedLine = new Loan(commitment, 0, start, expiry,
                            null, riskRating, new CapitalStrategyAdvisedLine());
            advisedLine.SetUnusedPercentage(0.1);
            return advisedLine;
        }

        public void Payment(double amount, DateTime paymentDate)
        {
            _payments.Add(new Payment(amount, paymentDate));
        }

        public double Capital()
        {
            return _capitalStrategy.capital(this);
        }

        public double Duration()
        {
            return _capitalStrategy.duration(this);
        }

        public double GetUnusedPercentage()
        {
            return _unusedPercentage;
        }

        public void SetUnusedPercentage(double unusedPercentage)
        {
            _unusedPercentage = unusedPercentage;
        }

        public double UnusedRiskAmount()
        {
            return (_commitment - _outstanding);
        }

        public double OutstandingRiskAmount()
        {
            return _outstanding;
        }
    }
}