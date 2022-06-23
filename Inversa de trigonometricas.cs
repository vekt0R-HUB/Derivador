
namespace MathemathicExpresion;

public class Arcsen:UnaryExpresion
{
    public Arcsen(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="arcsen";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return InternalExpresion.DerivateInVariable(variable)/
        (1-new Potence(new Potence(InternalExpresion,2),0.5));
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Asin(Internal.GetValue());
        }

        catch
        {
            return new Arcsen(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Asin(InternalExpresion.GetValue());
    }
}

public class Arccosen:UnaryExpresion
{
    public Arccosen(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="arccos";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return -InternalExpresion.DerivateInVariable(variable)/
        (1-new Potence(new Potence(InternalExpresion,2),0.5));
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Acos(Internal.GetValue());
        }

        catch
        {
            return new Arccosen(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Acos(InternalExpresion.GetValue());
    }
}

public class Arctangent:UnaryExpresion
{
    public Arctangent(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="arctan";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return InternalExpresion.DerivateInVariable(variable)/(1+new Potence(InternalExpresion,2));
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Atan(Internal.GetValue());
        }

        catch
        {
            return new Arctangent(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Atan(InternalExpresion.GetValue());
    }
}

public class Arcsecant:UnaryExpresion
{
    public Arcsecant(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="arcsec";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return InternalExpresion.DerivateInVariable(variable)/InternalExpresion*
        new Potence((1-new Potence(InternalExpresion,2)),0.5);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Acos(1/Internal.GetValue());
        }

        catch
        {
            return new Arcsecant(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Acos(1/InternalExpresion.GetValue());
    }
}

public class Arccotangent:UnaryExpresion
{
    public Arccotangent(Expresion Internal)
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
        return -InternalExpresion.DerivateInVariable(variable)/new Potence(1+InternalExpresion,2);
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Atan(1/Internal.GetValue());
        }

        catch
        {
            return new Arccotangent(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Atan(1/InternalExpresion.GetValue());
    }
}

public class Arccosecant:UnaryExpresion
{
    public Arccosecant(Expresion Internal)
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
        
        return -InternalExpresion.DerivateInVariable(variable)/InternalExpresion*
        new Potence(1-new Potence(InternalExpresion,2),0.5);
    
    }
    public override Expresion Symplify()
    {
        Expresion Internal=InternalExpresion.Symplify();
        try
        {
            return Math.Asin(1/Internal.GetValue());
        }

        catch
        {
            return new Arccosecant(Internal);
        }
    }
    public override double GetValue()
    {
        return Math.Asin(1/InternalExpresion.GetValue());
    }
}
