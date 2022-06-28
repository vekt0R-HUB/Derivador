using System;
using MathemathicExpresion;

public class Program
{
    public static void Main()
    {
        var s = new Constant(4);
        var t = new Variable('a');
        var r = new Multiplication(s,t);

        System.Console.WriteLine(r.DerivateInVariable().Symplify());
    }
}
