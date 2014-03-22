using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Hitch;

namespace HitchTest
{
  public class fakeCommand : ICommands
  {
    public bool print_infoCalled { get; set; }
    public void print_info()
    {
      print_infoCalled = true;
    }


    public bool unhitchCalled { get; set; }
    public void unhitch()
    {
      unhitchCalled = true;
    }

    public bool author_commandCalled { get; set; }
    public void author_command(string[] devs)
    {
      author_commandCalled = true;
    }

    public bool versionCalled { get; set; }
    public void version()
    {
      versionCalled = true;
    }

    public bool setupCalled { get; set; }
    public void setup()
    {
      setupCalled = true;
    }

    public HitchSettings Configuration { get; set; }

    public bool invalid_commandCalled { get; set; }
    public void invalid_command(string[] args)
    {
      invalid_commandCalled = true;
    }
  }
}
