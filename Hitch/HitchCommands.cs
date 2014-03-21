using System;

namespace Hitch
{
  public class HitchCommands
  {
    private const string GIT_AUTHOR_NAME = "GIT_AUTHOR_NAME";
    private const string GIT_AUTHOR_EMAIL = "GIT_AUTHOR_EMAIL";


    public void print_info()
    {
      string name = Environment.GetEnvironmentVariable(GIT_AUTHOR_NAME, EnvironmentVariableTarget.User);
      string email = Environment.GetEnvironmentVariable(GIT_AUTHOR_EMAIL, EnvironmentVariableTarget.User);
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
      Environment.SetEnvironmentVariable(GIT_AUTHOR_NAME, null, EnvironmentVariableTarget.User);
      Environment.SetEnvironmentVariable(GIT_AUTHOR_EMAIL, null, EnvironmentVariableTarget.User);
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

      string email = string.Format("{0}@{1}", current_pair, Environment.MachineName);
      Environment.SetEnvironmentVariable(GIT_AUTHOR_NAME, name, EnvironmentVariableTarget.User);
      Environment.SetEnvironmentVariable(GIT_AUTHOR_EMAIL, email, EnvironmentVariableTarget.User);
      Console.ForegroundColor = ConsoleColor.Green;
      Console.WriteLine("HITCHED");
      print_info();

    }
  }
}
