namespace MathemathicExpresion;

public class Potence:BinaryExpresion
{
    public Potence(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="^";
        Priotity=2;
    }
    public Potence(Expresion Exponent)
    {
        LeftExpresion=new Constant(System.Math.E);
        RigthExpresion=Exponent;
        ExpresionOperator="e^";
        Priotity=2;
    }
    public Potence(Expresion Base,int Exponent)
    {
        LeftExpresion=Base;
        RigthExpresion=new Constant(Exponent);
        ExpresionOperator="^"+Exponent;
        Priotity=3;
    }

    public override string ToString()
    {
        if(ExpresionOperator=="e^")
            return ExpresionOperator+"("+RigthExpresion+")";
        if(ExpresionOperator.Length>1)
            return "("+LeftExpresion+")"+ExpresionOperator;
        return base.ToString();
    }

    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);

        if(ExpresionOperator=="e^")
            return new Multiplication(RigthExpresion.DerivateInVariable(variable),new Potence(RigthExpresion));
        if(ExpresionOperator.Length>1)
        {
            int Exponent=int.Parse(ExpresionOperator.Remove(0,1));
            Expresion left = new Multiplication(new Constant(Exponent),new Potence(LeftExpresion,Exponent-1));
            return (new Multiplication(left, LeftExpresion.DerivateInVariable(variable)));
        }
        
        Expresion Left = new Multiplication(RigthExpresion,new Logaritm(LeftExpresion));
        return new Multiplication(Left.DerivateInVariable(variable),new Potence(LeftExpresion,RigthExpresion));
    }
}

public class Logaritm:BinaryExpresion
{
    public Logaritm(Expresion Left, Expresion Rigth)
    {
        LeftExpresion=Left;
        RigthExpresion=Rigth;
        ExpresionOperator="log";
        if(Left==new Constant(System.Math.E))
        ExpresionOperator="ln";
        Priotity=3;
    }
    public Logaritm(Expresion Rigth)
    {
        LeftExpresion=new Constant(System.Math.E);
        RigthExpresion=Rigth;
        ExpresionOperator="ln";
        Priotity=2;
    }
    public Logaritm(Expresion Rigth,int Base)
    {
        LeftExpresion=new Constant(Base);
        RigthExpresion=Rigth;
        ExpresionOperator="log["+Base+"]";
        Priotity=2;
    }
    
    public override string ToString()
    {
        if(ExpresionOperator=="ln")
            return "ln"+"("+RigthExpresion+")";
        if(ExpresionOperator.Length>3)
            return ExpresionOperator+"("+RigthExpresion+")";
            return ExpresionOperator+"["+LeftExpresion+"]"+"("+RigthExpresion+")";
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);
        
        if(ExpresionOperator=="ln")
        {
            Expresion Left=RigthExpresion.DerivateInVariable(variable);
            return new Divition(Left,RigthExpresion);
        }
        if(ExpresionOperator.Length>3)
        {
            int Base = int.Parse(ExpresionOperator.Remove(0,4).Remove(0,1));
            Expresion Left=new Divition(new Constant(1),new Logaritm(new Constant(Base)));
            Expresion Rigth = new Divition(RigthExpresion.DerivateInVariable(variable),RigthExpresion);
            return new Multiplication(Left,Rigth);
        }
        
        Expresion divition = new Divition(new Logaritm(RigthExpresion),new Logaritm(LeftExpresion));
        return divition.DerivateInVariable(variable);
    }
}

