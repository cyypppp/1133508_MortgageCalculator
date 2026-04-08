public partial class Form1 : Form
{
    public Form1()
    {
        InitializeComponent();
    }


    private void btnCalculate_Click(object sender, EventArgs e)
    {
        [cite_start]// 1. 輸入驗證：攔截非法輸入，避免程式崩潰 
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

        [cite_start]// 2. 呼叫計算邏輯 
        var result = LoanCalculator.Calculate(totalPrice, downPayment, annualRate, years, graceYears);

        [cite_start]// 3. 顯示結果：含千分位與小數點後兩位 ("N2") [cite: 19, 34]
        lblTotalLoan.Text = result.TotalLoanAmount.ToString("N2");
        lblMonthlyPay.Text = result.MonthlyPayment.ToString("N2");
        lblFirstInterest.Text = result.FirstMonthInterest.ToString("N2");
        lblFirstPrincipal.Text = result.FirstMonthPrincipal.ToString("N2");
        lblTotalInterest.Text = result.TotalInterest.ToString("N2");
        lblTotalAll.Text = result.TotalPayment.ToString("N2");
    }
}
