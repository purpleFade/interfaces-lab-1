using System.Drawing;
using System.Windows.Forms;

namespace CreditDepositCalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        private Label lblAmount, lblRate, lblYears, txtResult;
        private TextBox txtAmount, txtRate, txtYears;
        private RadioButton rbCredit, rbDeposit;
        private Button btnCalculate, btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.Text = "Фінансовий калькулятор";          
            this.ClientSize = new Size(430, 460);          
            this.StartPosition = FormStartPosition.CenterScreen;

            lblAmount = new Label { Text = "Сума (грн):", Location = new Point(20, 20), AutoSize = true };
            txtAmount = new TextBox { Location = new Point(200, 20), Width = 190 };

            lblRate = new Label { Text = "Ставка (річна, %):", Location = new Point(20, 60), AutoSize = true };
            txtRate = new TextBox { Location = new Point(200, 60), Width = 190 };

            lblYears = new Label { Text = "Термін, років:", Location = new Point(20, 100), AutoSize = true };
            txtYears = new TextBox { Location = new Point(200, 100), Width = 190 };

            rbCredit = new RadioButton { Text = "Кредит", Location = new Point(200, 140), Checked = true };
            rbDeposit = new RadioButton { Text = "Депозит", Location = new Point(300, 140) };

            btnCalculate = new Button { Text = "Розрахувати", Location = new Point(200, 185), Size = new Size(110, 30) };
            btnSave = new Button { Text = "Записати", Location = new Point(320, 185), Size = new Size(85, 30) };

            txtResult = new Label { Text = string.Empty, Location = new Point(20, 235), AutoSize = true };

            btnCalculate.Click += btnCalculate_Click;
            btnSave.Click += btnSave_Click;

            this.Controls.AddRange(new Control[]
            {
                lblAmount, txtAmount,
                lblRate,   txtRate,
                lblYears,  txtYears,
                rbCredit,  rbDeposit,
                btnCalculate, btnSave,
                txtResult
            });
        }

    }
}