namespace MathemathicExpresion;

public class Pow:BinaryExpresion
//includes the forms f^a, a^f, f^g
{
    public Pow(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="^";
        Priotity=2;
    }
    public Pow(Expresion Exponent)
    {
        LeftExpresion=System.Math.E;
        RigthExpresion=Exponent;
        ExpresionOperator="e^";
        Priotity=2;
    }
    public Pow(Expresion Base, double Exponent)
    {
        if(Exponent==0 && !base.Equals(0))
        {
            LeftExpresion=1;
            RigthExpresion=1;
            ExpresionOperator="^";
            Priotity=3;

        }
        LeftExpresion=Base;
        RigthExpresion=Exponent;
        ExpresionOperator="^"+Exponent;
        Priotity=3;
    }

    public override string ToString()
    {
        if(ExpresionOperator=="e^")
            return ExpresionOperator+"("+(RigthExpresion==null?"???":RigthExpresion)+")";
        if(ExpresionOperator.Length>1)
            return "("+LeftExpresion+")"+ExpresionOperator;
        return base.ToString();
    }

    public override Expresion DerivateInVariable(char variable='\0')
    //Case 1: (f^a)'=af'f^(a-1)
    //Case 2: (a^f)'=f'*a^f*lna
    //Case 3: (f^g)'=(f'g/f+g'lnf)*f^g
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;

        if(ExpresionOperator=="e^")
            return RigthExpresion.DerivateInVariable(variable)*new Pow(RigthExpresion);
        if(ExpresionOperator.Length>1)
        //Case 2
        {
            double Exponent=double.Parse(ExpresionOperator.Remove(0,1));
            Expresion left = Exponent*new Pow(LeftExpresion,(Exponent-1));
            return left*LeftExpresion.DerivateInVariable(variable);
        }
        
        Expresion Left = RigthExpresion*new Logarithm(LeftExpresion);
        return Left.DerivateInVariable(variable)*new Pow(LeftExpresion,RigthExpresion);
    }

    
    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double l=Left.GetValue();
            if(l==0)//case 0^f
                return 0;
            if(l==1)//case 1^f
                return 1;
            return Math.Pow(l,Right.GetValue());
        }
        
        catch
        {
            try
            {
                double r=Right.GetValue();
                if(r==0)//case f^0
                    return 1;
                if(r==1)//case f^1
                    return Left;
                return new Pow(Left,r);
            }catch{}
            if(ExpresionOperator=="e^")
                return new Pow(Right);
            return new Pow(Left,Right);
        }
    }
    public override double GetValue()
    {
        return Math.Pow(LeftExpresion.GetValue(),RigthExpresion.GetValue());
    }
    
    public override Expresion Evaluate(char variable, double valor)
    {
        if(ExpresionOperator=="e^")
            return new Pow(RigthExpresion.Evaluate(variable,valor));
        return new Pow(LeftExpresion.Evaluate(variable,valor),RigthExpresion.Evaluate(variable,valor));
    }
    public override Expresion Modify(Expresion newInternal){return new Pow(LeftExpresion,newInternal);}
}

public class Logarithm:BinaryExpresion
{
    public Logarithm(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="log";
        if(Left.Equals(System.Math.E))
            ExpresionOperator="ln";
        Priotity=3;
    }
    public Logarithm(Expresion Rigth)
    {
        LeftExpresion=System.Math.E;
        RigthExpresion=Rigth;
        ExpresionOperator="ln";
        Priotity=2;
    }
    public Logarithm(Expresion Rigth,double Base)
    {
        LeftExpresion=new Constant(Base);
        RigthExpresion=Rigth;
        ExpresionOperator="log["+Base+"]";
        Priotity=2;
    }
    
    public override string ToString()
    {
        if(ExpresionOperator=="ln")
            return "ln"+"("+(RigthExpresion==null?"???":RigthExpresion)+")";
        if(ExpresionOperator.Length>3)
            return ExpresionOperator+"("+(RigthExpresion==null?"???":RigthExpresion)+")";
            return ExpresionOperator+"["+LeftExpresion+"]"+"("+(RigthExpresion==null?"???":RigthExpresion)+")";
    }
    public override Expresion DerivateInVariable(char variable='\0')
    //Case 1: Ln'(f)=f'/f
    //Case 2: Log'[a](f)=f'/(f*ln(a))
    //Case 3: Log'[f](g)=(ln(f)/ln(g))'=(f'ln(g)/f + ln(f)*g'/g)/ln^2(g)
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return 0;
        
        if(ExpresionOperator=="ln")
            return RigthExpresion.DerivateInVariable(variable)/RigthExpresion;
        
        if(ExpresionOperator.Length>3)
        {
            double Base = double.Parse(ExpresionOperator.Remove(0,4).Remove(ExpresionOperator.Length-1));
            return RigthExpresion.DerivateInVariable(variable)/(RigthExpresion*new Logarithm(Base));
        }
        
        Expresion divition = new Logarithm(RigthExpresion)/new Logarithm(LeftExpresion);
        return divition.DerivateInVariable(variable);
    }

    public override Expresion Symplify()
    {
        Expresion Left = LeftExpresion.Symplify();
        Expresion Right = RigthExpresion.Symplify();
        try
        {
            double r=Right.GetValue();
            if(r==1)//case log[f](1)
                return 0;
            return Math.Log(r,Left.GetValue());
        }
        
        catch
        {
            if(Left.Equals(Right))//case log[f](f)
                return 1;
            return new Logarithm(Left,Right);
        }
    }
    public override double GetValue()
    {
        return Math.Log(RigthExpresion.GetValue(),LeftExpresion.GetValue());
    }
    
    public override Expresion Evaluate(char variable, double valor)
    {
        if(ExpresionOperator=="ln")
            return new Logarithm(RigthExpresion.Evaluate(variable,valor));
        return new Logarithm(LeftExpresion.Evaluate(variable,valor),RigthExpresion.Evaluate(variable,valor));
    }
    
    public override Expresion Modify(Expresion newInternal){return new Logarithm(LeftExpresion,newInternal);}
}

