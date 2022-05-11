namespace Calculator
{
    public partial class Form1 : Form
    {
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

            tbScreen.Text += clickedValue;
        }

        private void OnBtnOperationClick(object sender, EventArgs e)
        {

        }

        private void OnBtnResultClick(object sender, EventArgs e)
        {

        }

        private void OnBtnClearClick(object sender, EventArgs e)
        {
            tbScreen.Text = String.Empty;
        }

    }
}