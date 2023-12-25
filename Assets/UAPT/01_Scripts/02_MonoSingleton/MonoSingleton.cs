using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool shuttingDown = false;
    private static object locker = new object();
    private static T instance = null; // T는 제네릭 탑입이기에 뭐든 넣을수 있음
    public static T Instance
    {
        get
        {
            if (shuttingDown)
            {
                return null;
            }
            lock (locker)
            {

                if (instance == null)
                {

                    instance = (T)FindAnyObjectByType(typeof(T));
                    if (instance == null)
                    {

                        GameObject temp = new GameObject(typeof(T).ToString());
                        instance = temp.AddComponent<T>();

                    }
                    DontDestroyOnLoad(instance);
                }
            }
            return instance;
        }
    }

    private void OnApplicationQuit()
    {
        shuttingDown = true;
    }

    private void OnDestroy()
    {
        shuttingDown = true;
    }
}