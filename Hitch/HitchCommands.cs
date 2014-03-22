using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Hitch
{
  public class HitchCommands : ICommands
  {
    protected GitConfigSettings _settings;
    private HitchSettings configuration;

    public HitchCommands(ISystemReader config)
    {
      _settings = new GitConfigSettings(config);

    }

    public HitchSettings Configuration
    {
      get { return configuration ?? (configuration = HitchSettings.Load()); }
      set { configuration = value; }
    }

    public void print_info()
    {
      
      string email = _settings.GetConfigVariable("email");
      string name = _settings.GetConfigVariable("name");

      if (string.IsNullOrEmpty(name))
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("HITCH Not Set!");
      }
      else
      {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("{0} <{1}>", name, email);
      }
    }

    public void unhitch()
    {
      _settings.SetConfigVariable("name", Configuration.defaultName);
      _settings.SetConfigVariable("email",Configuration.defaultEmail);
      Environment.SetEnvironmentVariable("prompt", null, EnvironmentVariableTarget.User);
      Console.ForegroundColor = ConsoleColor.Yellow;
      Console.WriteLine("UNHITCHED");
    }

    public void author_command(string[] devs)
    {
      string name;
      string current_pair;
      if (devs.Length > 1)
      {
        name = String.Join(" and ", devs);
        current_pair = string.Join("+", devs);
      }
      else
      {
        name = devs[0];
        current_pair = devs[0];
      }

      string email = string.Format("{0}@{1}", current_pair, Configuration.group_domain);

      _settings.SetConfigVariable("name", name);
      _settings.SetConfigVariable("email", email);

     
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("HITCHED");
      print_info();
    }

    public void version()
    {
      Assembly assembly = Assembly.GetExecutingAssembly();
      FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
      Console.WriteLine(fvi.ProductVersion);
    }

    public void setup()
    {
      try
      {
        Configuration = AppSettings<HitchSettings>.Load();
      }
      catch (Exception)
      {
        Configuration = new HitchSettings();
        Configuration.defaultName = _settings.GetConfigVariable("name");
        Configuration.defaultEmail = _settings.GetConfigVariable("email");
        Configuration.group_domain = "";
      }
      Console.WriteLine("What default NAME do you want to use for UNHITCH [{0}]?", Configuration.defaultName);
      string line = Console.ReadLine();
      if (!string.IsNullOrEmpty(line)) Configuration.defaultName = line;
      Console.WriteLine("What default EMAIL do you want to use for UNHITCH [{0}]?", Configuration.defaultEmail);
      line = Console.ReadLine();
      if (!string.IsNullOrEmpty(line)) Configuration.defaultEmail = line;
      Console.WriteLine("What GROUP_DOMAIN do you want to use for HITCH? [{0}]", Configuration.group_domain);
      line = Console.ReadLine();
      if (!string.IsNullOrEmpty(line)) Configuration.group_domain = line;
      Configuration.Save();
    }

    public void invalid_command(string[] args)
    {
      throw new NotSupportedException(string.Format("Command \"{0}\" not supported.", args));
    }
  }
}
