using System;
using UnityEngine;


namespace BIS.Utility
{
    public static class Util
    {
        public static T GetOrAddComponent<T>(GameObject go) where T : UnityEngine.Component
        {
            T compoent = go.GetComponent<T>();
            if (compoent == null)
                compoent = go.AddComponent<T>();

            return compoent;
        }

        /// <summary>
        /// All Finding
        /// </summary>
        /// <param name="go">Target GameObject</param>
        /// <param name="name">GameObject Name</param>
        /// <param name="recursive">Find in Every Child</param>
        /// <returns></returns>
        public static GameObject FindChild(GameObject go, string name = null, bool recursive = false)
        {
            Transform transform = FindChild<Transform>(go, name, recursive);
            if (transform == null)
                return null;

            return transform.gameObject;
        }
        public static T FindChild<T>(GameObject go, string name = null, bool recursive = false) where T : UnityEngine.Object
        {
            if (go == null)
                return null;

            if (recursive==false)
            {
                for (int i = 0; i < go.transform.childCount; ++i)
                {
                    Transform transform = go.transform.GetChild(i);
                    if (string.IsNullOrEmpty(name) || transform.name == name)
                    {
                        T component = transform.GetComponent<T>();
                        if (component != null)
                            return component;
                    }
                }
            }
            else
            {
                foreach (T component in go.GetComponentsInChildren<T>())
                {
                    if (string.IsNullOrEmpty(name) || component.name == name)
                    {
                        return component;
                    }
                }
            }
            return null;
        }
        public static bool ValueNullCheck<T>(this T Value) where T : class
        {
            if (Value == null)
            {
                Type type = typeof(T);
                Debug.LogError($"{type.ToString()} Is Null");
                return false;
            }
            return true;
        }

        public static bool IntToBool(int value) => value == 0 ? false : true;

        public static int BoolToInt(bool value) => value ? 1 : 0;

        public static RaycastHit GetMouseToRay(Camera cam)
        {
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                return hit;
            }
            return hit;
        }
    }
}

