
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
            return new Constant(0);
        return new Divition(InternalExpresion.DerivateInVariable(variable),
        new Potence(new Diference(new Constant(1),new Potence(InternalExpresion,2)),2));
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
            return new Constant(0);
        return new Multiplication(new Constant(-1),new Divition(InternalExpresion.DerivateInVariable(variable),
        new Potence(new Diference(new Constant(1),new Potence(InternalExpresion,2)),2)));
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
            return new Constant(0);
        return new Divition(InternalExpresion.DerivateInVariable(variable),
        new Sum(new Constant(1),new Potence(InternalExpresion,2)));
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
            return new Constant(0);
        return new Divition(InternalExpresion.DerivateInVariable(variable), new Multiplication(InternalExpresion,
        new Potence(new Diference(new Constant(1),new Potence(InternalExpresion,2)),2)));
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
            return new Constant(0);
        return new Divition(new Multiplication(new Constant(-1),InternalExpresion.DerivateInVariable(variable)),
        new Sum(new Constant(1),new Potence(InternalExpresion,2)));
    }
}

public class Arcosecant:UnaryExpresion
{
    public Arcosecant(Expresion Internal)
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
        
        return new Divition(new Multiplication(new Constant(-1),InternalExpresion.DerivateInVariable(variable)),
        new Potence(new Diference(new Constant(1),new Potence(InternalExpresion,2)),2));
    
    }
}
