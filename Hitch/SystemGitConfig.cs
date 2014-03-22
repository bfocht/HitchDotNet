using System;
using System.IO;
using System.Text;

namespace Hitch
{
  public class SystemGitConfig : ISystemReader
  {

    private const string HOME = "HOME";
    private const string HOMEDRIVE = "HOMEDRIVE";
    private const string HOMEPATH = "HOMEPATH";
    private const string GITCONFIG = ".gitconfig";

    public string Read()
    {
      string configFile = Path.Combine(ConfigPath(), GITCONFIG);
      return File.ReadAllText(configFile);
    }

    public void Write(string fileText)
    {
      string configFile = Path.Combine(ConfigPath(), GITCONFIG);
      File.WriteAllText(configFile,fileText,Encoding.UTF8);
    }

    private string ConfigPath()
    {
      string home = Environment.GetEnvironmentVariable(HOME);
      if (!string.IsNullOrEmpty(home)) return home;
      return string.Format("{0}{1}", Environment.GetEnvironmentVariable(HOMEDRIVE), Environment.GetEnvironmentVariable(HOMEPATH));
    }
  }
}
