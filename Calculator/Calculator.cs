using System;
namespace Calculator;

public static class Calculator
	{
		public static double Calculate(double val1, double val2, string mathOperator)
		{

			double result = 0;
			switch (mathOperator)
			{
				case "÷":
					result = val1 / val2;
					break;
                case "×":
                    result = val1 * val2;
                    break;
                case "+":
                    result = val1 + val2;
                    break;
                case "−":
                    result = val1 - val2;
                    break;

            }
			return result;
		}
		
	}
public static class DoubleExtensions
{
	public static string ToTrimmedString (this double target, string decimalFormat)
	{
		string strValue = target.ToString(decimalFormat);

		if (strValue.Contains(".")) 
		{
			strValue = strValue.TrimEnd('0');

			if (strValue.EndsWith("."))
				strValue = strValue.TrimEnd('.');

		}
		return strValue;
	}
}


