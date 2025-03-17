using BIS.Utility;
using UnityEngine;

namespace BIS.Extension
{
    public static class Extension
    {
        public static T GetOrAddComponent<T>(this GameObject go) where T : UnityEngine.Component
        {
            return Util.GetOrAddComponent<T>(go);
        }

        public static bool IsValid(this GameObject go)
        {
            return go != null && go.activeSelf;
        }
    }
}


