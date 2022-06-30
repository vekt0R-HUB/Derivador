namespace MathemathicExpresion;

public class Constant : Expresion
{
    double value;
    public override string ToString() { return this.value.ToString(); }
    public Constant(double value)
    {
        this.value = value;
        Priotity = 0;
    }
    public override Expresion DerivateInVariable(char variable = '\0') { return new Constant(0); }
    public override char GetAVariable() { return '\0'; }
    public override Expresion Symplify() => value;
    public override double GetValue() => value;
    public override Expresion Evaluate(char variable, double valor) => value;
}

public class Variable : Expresion
{
    private char variable;
    public override string ToString() => this.variable.ToString();
    public Variable(char variable)
    {
        Priotity = 0;
        this.variable = variable;
    }
    //returns 1 if it is the variable is the derivated one, and 0 if it isn't
    public override Expresion DerivateInVariable(char variable = '\0') => this.variable == variable || variable == '\0' ? new Constant(1) : new Constant(0);
    public override char GetAVariable() => this.variable;
    public override Expresion Symplify() => new Variable(variable);
    public override double GetValue() => throw new Exception("No tiene valor");
    public override Expresion Evaluate(char variable, double valor) => this.variable == variable ? valor : new Variable(this.variable);
}