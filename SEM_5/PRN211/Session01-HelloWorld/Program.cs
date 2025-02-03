namespace Healthy;
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");
	double bmi = BMICalculator.GetBMI(48, 1.60);

	Console.WriteLine("Your BMI is "+bmi);


	Console.WriteLine("Press any key to exit!");
	
	Console.ReadLine();
    }
}
