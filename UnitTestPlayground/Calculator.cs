namespace UnitTestPlayground
{
    public class Calculator
    {
        public double Sum(double number1, double number2) => number1 + number2;
        public double Average(List<double> numberList) => numberList.Average();
        public double Divide(int numerator, int denominator) => numerator / denominator;
    }
}