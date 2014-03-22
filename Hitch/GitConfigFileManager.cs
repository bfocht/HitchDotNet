using System.Text.RegularExpressions;

namespace Hitch
{
  public class GitConfigSettings
  {
    private const string PATTERN_CONFIG = "\t({0}) = (.*)\r+";

    private ISystemReader configInfo;

    public GitConfigSettings(ISystemReader reader)
    {
      this.configInfo = reader;
    }

    public string GetConfigVariable(string key)
    {
      Regex match = new Regex(string.Format(PATTERN_CONFIG, key));
      var value = match.Match(configInfo.Read()).Groups[2].Value;
      return value;
    }

    public void SetConfigVariable(string key, string value)
    {
      string pattern = string.Format(PATTERN_CONFIG, key);
      string input = configInfo.Read();
      string replace = string.Format("\t{0} = {1}\r", key, value);
      string newFile = Regex.Replace(input, pattern, replace);
      configInfo.Write(newFile);
    }
  }
}
