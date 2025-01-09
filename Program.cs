using _4_lab;
using Laba4;
using System;
using System.Numerics;

using _4_lab;
 class Program
{
    static void TestAPlusBSquare<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
        T aPlusB = a.Add(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("(a + b) = " + aPlusB);
        Console.WriteLine("(a+b)^2 = " + aPlusB.Multiply(aPlusB));
        Console.WriteLine(" = = = ");
        T curr = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr);
        T wholeRightPart = curr;
        curr = a.Multiply(b); // ab
        curr = curr.Add(curr); // ab + ab = 2ab
                               // I’m not sure how to create constant factor "2" in more elegant way,
                               // without knowing how IMyNumber is implemented
        Console.WriteLine("2*a*b = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        curr = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr);
        wholeRightPart = wholeRightPart.Add(curr);
        Console.WriteLine("a^2+2ab+b^2 = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing (a+b)^2=a^2+2ab+b^2 with a = " + a + ", b = " + b + " ===");
    }

    static void TestSquaresDifference<T>(T a, T b) where T : IMyNumber<T>
    {
        Console.WriteLine("=== Starting testing a^2 - b^2 / a + b, with a = " + a + ", b = " + b + " ===");
        T aMinusB = a.Subtract(b);
        Console.WriteLine("a = " + a);
        Console.WriteLine("b = " + b);
        Console.WriteLine("a - b = " + aMinusB);
        Console.WriteLine(" = = = ");
        T curr1 = a.Multiply(a);
        Console.WriteLine("a^2 = " + curr1);
        T curr2 = b.Multiply(b);
        Console.WriteLine("b^2 = " + curr2);
        T curr3 = curr1.Subtract(curr2);
        Console.WriteLine("a^2 - b^2 = " + curr3);
        T aPlusB = a.Add(b);
        Console.WriteLine("a + b = " + aPlusB);
        T wholeRightPart = curr3.Divide(aPlusB);
        Console.WriteLine("a^2 - b^2 / a + b = " + wholeRightPart);
        Console.WriteLine("=== Finishing testing a^2 - b^2 / a + b with a = " + a + ", b = " + b + " ===");
    }

    static void TestCompareTo(MyFrac f1, MyFrac f2)
    {
        Console.WriteLine("===");
        Console.WriteLine($"Результат порівняння дробу {f1} з дробом {f2} = {f1.CompareTo(f2)}");
        Console.WriteLine("===");
    }

    static void Main(string[] args)
    {
        TestAPlusBSquare(new MyFrac(1, 3), new MyFrac(1, 6));
        Console.WriteLine();
        TestAPlusBSquare(new MyComplex(1, 3), new MyComplex(1, 6));
        Console.WriteLine();
        TestSquaresDifference(new MyFrac(1, 3), new MyFrac(1, 6));
        Console.WriteLine();
        TestSquaresDifference(new MyComplex(1, 3), new MyComplex(1, 6));
        Console.WriteLine();
        TestCompareTo(new MyFrac(1, 3), new MyFrac(1, 6));
        Console.WriteLine();
        TestCompareTo(new MyFrac(2, 18), new MyFrac(1, 6));
        Console.WriteLine();
        TestCompareTo(new MyFrac(2, 3), new MyFrac(2, 3));
        Console.WriteLine();
        Console.ReadKey();
    }
}