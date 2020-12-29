using System;
using System.Numerics;


namespace Lr5Interfaces
{
    class MyFrac : IMyNumber<MyFrac>, IComparable
    {
        
        BigInteger num;
        BigInteger denom;
        public double Value
        {
            get { return (double)num / (double)denom; }
        }
        public MyFrac() { }
        public MyFrac(BigInteger num, BigInteger denom)
        {
            this.num = num;
            this.denom = denom;
        }
        public MyFrac(int num, int denom)
        {
            this.num = num;
            this.denom = denom;
        }
        public double GetValue()
        {
            return ((double)num / (double)denom);
        }
        public MyFrac Add(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.denom + this.denom * that.num, this.denom * that.denom));
        }
        public MyFrac Subtract(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.denom - this.denom * that.num, this.denom * that.denom));
        }
        public MyFrac Multiply(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.num, this.denom * that.denom));
        }
        public MyFrac Divide(MyFrac that)
        {
            return Normal(new MyFrac(this.num * that.denom, this.denom * that.num));
        }
        public override string ToString()
        {
            try
            {
                return num + "/" + denom;
            }
            catch (DivideByZeroException ex)
            {
                throw ex;
            }
        }
        public MyFrac Normal(MyFrac t)
        {
            BigInteger x, y;
            x = t.num;
            y = t.denom;
           while (y!=x&&-y!=x)
            {
                if (x > y)
                    x = x - y;
                else y = y - x;
            }
            return new MyFrac(t.num/x,t.denom/x);
        }
        public int CompareTo(object o)
        {
            MyFrac one = o as MyFrac;
            if (Value > one.Value)
            {
                return 1;
            }
            else if (Value == one.Value)
            {
                return 0;
            }
            else
            {
                return -1;
            }
        }
    }
}

