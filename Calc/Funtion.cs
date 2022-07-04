using MathemathicExpresion;
namespace MathemathicFuntion;
public class Function{
    private Expresion[] Components;
    private char[] variables;
    public Function(Expresion[] Components)
    {
        this.Components=Components;
        List<char> variables=new List<char>();
        for(int i=0;i<Components.Length;i++)
        {
            for(int j=0;j<variables.Count;j++)
                Components[i]=Components[i].Evaluate(variables[j],0);
            char newvar=Components[i].GetAVariable();
            while(newvar=='\0')
            {
                variables.Add(newvar);
                Components[i]=Components[i].Evaluate(newvar,0);
                newvar=Components[i].GetAVariable();
            }
        }
        this.variables=variables.ToArray();
    }

    public override string ToString()
    {
        string Retorno="( ";
        for(int i=0;i<Components.Length;i++)
        {
            Retorno+=Components[i]+" , ";
        }
        return Retorno.Remove(Retorno.Length-2)+")";
    }

    public Expresion[,] GradientVector()
    {
        Expresion[,] Gradient=new Expresion[Components.Length,variables.Length];
        for(int i=0;i<Components.Length;i++)
            for(int j=0;j<variables.Length;j++)
                Gradient[i,j]=Components[i].DerivateInVariable(variables[j]);
        return Gradient;
    }
}