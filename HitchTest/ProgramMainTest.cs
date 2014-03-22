using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hitch;

namespace HitchTest
{
  [TestClass]
  public class ProgramMainTest
  {
    [TestMethod]
    public void UnhitchCommandParam()
    {
      fakeCommand command = new fakeCommand();
      Program.commands = command;
      Program.Main(new string[] {"-u"});
      Assert.IsTrue(command.unhitchCalled);
      Assert.IsFalse(command.author_commandCalled);
      Assert.IsFalse(command.invalid_commandCalled);
      Assert.IsFalse(command.setupCalled);
      Assert.IsFalse(command.versionCalled);
      Assert.IsFalse(command.print_infoCalled);

    }


    [TestMethod]
    public void EmptyCommandParam()
    {
      fakeCommand command = new fakeCommand();
      Program.commands = command;
      Program.Main(new string[] { });
      Assert.IsTrue(command.print_infoCalled);
      Assert.IsFalse(command.unhitchCalled);
      Assert.IsFalse(command.author_commandCalled);
      Assert.IsFalse(command.invalid_commandCalled);
      Assert.IsFalse(command.setupCalled);
      Assert.IsFalse(command.versionCalled);
    }


    [TestMethod]
    public void HitchCommandParam()
    {
      fakeCommand command = new fakeCommand();
      Program.commands = command;
      Program.Main(new string[] { "dev dev2" });
      Assert.IsTrue(command.author_commandCalled);
      Assert.IsFalse(command.unhitchCalled);
      Assert.IsFalse(command.invalid_commandCalled);
      Assert.IsFalse(command.setupCalled);
      Assert.IsFalse(command.versionCalled);
      Assert.IsFalse(command.print_infoCalled);
    }

    [TestMethod]
    public void SetupCommandParam()
    {
      fakeCommand command = new fakeCommand();
      Program.commands = command;
      Program.Main(new string[] { "-s" });
      Assert.IsTrue(command.setupCalled);
      Assert.IsFalse(command.unhitchCalled);
      Assert.IsFalse(command.author_commandCalled);
      Assert.IsFalse(command.invalid_commandCalled);
      Assert.IsFalse(command.versionCalled);
      Assert.IsFalse(command.print_infoCalled);
    }

    [TestMethod]
    public void InvalidCommandParam()
    {
      fakeCommand command = new fakeCommand();
      Program.commands = command;
      Program.Main(new string[] { "-xyz" });
      Assert.IsTrue(command.invalid_commandCalled);
      Assert.IsFalse(command.unhitchCalled);
      Assert.IsFalse(command.author_commandCalled);
      Assert.IsFalse(command.setupCalled);
      Assert.IsFalse(command.versionCalled);
      Assert.IsFalse(command.print_infoCalled);
    }

  }
}
