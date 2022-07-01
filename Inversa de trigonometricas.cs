
namespace MathemathicExpresion;

//for all of this funtion the structure is more or less the same

public class Arcsen:UnaryExpresion
{
    public Arcsen(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="arcsen";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //arcsen'(f)= f'/(1-f)^(1/2)
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Arcsen(InternalExpresion.Evaluate(variable,valor));
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
    //arccos'(f)= -f'/(1-f)^(1/2)
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
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Arccosen(InternalExpresion.Evaluate(variable,valor));
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
    //arctan'(f)= f'/(1+f^2)
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Arctangent(InternalExpresion.Evaluate(variable,valor));
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
    //arcsec'(f)= f'/(f(1-f)^(1/2))
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Arcsecant(InternalExpresion.Evaluate(variable,valor));
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
    //arccot'(f)= -f'/(1+f^2)
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
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Arccotangent(InternalExpresion.Evaluate(variable,valor));
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
    //arccsc'(f)= -f'/(f(1-f)^(1/2))
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Arccosecant(InternalExpresion.Evaluate(variable,valor));
    }
}
