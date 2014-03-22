using System;
using System.Linq.Expressions;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Hitch;

namespace HitchTest
{
  [TestClass]
  public class HitchCommandsTest
  {

    [TestMethod]
    public void Test_print_info()
    {
      ISystemReader fake = new fakeGitconfig("[user]\r\n\tname = aaaa bbbbbb\r\n\temail = email@test.com\r\n[difftool]");

      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        HitchCommands commands = new HitchCommands(fake);
        commands.print_info();
        Assert.AreEqual("aaaa bbbbbb <email@test.com>\r\n", cr.ToString());
      }
    }


    [TestMethod]
    public void Test_print_infoNotSetup()
    {
      ISystemReader fake = new fakeGitconfig("[user]\r\n\tname = \r\n\temail = \r\n[difftool]");
      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        HitchCommands commands = new HitchCommands(fake);
        commands.print_info();
        Assert.AreEqual("HITCH Not Set!\r\n", cr.ToString());
      }
    }

    [TestMethod]
    public void TestUnhitch()
    {
      ISystemReader fake = new fakeGitconfig("[user]\r\n\tname = Developer\r\n\temail = developer@test.com\r\n[difftool]");
      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        ICommands commands = new HitchCommands(fake);
        commands.Configuration = new HitchSettings();
        commands.unhitch();
        Assert.AreEqual("UNHITCHED\r\n", cr.ToString());
      }
    }

    [TestMethod]
    public void TestAuthorCommand()
    {
      ISystemReader fake = new fakeGitconfig("[user]\r\n\tname = Developer\r\n\temail = developer@test.com\r\n[difftool]");
      string[] args =  {"dev1", "dev2"};
      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        HitchCommands commands = new HitchCommands(fake);
        commands.Configuration = new HitchSettings();
        commands.author_command(args);
        Assert.AreEqual("HITCHED\r\ndev1 and dev2 <dev1+dev2@>\r\n", cr.ToString());
      } 
    }

    [TestMethod]
    public void TestVersion()
    {
      ISystemReader fake = new fakeGitconfig("[user]\r\n\tname = Developer\r\n\temail = developer@test.com\r\n[difftool]");
      
      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        HitchCommands commands = new HitchCommands(fake);
        commands.Configuration = new HitchSettings();
        commands.version();
        Assert.IsTrue(cr.ToString().StartsWith("1.1."));
      }
    }

    [TestMethod()]
    [ExpectedException(typeof (System.NotSupportedException))]
    public void TestInvalidCommend()
    {
      ISystemReader fake = new fakeGitconfig("[user]\r\n\tname = Developer\r\n\temail = developer@test.com\r\n[difftool]");
      using (ConsoleRedirector cr = new ConsoleRedirector())
      {
        HitchCommands commands = new HitchCommands(fake);
        commands.Configuration = new HitchSettings();
        commands.invalid_command(new string[] {"-xyz"});
      }
    }


  }
}
