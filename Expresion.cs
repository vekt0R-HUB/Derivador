namespace MathemathicExpresion;

public abstract class Expresion
//A mathematic expresion
{
    public abstract Expresion DerivateInVariable(char variable='\0');
    //returns the derivate of the experesion acording to the variable from the entry
    //if the variable is not specificated, dreivate in the first variable found 
    public abstract char GetAVariable();
    //obtains the first variable in the expresion
    public int Priotity{get;protected set;}

    static public Expresion operator +(Expresion a, Expresion b)
    {
        return new Sum(a,b);
    }
    static public Expresion operator -(Expresion a, Expresion b)
    {
        return new Diference(a,b);
    }
    static public Expresion operator -(Expresion a)
    {
        return -1*a;
    }
    static public Expresion operator *(Expresion a, Expresion b)
    {
        return new Multiplication(a,b);
    }
    static public Expresion operator /(Expresion a, Expresion b)
    {
        return new Divition(a,b);
    }
    public static implicit operator Expresion(double a)
    {
        return new Constant(a);
    }
    public abstract double GetValue();
    public abstract Expresion Symplify();

    public abstract Expresion Evaluate(char variable, double valor);
}

public abstract class UnaryExpresion:Expresion
{
    protected string ExpresionOperator="";
    protected Expresion InternalExpresion=null!;

    public override char GetAVariable()
    {
        return InternalExpresion.GetAVariable();
    }

    public override string ToString()
    {
        return ExpresionOperator+"("+InternalExpresion.ToString()+")";
    }
}

public abstract class BinaryExpresion:Expresion
{
    protected string ExpresionOperator="";
    protected Expresion LeftExpresion=null!;
    protected Expresion RigthExpresion=null!;

    public override string ToString()
    {
        string ToReturn;
        if(LeftExpresion.Priotity<this.Priotity && LeftExpresion.Priotity!=0)
            ToReturn="("+LeftExpresion+")"+ExpresionOperator;
        else
            ToReturn=LeftExpresion+ExpresionOperator;
        
        if(RigthExpresion.Priotity<this.Priotity && RigthExpresion.Priotity!=0)
            return ToReturn+"("+RigthExpresion+")";
        else
            return ToReturn+RigthExpresion;   
    }
    
    public override char GetAVariable()
    {
        char variable=LeftExpresion.GetAVariable();
        if(variable=='\0')
            return RigthExpresion.GetAVariable();
        return variable;
    }
}