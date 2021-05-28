<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

public static class Disposable
{
    public static TResult Using<TDisposable, TResult>(
        Func<TDisposable> factory,
        Func<TDisposable, TResult> map)
        where TDisposable : IDisposable
    {
        using (var disposable = factory())
        {
            return map(disposable);
        }
    }
}

void Main()
{
    var time = 
        Disposable
            .Using(
                () => new System.Net.WebClient(),
                client => XDocument.Parse(client.DownloadString("http://time.gov/actualtime.cgi")))
            .Root
            .Attribute("time")
            .Value;
                
    var ms = Convert.ToInt64(time) / 1000;
    var currentTime = new DateTime(1970, 1, 1).AddMilliseconds(ms).ToLocalTime();

    currentTime.Dump();
}
