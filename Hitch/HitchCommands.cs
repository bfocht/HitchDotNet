using System;
using System.Diagnostics;
using System.IO;
using System.Reflection;

namespace Hitch
{
  public class HitchCommands
  {

    private const string HITCH_STATUS_FILE = "hitch_status.cmd";

    private GitConfigSettings _settings;
    private HitchSettings configuration;

    public HitchCommands(ISystemReader config)
    {
      _settings = new GitConfigSettings(config);
      configuration = HitchSettings.Load();
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

        Process cmd = new Process();
      }
    }

    public void unhitch()
    {
      _settings.SetConfigVariable("name", configuration.defaultName);
      _settings.SetConfigVariable("email",configuration.defaultEmail);
      Environment.SetEnvironmentVariable("prompt", null, EnvironmentVariableTarget.User);
      File.WriteAllText(Path.Combine(AppSettings<HitchSettings>.AssemblyDirectory, HITCH_STATUS_FILE), "prompt $P$G");
      
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

      string email = string.Format("{0}@{1}", current_pair, configuration.group_domain);

      _settings.SetConfigVariable("name", name);
      _settings.SetConfigVariable("email", email);

      string prompt = string.Format("$_HITCHED: {0}$_$P$G", name);
      File.WriteAllText(Path.Combine(AppSettings<HitchSettings>.AssemblyDirectory,HITCH_STATUS_FILE), "prompt " + prompt);
      Environment.SetEnvironmentVariable("prompt", prompt, EnvironmentVariableTarget.User);

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

    internal void setup()
    {
      
      Console.WriteLine("What default NAME do you want to use for UNHITCH?");
      configuration.defaultName = Console.ReadLine();
      Console.WriteLine("What default EMAIL do you want to use for UNHITCH?");
      configuration.defaultEmail = Console.ReadLine();
      Console.WriteLine("What GROUP_DOMAIN do you want to use for HITCH?");
      configuration.group_domain = Console.ReadLine();
      configuration.Save();
    }
  }
}
