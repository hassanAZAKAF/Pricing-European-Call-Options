using MathNet.Numerics;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace European_Call_Option_Pricing
{
    internal class BinomialOptionPricing
    {
        public double callPrice;
        public double BinomialTreeCallPrice(double Spot, double Strike, double InterestRate, double Maturity, double u, double d, int N)
        {
            double dt = Maturity / N;
            double q = (Math.Exp(InterestRate * dt) - d) / (u - d);

            callPrice = 0;
            for (int i = 0; i < N + 1; i++)
            {
                double binom_factor = SpecialFunctions.Binomial(N,i);
                callPrice +=  binom_factor * Math.Pow(q, i) * Math.Pow(1 - q, N - i) * Math.Max(0, Spot * Math.Pow(u, i) * Math.Pow(u = d, N - i) - Strike);
            }
            callPrice = Math.Exp(-InterestRate * Maturity)*callPrice;
            return callPrice;
        }
    }
}
