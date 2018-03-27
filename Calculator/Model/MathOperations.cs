using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator.Model
{
   public class MathOperations 
    {
        private double number1;
        private double number2;

        public MathOperations(double n1, double n2)
        {
            this.number1 = n1;
            this.number2 = n2;
        }

        public double multiply()
        {
            return number1 * number2;
        }

        public double divided()
        {
           
            return number1 / number2;
                
        }
        public double plus()
        {
            return number1 + number2;
        }
        public double minus()
        {
            return number1 - number2;
        }
        public double operationLog()
        {
            return Math.Log(number1);
        }

        public double operationSinus()
        {
            return Math.Sin(number1);
        }
        public double operationCosinus()
        {
            return Math.Cos(number1);
        }

        public double operationSqrt()
        {
            return Math.Sqrt(number1);
        }
        public double operationSquare()
        {
            return Math.Pow(number1, 2);
        }


    }
}
