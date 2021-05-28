<Query Kind="Program">
  <Namespace>System.Net</Namespace>
</Query>

void Main()
{
    XDocument timeDoc;

    using (var client = new System.Net.WebClient())
    {
        timeDoc = XDocument.Parse(client.DownloadString("http://time.gov/actualtime.cgi"));
    }

    var ms = Convert.ToInt64(timeDoc.Root.Attribute("time").Value) / 1000;
    var currentTime = new DateTime(1970, 1, 1).AddMilliseconds(ms).ToLocalTime();

    currentTime.Dump();
}
