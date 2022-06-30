namespace MathemathicExpresion;

public class Potence : BinaryExpresion
{
    public Potence(Expresion Left, Expresion Rigth)
    {
        LeftExpresion = Left;
        RigthExpresion = Rigth;
        ExpresionOperator = "^";
        Priotity = 2;
    }
    public Potence(Expresion Exponent)
    {
        LeftExpresion = System.Math.E;
        RigthExpresion = Exponent;
        ExpresionOperator = "e^";
        Priotity = 2;
    }
    public Potence(Expresion Base, double Exponent)
    {
        if (Exponent == 0 && !base.Equals(0))
        {
            LeftExpresion = 1;
            RigthExpresion = 1;
            ExpresionOperator = "^";
            Priotity = 3;

        }
        LeftExpresion = Base;
        RigthExpresion = Exponent;
        ExpresionOperator = "^" + Exponent;
        Priotity = 3;
    }

    public override string ToString()
    {
        if (ExpresionOperator == "e^")
            return ExpresionOperator + "(" + RigthExpresion + ")";
        if (ExpresionOperator.Length > 1)
            return "(" + LeftExpresion + ")" + ExpresionOperator;
        return base.ToString();
    }

    public override Expresion DerivateInVariable(char variable = '\0')
    {
        if (variable == '\0')
            variable = GetAVariable();
        if (variable == '\0')
            return 0;

        if (ExpresionOperator == "e^")
            return RigthExpresion.DerivateInVariable(variable) * new Potence(RigthExpresion);
        if (ExpresionOperator.Length > 1)
        {
            double Exponent = double.Parse(ExpresionOperator.Remove(0, 1));
            Expresion left = Exponent * new Potence(LeftExpresion, (Exponent - 1));
            return left * LeftExpresion.DerivateInVariable(variable);
        }

        Expresion Left = RigthExpresion * new Logaritm(LeftExpresion);
        return Left.DerivateInVariable(variable) * new Potence(LeftExpresion, RigthExpresion);
    }


    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double l = Left.GetValue();
            if (l == 0)
                return 0;
            if (l == 1)
                return 1;
            return Math.Pow(l, Right.GetValue());
        }

        catch
        {
            try
            {
                double r = Right.GetValue();
                if (r == 0)
                    return 1;
                if (r == 1)
                    return Left;
            }
            catch { }
            if (ExpresionOperator == "e^")
                return new Potence(Right);
            return new Potence(Left, Right);
        }

    }
    public override double GetValue() => Math.Pow(LeftExpresion.GetValue(), RigthExpresion.GetValue());
    public override Expresion Evaluate(char variable, double valor)
    {
        if (ExpresionOperator == "e^")
            return new Potence(RigthExpresion.Evaluate(variable, valor));
        return new Potence(LeftExpresion.Evaluate(variable, valor), RigthExpresion.Evaluate(variable, valor));
    }
}

public class Logaritm : BinaryExpresion
{
    public Logaritm(Expresion Left, Expresion Rigth)
    {
        LeftExpresion = Left;
        RigthExpresion = Rigth;
        ExpresionOperator = "log";
        if (Left == new Constant(System.Math.E))
            ExpresionOperator = "ln";
        Priotity = 3;
    }
    public Logaritm(Expresion Rigth)
    {
        LeftExpresion = System.Math.E;
        RigthExpresion = Rigth;
        ExpresionOperator = "ln";
        Priotity = 2;
    }
    public Logaritm(Expresion Rigth, double Base)
    {
        LeftExpresion = new Constant(Base);
        RigthExpresion = Rigth;
        ExpresionOperator = "log[" + Base + "]";
        Priotity = 2;
    }

    public override string ToString()
    {
        if (ExpresionOperator == "ln")
            return "ln" + "(" + RigthExpresion + ")";
        if (ExpresionOperator.Length > 3)
            return ExpresionOperator + "(" + RigthExpresion + ")";
        return ExpresionOperator + "[" + LeftExpresion + "]" + "(" + RigthExpresion + ")";
    }
    public override Expresion DerivateInVariable(char variable = '\0')
    {
        if (variable == '\0')
            variable = GetAVariable();
        if (variable == '\0')
            return 0;

        if (ExpresionOperator == "ln")
            return RigthExpresion.DerivateInVariable(variable) / RigthExpresion;

        if (ExpresionOperator.Length > 3)
        {
            double Base = double.Parse(ExpresionOperator.Remove(0, 4).Remove(ExpresionOperator.Length - 1));
            return RigthExpresion.DerivateInVariable(variable) / (RigthExpresion * new Logaritm(Base));
        }

        Expresion divition = new Logaritm(RigthExpresion) / new Logaritm(LeftExpresion);
        return divition.DerivateInVariable(variable);
    }

    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double r = Right.GetValue();
            if (r == 1)
                return 0;
            return Math.Log(r, Left.GetValue());
        }

        catch
        {
            if (Left.Equals(Right))
                return 1;
            return new Logaritm(Left, Right);
        }
    }
    public override double GetValue() => Math.Log(RigthExpresion.GetValue(), LeftExpresion.GetValue());
    public override Expresion Evaluate(char variable, double valor)
    {
        if (ExpresionOperator == "ln")
            return new Logaritm(RigthExpresion.Evaluate(variable, valor));
        return new Logaritm(LeftExpresion.Evaluate(variable, valor), RigthExpresion.Evaluate(variable, valor));
    }
}

