using System;
using System.IO;
using System.Reflection;
using System.Web.Script.Serialization;

namespace Hitch
{
  public class HitchSettings : AppSettings<HitchSettings>
  {
    public string defaultEmail;
    public string defaultName;
    public string group_domain;
  }

  public class AppSettings<T> where T : new()
  {
    private const string DEFAULT_FILENAME = "hitch.json";

    static public string AssemblyDirectory
    {
      get
      {
        string codeBase = Assembly.GetExecutingAssembly().CodeBase;
        UriBuilder uri = new UriBuilder(codeBase);
        string path = Uri.UnescapeDataString(uri.Path);
        return Path.GetDirectoryName(path);
      }
    }

    public void Save(string fileName = DEFAULT_FILENAME)
    {
      File.WriteAllText(Path.Combine(AssemblyDirectory, DEFAULT_FILENAME), (new JavaScriptSerializer()).Serialize(this));
    }

    public static void Save(T pSettings, string fileName = DEFAULT_FILENAME)
    {
      File.WriteAllText(Path.Combine(AssemblyDirectory, DEFAULT_FILENAME), (new JavaScriptSerializer()).Serialize(pSettings));
    }

    public static T Load(string fileName = DEFAULT_FILENAME)
    {
      T t = new T();
      if (File.Exists(Path.Combine(AssemblyDirectory, DEFAULT_FILENAME)))
      {
        t =
          (new JavaScriptSerializer()).Deserialize<T>(File.ReadAllText(Path.Combine(AssemblyDirectory, DEFAULT_FILENAME)));
      }
      else
      {
        throw new Exception("Setup not configured.  Run hitch --setup first.");
      }
      return t;
    }

  }
}