using UnityEngine;

namespace DASUnityFramework.Scripts.Utilities
{
    public static class ScreenUtils
    {
        public static Vector2 ScreenCenter()
        {
            return new Vector2(Screen.width / 2f, Screen.height / 2f);
        }
    }
}