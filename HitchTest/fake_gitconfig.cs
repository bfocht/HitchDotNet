using System.Runtime.CompilerServices;
using Hitch;

namespace HitchTest
{
  class fake_gitconfig :ISystemReader
  {

    public string configFile = "[user]\r\n\tname = aaaa bbbbbb\r\n\temail = email@test.com\r\n[difftool]";

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
