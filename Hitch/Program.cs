using System;

namespace Hitch
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        
        HitchCommands commands = new HitchCommands(new SystemGitConfig());
        if (args.Length == 0)
        {
          commands.print_info();
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
        if (args[0] == "-s" || args[0] == "--setup")
        {
          commands.setup();
          return;
        }
        if (args[0] == "judd")
        {
          Judd.quote();
          return;
        }

        commands.author_command(args);
        
      }
      catch (Exception ex)
      {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("ERROR : {0}",ex.Message);
        
      }
      finally 
      {
        Console.ResetColor();
      }
      
    }

  }
}
