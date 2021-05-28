<Query Kind="Program" />

public sealed class MySingleton
{
    private static MySingleton _instance;

    private MySingleton()
    {
    }

    public static MySingleton Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = new MySingleton();
            }
            
            return _instance;
        }
    }
    
    // Other stuff here
}


void Main()
{
    MySingleton.Instance.ToString().Dump();
}
