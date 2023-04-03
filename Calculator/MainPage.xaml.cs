namespace Calculator;

public partial class MainPage : ContentPage
{

	public MainPage()
	{
		InitializeComponent();
		OnClear(this, null);
	}
	string currentEntry = "";
	int currentState = 1;
	string mathOperator;
	double firstNum, secondNum;
	string decimalFormat = "N0";

	void OnClear(object sender, EventArgs e)
	{
		firstNum = 0;
		secondNum = 0;
		currentState = 1;
		decimalFormat = "N0";
		this.resultText.Text = "0";
		currentEntry = string.Empty;
	}

	void OnSelectNumber(object sender, EventArgs e)
	{
		Button button = (Button)sender;
		string pressed = button.Text;

		currentEntry += pressed;

		if((this.resultText.Text == "0" && pressed == "0")
			||(currentEntry.Length<=1 && pressed != "0")|| currentState<0)
		{
			this.resultText.Text = "";
			if (currentState < 0)
				currentState *= -1;

		}
		if(pressed == "." && decimalFormat !="N2")
		{
			decimalFormat = "N2";
		}
		this.resultText.Text += pressed;
	}

	void OnSelectOperator (object sender, EventArgs e)
	{
		LockNumberValue(resultText.Text);
		currentState = -2;
		Button button = (Button)sender;
		string pressed = button.Text;
		mathOperator = pressed;


	}

    private void LockNumberValue(string text)
    {
		double number;
		if(double.TryParse(text, out number))
		{
			if(currentState==1)
			{
				firstNum = number;

			}
			else
			{
				secondNum = number;
			}
			currentEntry = string.Empty;
		}
    }

	void OnCalculate (object sender, EventArgs e)
	{
		if(currentState==2)
		{
			if (secondNum == 0)
                decimalFormat = "N2";
            LockNumberValue(resultText.Text);
			double result = Calculator.Calculate(firstNum, secondNum, mathOperator);

			this.CurrentCalculation.Text = $"{firstNum} {mathOperator} {secondNum}";
			this.resultText.Text = result.ToTrimmedString(decimalFormat);
			firstNum = result;
			secondNum = 0;
			currentState = -1;
			currentEntry = string.Empty;
		}
	}
    void OnNegative(object sender, EventArgs e)
    {
        if (resultText.Text.StartsWith("-"))
        {
			resultText.Text = resultText.Text.Substring(1);
        }
		else if(!string.IsNullOrEmpty(resultText.Text)&&decimal.Parse(resultText.Text) !=0)
		{
			resultText.Text = "-" + resultText.Text;
		}
    }

    void OnPercentage(object sender, EventArgs e)
    {
        if (currentState == 1)
        {
            LockNumberValue(resultText.Text);
            decimalFormat = "N2";
			firstNum = 0.01;
            mathOperator = "×";
            currentState = 2;
            OnCalculate(this, null);
        }
    }


}


