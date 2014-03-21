using System;

namespace Hitch
{
  class Program
  {
    static void Main(string[] args)
    {
      try
      {
        HitchCommands commands = new HitchCommands();
        if (args.Length == 0)
        {
          commands.print_info();
          return;
        }
        if (args[0] == "-u")
        {
          commands.unhitch();
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
