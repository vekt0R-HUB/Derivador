namespace MathemathicExpresion;

public class Constant:Expresion
//A number, nothing more, nothing less
{
    double value;
    public override string ToString()
    {
        if(value==Math.PI) return "pi";
        
        if(value==Math.E) return "e";

        return this.value.ToString();
    }
    public Constant(double value)
    {
        this.value=value;
        Priotity=0;
    }
    public override Expresion DerivateInVariable(char variable='\0'){return 0;}//a'=0
    public override char GetAVariable(){return '\0';}
    public override Expresion Symplify(){return value;}
    public override double GetValue(){return value;}
    public override Expresion Evaluate(char variable, double valor){return value;}
}

public class Variable:Expresion
//A variable. The reason for hold a char and not a string 
//is because it was making problems whith the toString() method
{
    private char variable;
    public override string ToString()
    {
        return this.variable.ToString();
    }
    public Variable(char variable)
    {
        Priotity=0;
        this.variable=variable;
    }
    public override Expresion DerivateInVariable(char variable='\0')//dx/dx=1, dx/dy=0
    //returns 1 if it is the variable is the derivated one, and 0 if it isn't
    {
        if(this.variable==variable || variable=='\0')
            return 1;
        else return 0;
    }
    public override char GetAVariable()
    {
        return this.variable;
    }
    public override Expresion Symplify()
    {
        return new Variable(variable);
    }
    public override double GetValue()
    {
        throw new Exception("No tiene valor");
    }
    
    public override Expresion Evaluate(char variable, double valor)
    {
        if(this.variable==variable)
            return valor;
        return new Variable(this.variable);
    }
}