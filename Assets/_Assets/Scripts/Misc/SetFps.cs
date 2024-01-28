using UnityEngine;

namespace _Assets.Scripts.Misc
{
    public static class SetFps
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void Main() => Application.targetFrameRate = 120;
    }
}