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
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);
        return new Sum(LeftExpresion.DerivateInVariable(variable),RigthExpresion.DerivateInVariable(variable));
    }
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
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);
        return new Diference(LeftExpresion.DerivateInVariable(variable),RigthExpresion.DerivateInVariable(variable));
    }
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
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);
        Expresion Left = new Multiplication(LeftExpresion.DerivateInVariable(variable),RigthExpresion);
        Expresion Rigth = new Multiplication(LeftExpresion,RigthExpresion.DerivateInVariable(variable));
        return new Sum(Left,Rigth);
    }
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
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);
        Expresion Left = new Multiplication(LeftExpresion.DerivateInVariable(variable),RigthExpresion);
        Expresion Rigth = new Multiplication(LeftExpresion,RigthExpresion.DerivateInVariable(variable));
        Expresion Dedominator = new Potence(RigthExpresion,new Constant(2));
        return new Divition(new Diference(Left,Rigth),Dedominator);
    }
}
