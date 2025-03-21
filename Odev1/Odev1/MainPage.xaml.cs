using System;
using Microsoft.Maui.Controls;

namespace Odev1
{
    public partial class MainPage : ContentPage
    {
        private string _currentInput = "";
        private string _operator = "";
        private double _firstNumber;
        private bool _isNewEntry = true;

        public MainPage()
        {
            InitializeComponent();
        }

        private void SayiButonu(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            string number = button.Text;

            if (_isNewEntry || ResultLabel.Text == "0")
            {
                ResultLabel.Text = number;
                _isNewEntry = false;
            }
            else
            {
                ResultLabel.Text += number;
            }
        }

        private void IslemButonu(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            _operator = button.Text;
            _firstNumber = double.Parse(ResultLabel.Text);
            _isNewEntry = true;
        }

        private void EsittirButonu(object sender, EventArgs e)
        {
            double secondNumber = double.Parse(ResultLabel.Text);
            double result = 0;

            switch (_operator)
            {
                case "+":
                    result = _firstNumber + secondNumber;
                    break;
                case "-":
                    result = _firstNumber - secondNumber;
                    break;
                case "×":
                    result = _firstNumber * secondNumber;
                    break;
                case "÷":
                    result = secondNumber != 0 ? _firstNumber / secondNumber : 0;
                    if (secondNumber == 0)
                        ResultLabel.Text = "Tanımsız";
                    break;
                case "%":
                    result = _firstNumber % secondNumber;
                    break;
            }

            if (secondNumber != 0 || _operator != "÷")
            {
                ResultLabel.Text = result.ToString();
            }
            _isNewEntry = true;
        }

        private void TemizleButonu(object sender, EventArgs e)
        {
            ResultLabel.Text = "0";
            _currentInput = "";
            _operator = "";
            _firstNumber = 0;
            _isNewEntry = true;
        }

        private void TemizleGirisButonu(object sender, EventArgs e)
        {
            ResultLabel.Text = "0";
            _isNewEntry = true;
        }

        private void GeriSilButonu(object sender, EventArgs e)
        {
            if (ResultLabel.Text.Length > 1)
                ResultLabel.Text = ResultLabel.Text.Substring(0, ResultLabel.Text.Length - 1);
            else
                ResultLabel.Text = "0";
        }

        private void IsaretDegistirButonu(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(ResultLabel.Text) && ResultLabel.Text != "0")
            {
                if (ResultLabel.Text.StartsWith("-"))
                {
                    ResultLabel.Text = ResultLabel.Text.Substring(1);
                }
                else
                {
                    ResultLabel.Text = "-" + ResultLabel.Text;
                }
            }
        }

        private void KaresiniAlButonu(object sender, EventArgs e)
        {
            double number = double.Parse(ResultLabel.Text);
            ResultLabel.Text = (number * number).ToString();
        }

        private void KarekokAlButonu(object sender, EventArgs e)
        {
            double number = double.Parse(ResultLabel.Text);
            if (number >= 0)
                ResultLabel.Text = Math.Sqrt(number).ToString();
            else
                ResultLabel.Text = "Geçersiz Girdi";
        }

        private void TersiniAlButonu(object sender, EventArgs e)
        {
            double number = double.Parse(ResultLabel.Text);
            if (number != 0)
                ResultLabel.Text = (1 / number).ToString();
            else
                ResultLabel.Text = "Sıfıra Bölünemez";
        }
    }
}
