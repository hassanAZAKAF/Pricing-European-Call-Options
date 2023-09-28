using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics;
namespace European_Call_Option_Pricing
{
    internal class Program
    {
        static void Main(string[] args)

        {
            European_Call_Option_Pricing.BlackScholes blackScholes = new European_Call_Option_Pricing.BlackScholes();
            European_Call_Option_Pricing.BinomialOptionPricing binomial_price = new European_Call_Option_Pricing.BinomialOptionPricing();
            double Spot = 50;
            int N = 10;
            double Strike = 30;
            double InterestRate = 0.05;
            double Maturity = 1;
            double dt = Maturity / N;
            double Volatility = 0.03;
            double u = Math.Exp(Volatility*Math.Sqrt(dt));
            double d = 1 / u;
            double call_price = blackScholes.CallPrice(Spot, Strike, InterestRate, Maturity, Volatility);
            double Binomial_call_price = binomial_price.BinomialTreeCallPrice(Spot, Strike, InterestRate, Maturity, u, d, N);
            Console.WriteLine("Black Scholes Model Price");
            Console.WriteLine(call_price);
            Console.WriteLine("Binomial Model Price");
            Console.WriteLine(Binomial_call_price);
            Console.ReadLine();
        }
    }
}
