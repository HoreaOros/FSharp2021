<Query Kind="Program" />

public delegate decimal MathOperation(decimal left, decimal right);

public static decimal Add(decimal left, decimal right)
{
    return left + right;
}

public static decimal Subtract(decimal left, decimal right)
{
    return left - right;
}

public static decimal Multiply(decimal left, decimal right)
{
    return left * right;
}

public static decimal Divide(decimal left, decimal right)
{
    return left / right;
}

private static MathOperation GetOperation(char oper)
{
    switch (oper)
    {
        case '+': return Add;
        case '-': return Subtract;
        case '*': return Multiply;
        case '/': return Divide;
    }
    
    throw new NotSupportedException("The supplied operator is not supported");
}

private static decimal Eval(string expr)
{
    var elements = expr.Split(new[] { ' ' }, 3);
    var l = Decimal.Parse(elements[0]);
    var r = Decimal.Parse(elements[1]);
    var op = elements[2][0];

    return GetOperation(op)(l, r);
}

void Main()
{
    Eval("1 3 +").Dump();
    Eval("10 5 -").Dump();
    Eval("2 3 *").Dump();
    Eval("14 2 /").Dump();
}