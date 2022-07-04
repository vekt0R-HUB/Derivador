namespace MathemathicExpresion;

public class Sum:BinaryExpresion
{
    public Sum(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="+";
        Priotity=1;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //(f+g)'=f'+g'
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return LeftExpresion.DerivateInVariable(variable)+RigthExpresion.DerivateInVariable(variable);
    }
    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        
        try
        //try cases 0+f or a+b
        {
            double l= Left.GetValue();
            if(l==0)
                return Right;
            return l+Right.GetValue();
        }
        catch
        {
            try
            //try case f+0
            {
                double r=Right.GetValue();
                if(r==0)
                    return Left;
            }catch{}
            if(Left.Equals(Right))//try case f+f
                return 2*Right;
            return Left+Right;
        }
    }
    public override double GetValue()
    {
        return LeftExpresion.GetValue()+RigthExpresion.GetValue();
    }
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return LeftExpresion.Evaluate(variable,valor)+RigthExpresion.Evaluate(variable,valor);
    }
    
    public override Expresion Modify(Expresion newInternal){return LeftExpresion+newInternal;}
}

public class Diference:BinaryExpresion
{
    public Diference(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="-";
        Priotity=1;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //(f-g)'=f'-g'
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return LeftExpresion.DerivateInVariable(variable)-RigthExpresion.DerivateInVariable(variable);
    }
    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double l= Left.GetValue();
            if(l==0)//try case 0-f
                return -Right;
            return l+Right.GetValue();//try case a-b
        }
        catch
        {
            try
            {
                double r=Right.GetValue();
                if(r==0)//try case f-0
                    return Left;
            }catch{}
            
            if(Left.Equals(Right))//try case f-f
                return 0;
            return Left-Right;
        }
    }
    public override double GetValue()
    {
        return LeftExpresion.GetValue()-RigthExpresion.GetValue();
    }
    public override Expresion Evaluate(char variable, double valor)
    {
        return LeftExpresion.Evaluate(variable,valor)-RigthExpresion.Evaluate(variable,valor);
    }
    public override Expresion Modify(Expresion newInternal){return LeftExpresion-newInternal;}
}

public class Multiplication:BinaryExpresion
{
    public Multiplication(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="*";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //(fg)'=f'g+fg'
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        return LeftExpresion.DerivateInVariable(variable)*RigthExpresion+
        LeftExpresion*RigthExpresion.DerivateInVariable(variable);
    }
    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double l= Left.GetValue();
            if(l==0)//case 0*f
                return 0;
            if(l==1)//case 1*f
                return Right;
            return l*Right.GetValue();
        }
        catch
        {
            try
            {
                double r= Right.GetValue();
                if(r==0)//case f*0
                    return 0;
                if(r==1)//case f*1
                    return Left;
            }catch{}

            if(Left.Equals(Right))//case f*f
                return 2*Right;
            return Left*Right;
        }
    }
    public override double GetValue()
    {
        return LeftExpresion.GetValue()*RigthExpresion.GetValue();
    }
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return LeftExpresion.Evaluate(variable,valor)*RigthExpresion.Evaluate(variable,valor);
    }
    
    public override Expresion Modify(Expresion newInternal){return LeftExpresion*newInternal;}
}

public class Divition:BinaryExpresion
{
    public Divition(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="/";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //(f/g)'=(f'g-fg')/g^2
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        Expresion Left = LeftExpresion.DerivateInVariable(variable)*RigthExpresion;
        Expresion Rigth = LeftExpresion*RigthExpresion.DerivateInVariable(variable);
        return (Left-Rigth)/new Pow(RigthExpresion,2);
    }

    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double l= Left.GetValue();
            if(l==0)//case 0/f
                return 0;
            return l/Right.GetValue();
        }
        
        catch
        {
            try
            {
                double r= Right.GetValue();
                if(r==0)//case f/0
                    throw new DivideByZeroException();
                if(r==1)//case f/1
                    return Left;
                return Left/r;
            }catch{}
            
            if(Left.Equals(Right))//case f/f
                return 1;
            
            return Left/Right;
        }
    }
    public override double GetValue()
    {
        return LeftExpresion.GetValue()/RigthExpresion.GetValue();
    }
    
    public override Expresion Evaluate(char variable, double valor)
    {
        return LeftExpresion.Evaluate(variable,valor)/RigthExpresion.Evaluate(variable,valor);
    }
    public override Expresion Modify(Expresion newInternal){return LeftExpresion/newInternal;}
}
