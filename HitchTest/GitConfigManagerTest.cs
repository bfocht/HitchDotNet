using Hitch;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace HitchTest
{
  [TestClass]
  public class GitConfigManagerTest
  {
   
    [TestMethod]
    public void TestReadConfigValue()
    {
      GitConfigSettings settings = new GitConfigSettings(new fakeGitconfig());
      Assert.AreEqual("aaaa bbbbbb",settings.GetConfigVariable("name"));
    }

    [TestMethod]
    public void TestWriteConfigValue()
    {
      var fake = new fakeGitconfig();
      GitConfigSettings settings = new GitConfigSettings(fake);
      settings.SetConfigVariable("name", "My New Name");
      Assert.AreEqual("[user]\r\n\tname = My New Name\r\n\temail = email@test.com\r\n[difftool]", fake.configFile);
    }
  }
}
