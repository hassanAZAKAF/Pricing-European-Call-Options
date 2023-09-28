using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MathNet.Numerics.Distributions;

namespace European_Call_Option_Pricing

{
    public class BlackScholes
{
    public double callPrice;
    public double CallPrice(double Spot, double Strike, double InterestRate, double Maturity, double Volatility)
    {
        double d1 = (Math.Log(Spot / Strike) + (InterestRate + 0.5 * Math.Pow(Volatility, 2)) * Maturity) / (Volatility * Math.Sqrt(Maturity));
        double d2 = d1 - Volatility * Math.Sqrt(Maturity);
            callPrice = Normal.CDF(0,1,d1) * Spot - Normal.CDF(0,1,d2) * Strike * Math.Exp(-InterestRate * Maturity);
        return callPrice;
    }
}
}