using System.Runtime.CompilerServices;
using Hitch;

namespace HitchTest
{
  class fakeGitconfig :ISystemReader
  {

    public string configFile;

    public fakeGitconfig()
    {
      configFile = "[user]\r\n\tname = aaaa bbbbbb\r\n\temail = email@test.com\r\n[difftool]";
    }
    
    public fakeGitconfig(string config)
    {
      this.configFile = config;
    }
    
    public string Read()
    {
      return configFile;
    }

    public void Write(string fileText)
    {
      configFile = fileText;
    }
  }
}
