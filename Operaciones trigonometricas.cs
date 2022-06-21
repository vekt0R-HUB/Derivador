
namespace MathemathicExpresion;

public class Sen:UnaryExpresion
{
    public Sen(Expresion Internal)
    {
        InternalExpresion=Internal;
        ExpresionOperator="sen";
        Priotity=2;
    }
    public override Expresion DerivateInVariable(char variable='\0')
    {
        if(variable=='\0')
            variable=GetAVariable();
        if(variable=='\0')
            return new Constant(0);
        return new Multiplication(new Cosen(InternalExpresion),
        InternalExpresion.DerivateInVariable(variable));
    }
}

public class Cosen:UnaryExpresion
{
    public Cosen(Expresion Internal)
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
            return new Constant(0);
        return new Multiplication(new Sen(InternalExpresion),
        new Multiplication(InternalExpresion.DerivateInVariable(variable),new Constant(-1)));
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
            return new Constant(0);
        return new Multiplication(new Potence(new Secant(InternalExpresion),2),
        InternalExpresion.DerivateInVariable(variable));
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
            return new Constant(0);
        return new Multiplication(new Multiplication(new Secant(InternalExpresion),new Tangent(InternalExpresion)),
        InternalExpresion.DerivateInVariable(variable));
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
            return new Constant(0);
        Expresion Left=new Multiplication(new Potence(new Cosecant(InternalExpresion),2),new Constant(-1));
        return new Multiplication(Left,InternalExpresion.DerivateInVariable(variable));
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
            return new Constant(0);
        
        Expresion Left=new Multiplication(new Multiplication(new Cosecant(InternalExpresion),new Cotangent(InternalExpresion)),new Constant(-1));
        return new Multiplication(Left,InternalExpresion.DerivateInVariable(variable));
    }
}
