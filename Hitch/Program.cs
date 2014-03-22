using System;

namespace Hitch
{
  public class Program
  {
    public static ICommands commands;

    public static void Main(string[] args)
    {
      SystemGitConfig config = new SystemGitConfig();
      try
      {
        //allow for dependency injection
        if (commands == null) commands = new HitchCommandPrompt(config);

        if (args.Length == 0)
        {
          commands.print_info();
          return;
        }

        if (args.Length > 0 && (args[0] == "-s" || args[0] == "--setup"))
        {
          commands.setup();
          return;
        }

        if (args[0] == "-u" || args[0] == "--unhitch")
        {
          commands.unhitch();
          return;
        }
        if (args[0] == "-v" || args[0] == "--version")
        {
          commands.version();
          return;
        }

        if (args[0] == "judd")
        {
          Judd.quote();
          return;
        }

        if (args[0].StartsWith("-"))
        {
          commands.invalid_command(args);
          return;
        }
        
        commands.author_command(args);

      }
      catch (Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine(ex.Message);

      }
      finally
      {
        Console.ResetColor();
      }

    }
  }
}
