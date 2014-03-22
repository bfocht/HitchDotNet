namespace Hitch
{
  public interface ISystemReader
  {
    string Read();
    void Write(string fileText);
  }
}