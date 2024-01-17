using UnityEngine;

public class MonoSingleton<T> : MonoBehaviour where T : MonoBehaviour
{
    private static bool shuttingDown = false;
    private static object locker = new object();
    private static T instance = null;
    public static T Instance
    {
        get
        {
            if (shuttingDown) //플레이어가 게임을 껏을때 또는 메니저 스크립트를 삭제 했을때 return null
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

    private void OnApplicationQuit()//모바일 에서 앱이 꺼졌을때
    {
        shuttingDown = true;
    }

    private void OnDestroy()
    {
        shuttingDown = true;
    }
}