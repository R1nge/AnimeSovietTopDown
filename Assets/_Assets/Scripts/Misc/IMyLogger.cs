namespace _Assets.Scripts.Misc
{
    public interface IMyLogger
    {
        bool IsLogEnable { get; set; }
        void Log(string message);
        void LogError(string message);
        void LogWarning(string message);
    }
}