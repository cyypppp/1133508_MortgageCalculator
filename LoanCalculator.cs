using System;

public class LoanCalculator
{
    public struct LoanResult
    {
        public double TotalLoanAmount;
        public double MonthlyPayment;
        public double FirstMonthInterest;
        public double FirstMonthPrincipal;
        public double TotalInterest;
        public double TotalPayment;
    }

    public static LoanResult Calculate(double totalPrice, double downPayment, double annualRate, int years, int graceYears)
    {
        double principal = totalPrice - downPayment;
        double monthlyRate = annualRate / 100 / 12;
        int totalMonths = years * 12;
        int graceMonths = graceYears * 12;

        LoanResult result = new LoanResult();
        result.TotalLoanAmount = principal;
        result.FirstMonthInterest = principal * monthlyRate;

        if (graceMonths > 0)
        {
            result.MonthlyPayment = result.FirstMonthInterest;
            result.FirstMonthPrincipal = 0;

            int remainingMonths = totalMonths - graceMonths;
            double postGraceMonthlyPayment = principal * (monthlyRate * Math.Pow(1 + monthlyRate, remainingMonths)) 
                                            / (Math.Pow(1 + monthlyRate, remainingMonths) - 1);

            result.TotalPayment = (result.MonthlyPayment * graceMonths) + (postGraceMonthlyPayment * remainingMonths);
        }
        else
        {
            result.MonthlyPayment = principal * (monthlyRate * Math.Pow(1 + monthlyRate, totalMonths)) 
                                   / (Math.Pow(1 + monthlyRate, totalMonths) - 1);
            result.FirstMonthPrincipal = result.MonthlyPayment - result.FirstMonthInterest;
            result.TotalPayment = result.MonthlyPayment * totalMonths;
        }

        result.TotalInterest = result.TotalPayment - principal;
        return result;
    }
}
