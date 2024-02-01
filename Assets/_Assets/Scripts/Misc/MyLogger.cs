using UnityEngine;

namespace _Assets.Scripts.Misc
{
    public class MyLogger : IMyLogger
    {
        public bool IsLogEnable { get; set; }

        public void Log(string message)
        {
            if (IsLogEnable)
            {
                Debug.Log(message);
            }
        }

        public void LogError(string message)
        {
            if (IsLogEnable)
            {
                Debug.LogError(message);
            }
        }

        public void LogWarning(string message)
        {
            if (IsLogEnable)
            {
                Debug.LogWarning(message);
            }
        }
    }
}