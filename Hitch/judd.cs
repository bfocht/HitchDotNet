using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Script.Serialization;


namespace Hitch
{
  public class Judd
  {
    public static void quote()
    {
      var response = new WebClient().DownloadString("http://www.juddisms.com/data/juddisms.json");
      Juddisms json = new JavaScriptSerializer().Deserialize<Juddisms>(response);
      Console.ForegroundColor = ConsoleColor.Blue;

      int random = new Random().Next(0, json.juddisms.Count - 1);
      Console.WriteLine(json.juddisms[random].quote);
    }

    internal class Juddisms
    {
      public List<Quote> juddisms { get; set; }
    }

    internal class Quote
    {
      public string quote { get; set; }
    }

  }

}
