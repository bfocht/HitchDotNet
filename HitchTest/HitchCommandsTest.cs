using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hitch;
using System.IO;

namespace HitchTest
{
  [TestClass]
  public class HitchCommandsTest
  {
    [TestMethod]
    public void Test_print_info()
    {
      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        Assert.IsFalse(cr.ToString().Contains("aaa"));
        HitchCommands commands = new HitchCommands(new fake_gitconfig());
        commands.print_info();
        Assert.AreEqual("aaaa bbbbbb <email@test.com>\r\n", cr.ToString());
      }
    }

    internal class ConsoleRedirector : IDisposable
    {
      private StringWriter _consoleOutput = new StringWriter();
      private TextWriter _originalConsoleOutput;
      public ConsoleRedirector()
      {
        this._originalConsoleOutput = Console.Out;
        Console.SetOut(_consoleOutput);
      }
      public void Dispose()
      {
        Console.SetOut(_originalConsoleOutput);
        Console.Write(this.ToString());
        this._consoleOutput.Dispose();
      }
      public override string ToString()
      {
        return this._consoleOutput.ToString();
      }
    }
  }
}
