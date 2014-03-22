using System;

namespace Hitch
{
  class EnvironmentVariables : ISystemReader
  {

    private const string GIT_AUTHOR_NAME = "GIT_AUTHOR_NAME";
    private const string GIT_AUTHOR_EMAIL = "GIT_AUTHOR_EMAIL";
    private string configFile = "[user]\r\n\tname = {0}\r\n\temail = {1}\r\n";

    
    public string Read()
    {
      string name = Environment.GetEnvironmentVariable(GIT_AUTHOR_NAME);
      string email = Environment.GetEnvironmentVariable(GIT_AUTHOR_EMAIL);
      return string.Format(configFile, name, email);
    }

    public void Write(string fileText)
    {
      
    }
  }
}
