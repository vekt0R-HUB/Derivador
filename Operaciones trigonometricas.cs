
namespace MathemathicExpresion;

public class Sin:UnaryExpresion
{
    public Sin(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="sin";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return new Cosin(InternalExpresion)*InternalExpresion.DerivateInVariable(variable);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Sin(Internal.GetValue());
        }

        catch
        {
            return new Sin(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Sin(InternalExpresion.GetValue());
    }
}

public class Cosin:UnaryExpresion
{
    public Cosin(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="cos";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return -InternalExpresion.DerivateInVariable(variable)*new Sin(InternalExpresion);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Cos(Internal.GetValue());
        }

        catch
        {
            return new Cosin(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Cos(InternalExpresion.GetValue());
    }
}

public class Tangent:UnaryExpresion
{
    public Tangent(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="cos";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return new Potence(new Secant(InternalExpresion),2)*InternalExpresion.DerivateInVariable(variable);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Tan(Internal.GetValue());
        }

        catch
        {
            return new Tangent(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Tan(InternalExpresion.GetValue());
    }
}

public class Secant:UnaryExpresion
{
    public Secant(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="sec";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return new Secant(InternalExpresion)*new Tangent(InternalExpresion)*InternalExpresion.DerivateInVariable(variable);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return 1/Math.Cos(Internal.GetValue());
        }

        catch
        {
            return new Secant(Internal);
        }
    }
    public override double GetValue()
    {
        return 1/Math.Cos(InternalExpresion.GetValue());
    }
}

public class Cotangent:UnaryExpresion
{
    public Cotangent(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="cot";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return -InternalExpresion.DerivateInVariable(variable)*new Potence(new Cosecant(InternalExpresion),2);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return 1/Math.Tan(Internal.GetValue());
        }

        catch
        {
            return new Cotangent(Internal);
        }
    }
    public override double GetValue()
    {
        return 1/Math.Tan(InternalExpresion.GetValue());
    }
}

public class Cosecant:UnaryExpresion
{
    public Cosecant(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="secant";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        
        return -InternalExpresion.DerivateInVariable(variable)*new Cosecant(InternalExpresion)*new Cotangent(InternalExpresion);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return 1/Math.Sin(Internal.GetValue());
        }

        catch
        {
            return new Cosecant(Internal);
        }
    }
    public override double GetValue()
    {
        return 1/Math.Sin(InternalExpresion.GetValue());
    }
}
