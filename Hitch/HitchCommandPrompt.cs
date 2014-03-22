using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hitch
{
  public class HitchCommandPrompt : HitchCommands, ICommands
  {
    private const string HITCH_STATUS_FILE = "hitch_status.cmd";

    public HitchCommandPrompt(SystemGitConfig config)
      : base(config)
    {
    }


    public new void unhitch()
    {
      base.unhitch();
      File.WriteAllText(Path.Combine(AppSettings<HitchSettings>.AssemblyDirectory, HITCH_STATUS_FILE), "prompt $P$G");
    }

    public new void author_command(string[] devs)
    {
      base.author_command(devs);
      string name = _settings.GetConfigVariable("name");
      string prompt = string.Format("$_HITCHED: {0}$_$P$G", name);
      File.WriteAllText(Path.Combine(AppSettings<HitchSettings>.AssemblyDirectory, HITCH_STATUS_FILE), "prompt " + prompt);
      Environment.SetEnvironmentVariable("prompt", prompt, EnvironmentVariableTarget.User);
    }

  }
}
