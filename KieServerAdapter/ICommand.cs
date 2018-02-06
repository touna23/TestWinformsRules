namespace KieServerAdapter
{
    public interface ICommand
    {
        KieCommandTypeEnum CommandType { get; }
    }

    public enum KieCommandTypeEnum : byte
    {
        GetObjects = 30,
        SetGlobal = 20,
        Insert = 10,
        FireAllRules = 2,
        GetGlobal = 1,
        StartProcess = 0
    }
}
