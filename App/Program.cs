using System;
using MathemathicExpresion;

public class Program
{
    public static void Main()
    {
        var s = new Constant(4);
        var t = new Variable('a');
        var r = new Multiplication(s,t);
        var p = new Sin(r);
        var x = new Sum(r,s);
        var y = new Potence(new Constant(Math.E),x);

        System.Console.WriteLine(y.DerivateInVariable().Symplify());
    }
}
