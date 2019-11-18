namespace ExampleInjection
{

    public  interface IMath
    {
        int Calculate(int a, int b);
    }

    public class Add : IMath
    {
        public int Calculate(int a, int b)
        {
            return a + b;
        }
    }

    public class Substraction : IMath
    {
        public int Calculate(int a, int b)
        {
            return a - b;
        }

    }
    public class Multiplication : IMath
    {
        public int Calculate(int a, int b)
        {
            return a * b;
        }

    }
}