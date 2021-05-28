<Query Kind="Program" />

public interface IMathOperation
{
    decimal Compute(decimal left, decimal right);
}

public class AddOperation : IMathOperation
{
    decimal IMathOperation.Compute(decimal l, decimal r)
    {
        return l + r;
    }
}

public class SubtractOperation : IMathOperation
{
    decimal IMathOperation.Compute(decimal l, decimal r)
    {
        return l - r;
    }
}

public class MultiplyOperation : IMathOperation
{
    decimal IMathOperation.Compute(decimal l, decimal r)
    {
        return l * r;
    }
}

public class DivideOperation : IMathOperation
{
    decimal IMathOperation.Compute(decimal l, decimal r)
    {
        return l / r;
    }
}

private static IMathOperation GetOperation(char oper)
{
    switch (oper)
    {
        case '+': return new AddOperation();
        case '-': return new SubtractOperation();
        case '*': return new MultiplyOperation();
        case '/': return new DivideOperation();
    }
    
    throw new NotSupportedException("The supplied operator is not supported");
}

private static decimal Eval(string expr)
{
    var elements = expr.Split(new[] { ' ' }, 3);
    var l = Decimal.Parse(elements[0]);
    var r = Decimal.Parse(elements[1]);
    var op = elements[2][0];

    return GetOperation(op).Compute(l, r);
}

void Main()
{
    Eval("1 3 +").Dump();
    Eval("10 5 -").Dump();
    Eval("2 3 *").Dump();
    Eval("14 2 /").Dump();
}