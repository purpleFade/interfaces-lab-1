using System;
using System.IO;
using System.Windows.Forms;

namespace CreditDepositCalculator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtAmount.Text) ||
                string.IsNullOrWhiteSpace(txtRate.Text) ||
                string.IsNullOrWhiteSpace(txtYears.Text))
            {
                MessageBox.Show("Будь ласка, заповніть усі поля.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtAmount.Text, out double principal) ||
                !double.TryParse(txtRate.Text, out double rate) ||
                !int.TryParse(txtYears.Text, out int years))
            {
                MessageBox.Show("Будь ласка, введіть коректні числові значення.", "Помилка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string result = "";

            if (rbCredit.Checked)
            {
                double monthlyRate = rate / 12 / 100;
                int months = years * 12;
                double annuityPayment = principal * (monthlyRate * Math.Pow(1 + monthlyRate, months)) /
                                        (Math.Pow(1 + monthlyRate, months) - 1);
                double totalPayment = annuityPayment * months;

                result = $"Кредит: \n" +
                        $"Щомісячний платіж: {annuityPayment:F2} грн\n" +
                        $"Загальна сума до сплати: {totalPayment:F2} грн\n" +
                        $"Переплата: {totalPayment - principal:F2} грн";
            }
            else if (rbDeposit.Checked)
            {
                double totalIncome = principal * Math.Pow(1 + rate / 100, years);
                double profit = totalIncome - principal;

                result = $"Депозит: \n" +
                        $"Сума на кінець терміну: {totalIncome:F2} грн\n" +
                        $"Прибуток: {profit:F2} грн";
            }

            txtResult.Text = result;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string fileText = $"Сума: {txtAmount.Text} грн\n" +
                              $"Ставка (% річних): {txtRate.Text} \n" +
                              $"Термін (років): {txtYears.Text} \n";
            

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.Title = "Зберегти результат";
                saveFileDialog.Filter = "Текстові файли (*.txt)|*.txt|Усі файли (*.*)|*.*";
                saveFileDialog.FileName = "result.txt";

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    File.WriteAllText(saveFileDialog.FileName, fileText+txtResult.Text);
                    MessageBox.Show("Результат збережено:\n" + saveFileDialog.FileName);
                }
            }
        }
    }
}
