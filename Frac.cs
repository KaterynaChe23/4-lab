using System;
using System.Numerics;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using _4_lab;

namespace Laba4
{
    public class MyFrac : IMyNumber<MyFrac>, IComparable<MyFrac>
    {
        BigInteger Nom, Denom;
        public MyFrac(BigInteger nom, BigInteger denom)
        {
            if (denom != 0)
                FractionReduction(nom, denom);
            else throw new DivideByZeroException();
        }
        public MyFrac(int nom, int denom)
        {
            if (denom != 0)
                FractionReduction(nom, denom);
            else throw new DivideByZeroException();
        }

        public MyFrac(string input)
        {
            string[] inp = input.Split('/');
            FractionReduction(BigInteger.Parse(inp[0]), BigInteger.Parse(inp[1]));
        }

        private void FractionReduction(BigInteger n, BigInteger d)
        {
            if (d < 0)
            {
                n = -n;
                d = -d;
            }
            BigInteger a = n;
            if (a < 0) { a = -a; }
            BigInteger b = d;
            BigInteger temp;
            while (b != 0)
            {
                temp = b;
                b = a % b;
                a = temp;
            }
            this.Nom = n / a;
            this.Denom = d / a;
        }

        public BigInteger nom
        {
            get
            {
                return Nom;
            }
            set
            {
                FractionReduction(value, denom);
            }
        }
        public BigInteger denom
        {
            get
            {
                return Denom;
            }
            set
            {
                if (value != 0)
                {
                    FractionReduction(nom, value);
                }
                else throw new DivideByZeroException();
            }
        }
        public override String ToString()
        {
            return nom + "/" + denom;
        }

        public MyFrac Add(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom + that.nom * this.denom, this.denom * that.denom);
        }

        public MyFrac Subtract(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom - that.nom * this.denom, this.denom * that.denom);
        }

        public MyFrac Multiply(MyFrac that)
        {
            return new MyFrac(this.nom * that.nom, this.denom * that.denom);
        }
        public MyFrac Divide(MyFrac that)
        {
            return new MyFrac(this.nom * that.denom, this.denom * that.nom);
        }


        public int CompareTo(MyFrac that)
        {
            BigInteger temp_den = this.denom * that.denom;
            BigInteger temp_thisnom = this.nom * that.denom;
            BigInteger temp_thatnom = that.nom * this.denom;

            if (temp_thisnom > temp_thatnom)
                return 1;
            if (temp_thisnom < temp_thatnom)
                return -1;
            else
                return 0;
        }

    }
}
