namespace MathemathicExpresion;

//for all of this funtion the structure is more or less the same

public class Sin:UnaryExpresion
{
    public Sin(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="sin";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //sen'(f)=cos(f)*f'
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Sin(InternalExpresion.Evaluate(variable,valor));
    }
    public override Expresion Modify(Expresion newInternal)
    {
        return new Sin(newInternal);
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
    //cos'(f)=-f'sen(f)
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Cosin(InternalExpresion.Evaluate(variable,valor));
    }
    public override Expresion Modify(Expresion newInternal)
    {
        return new Cosin(newInternal);
    }
}

public class Tangent:UnaryExpresion
{
    public Tangent(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="tan";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //tan'(f)=f'sec^2(f)
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return new Pow(new Secant(InternalExpresion),2)*InternalExpresion.DerivateInVariable(variable);
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Tangent(InternalExpresion.Evaluate(variable,valor));
    }
    
    public override Expresion Modify(Expresion newInternal)
    {
        return new Tangent(newInternal);
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
    //sec'(f)=f'tan(f)sec(f)
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Secant(InternalExpresion.Evaluate(variable,valor));
    }
    
    public override Expresion Modify(Expresion newInternal)
    {
        return new Secant(newInternal);
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
    //cot'(f)=-f'csc^2(f)
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return -InternalExpresion.DerivateInVariable(variable)*new Pow(new Cosecant(InternalExpresion),2);
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Cotangent(InternalExpresion.Evaluate(variable,valor));
    }
    public override Expresion Modify(Expresion newInternal)
    {
        return new Cotangent(newInternal);
    }
}

public class Cosecant:UnaryExpresion
{
    public Cosecant(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="csc";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //csc'(f)=-f'cot(f)csc(f)
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
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return new Cosecant(InternalExpresion.Evaluate(variable,valor));
    }
    
    public override Expresion Modify(Expresion newInternal)
    {
        return new Cosecant(newInternal);
    }
}
