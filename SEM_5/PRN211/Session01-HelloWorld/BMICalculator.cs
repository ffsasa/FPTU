namespace Healthy;
public class BMICalculator
{
    public static double GetBMI(double weight, double height)
    {
	return weight / (height*height);
	
    }
}
