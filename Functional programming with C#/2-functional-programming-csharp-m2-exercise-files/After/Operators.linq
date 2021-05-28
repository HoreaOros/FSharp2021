<Query Kind="Program" />

public sealed class MySingleton
{
    private static MySingleton _instance;

    private MySingleton()
    {
    }

    public static MySingleton Instance => _instance ?? (_instance = new MySingleton());

    // Other stuff here

    public override string ToString() => $"Type Name: {GetType().Name.Split('+')[0]}";
}

void Main()
{
    var instance1 = MySingleton.Instance;
    var instance2 = MySingleton.Instance;
    Object.ReferenceEquals(instance1, instance2).Dump("Same Object?");
    
    instance1.ToString().Dump("Instance 1");
}
