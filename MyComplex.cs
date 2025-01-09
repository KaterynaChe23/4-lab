using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace _4_lab
{
     class MyComplex: IMyNumber<MyComplex>
    {
        private double re, im;
        public MyComplex(double re, double im) 
        {
            this.re = re;
            this.im = im;
        }
        public double Re
        { get { return re; } set { re = value; } }
        public double Im { get { return im;} set { im = value; } }

        //to String- щоб забезпечити осмислене виведення вiдповiдних чисел.

        public MyComplex Add(MyComplex that) 
        {
            return new MyComplex(this.re+that.re,this.im+that.im);
        }
        public MyComplex Subtract(MyComplex that)
        {
            return new MyComplex(this.re - that.re, this.im - that.im);
        }

        public MyComplex Multiply(MyComplex that)
        {
            double res1 = (this.re * that.re) -(this.im - that.im);
            double res2 = (this.re * that.re) + (this.im + that.im);
            return new MyComplex(res1, res2);   

        }
        public MyComplex Divide(MyComplex that)
        {
            double sum = Math.Pow(that.re, 2) + Math.Pow(that.im, 2);
            if (sum == 0)
                throw new DivideByZeroException(); 
        
            double res1 = (this.re * that.re) + (this.im - that.im)/sum;
            double res2 = (this.im + that.im)-(this.re * that.re)/sum;
            return new MyComplex(res1, res2);

        }

        public MyComplex(string input)
        {
            string[] i = input.Split(" + ");
             this.re=double.Parse(i[0]);
            this.im=double.Parse(i[1].TrimEnd('i'));
        }

        public override string ToString()
        {
            if (im == 0) return $"{re}-дійсне число";
            else if (re == 0) return $"{im}i -не дійсне число";
            else return $"{re} + {im}i";
        }


    }
}
