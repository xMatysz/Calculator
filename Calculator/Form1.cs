namespace Calculator
{
    public enum Operation
    {
        None,
        Addition,
        Subtraction,
        Multiplication,
        Division
    }
    public partial class Form1 : Form
    {
        private string _firstValue = String.Empty;
        private string _secondValue = String.Empty;
        private Operation _currentOperation = Operation.None;
        private bool _isTheResultOnTheScreen = false;
        public Form1()
        {
            InitializeComponent();
            tbScreen.Text = "0";
        }

        private void OnBtnNumberClick(object sender, EventArgs e)
        {
            var clickedValue = (sender as Button).Text;

            if(tbScreen.Text == "0" && clickedValue != ",")
                tbScreen.Text = String.Empty;

            if (_isTheResultOnTheScreen)
            {
                _isTheResultOnTheScreen = false;
                tbScreen.Text = String.Empty;

                if (clickedValue == ",")
                    tbScreen.Text = "0";
            }

            if(_currentOperation != Operation.None && clickedValue == "," && _secondValue == String.Empty)
                tbScreen.Text += "0";

            tbScreen.Text += clickedValue;

            if(_currentOperation != Operation.None)
            {
                _secondValue += clickedValue;
            }

            SetResultBtnState(true);
        }

        private void OnBtnOperationClick(object sender, EventArgs e)
        {
            if (_currentOperation != Operation.None)
            {
                _currentOperation = Operation.None;
                tbScreen.Text = _firstValue;
            }

            _firstValue = tbScreen.Text;

            var operation = (sender as Button).Text;

            _currentOperation = operation switch
            {
                "+" => Operation.Addition,
                "-" => Operation.Subtraction,
                "*" => Operation.Multiplication,
                "/" => Operation.Division,
                _ => Operation.None,
            };

            tbScreen.Text += $" {operation} ";

            if(_isTheResultOnTheScreen)
                _isTheResultOnTheScreen=false;

            SetResultBtnState(false);
        }

        private void OnBtnResultClick(object sender, EventArgs e)
        {
            var firstNumber = double.Parse(_firstValue);
            var secondNumber = double.Parse(_secondValue);

            var result = Calculate(firstNumber, secondNumber);

            tbScreen.Text = result.ToString();

            _secondValue = string.Empty;
            _currentOperation = Operation.None;
            _isTheResultOnTheScreen = true;

            SetResultBtnState(false);
        }

        private double Calculate(double firstNumber, double secondNumber)
        {
            switch (_currentOperation)
            {
                case Operation.None:
                    return firstNumber;            
                case Operation.Addition:
                    return firstNumber + secondNumber;   
                case Operation.Subtraction:
                    return firstNumber - secondNumber;
                case Operation.Multiplication:
                    return firstNumber * secondNumber;
                case Operation.Division:
                    if (secondNumber == 0)
                    {
                        MessageBox.Show("Nie dziel cholero przez zero");
                        return 0;
                    }
                    return firstNumber / secondNumber;
            }
            return 0;
        }

        private void OnBtnClearClick(object sender, EventArgs e)
        {
            tbScreen.Text = "0";

            _firstValue = string.Empty;
            _secondValue= string.Empty;
            _currentOperation= Operation.None;
        }

        private void SetResultBtnState (bool value)
        {
            btnResult.Enabled = value;
        }
    }
}