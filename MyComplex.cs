using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lr5Interfaces
{
    class MyComplex : IMyNumber<MyComplex>
    {
        double re { get; set; }
        double im { get; set; }
        public MyComplex() { }
        public MyComplex(double re, double im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex(int re, int im)
        {
            this.re = re;
            this.im = im;
        }
        public MyComplex Add(MyComplex that)
        {
            return new MyComplex(this.re + that.re, this.im + that.im);
        }
        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }
        public MyComplex Multiply(MyComplex that)
        {
            return new MyComplex(this.re * that.re - this.im * that.im, this.re * that.im + this.im * that.re);
        }
        public MyComplex Divide(MyComplex that)
        {
            try
            {
                return new MyComplex((this.re * that.re + this.im * that.im) / (Math.Pow(that.re, 2) + Math.Pow(that.im, 2)),
                                  (this.im * that.re - this.re * that.im) / (Math.Pow(that.re, 2) + Math.Pow(that.im, 2)));
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }

        }
        public override string ToString()
        {
            return  re + " + " +im+"i";
        }
    }
}
