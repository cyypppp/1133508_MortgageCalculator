private void btnCalculate_Click(object sender, EventArgs e)
{
    if (!double.TryParse(txtTotalPrice.Text, out double totalPrice) ||
        !double.TryParse(txtDownPayment.Text, out double downPayment) ||
        !double.TryParse(txtInterestRate.Text, out double annualRate) ||
        !int.TryParse(txtLoanYears.Text, out int years))
    {
        MessageBox.Show("請輸入正確的數值");
        return;
    }

    int graceYears = 0;
    int.TryParse(txtGracePeriod.Text, out graceYears);

    var result = LoanCalculator.Calculate(totalPrice, downPayment, annualRate, years, graceYears);

    lblTotalLoan.Text = result.TotalLoanAmount.ToString("N2");
    lblMonthlyPay.Text = result.MonthlyPayment.ToString("N2");
    lblFirstInterest.Text = result.FirstMonthInterest.ToString("N2");
    lblFirstPrincipal.Text = result.FirstMonthPrincipal.ToString("N2");
    lblTotalInterest.Text = result.TotalInterest.ToString("N2");
    lblTotalAll.Text = result.TotalPayment.ToString("N2");
}
