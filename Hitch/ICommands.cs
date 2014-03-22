using System.Runtime.InteropServices.ComTypes;

namespace Hitch
{
  public interface ICommands
  {
    void print_info();
    void unhitch();
    void author_command(string[] args);
    void version();
    void setup();
    void invalid_command(string[] args);
    HitchSettings Configuration { get; set; }
  }
}