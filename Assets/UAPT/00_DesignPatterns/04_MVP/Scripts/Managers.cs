using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers : MonoBehaviour
{
    private static Managers s_inctance;
    private static Managers Instacne
    {
        get
        {
            Init();
            return s_inctance;
        }
    }

    private ResourceManager _resource = new ResourceManager();

    public static ResourceManager Resource { get { return Instacne._resource; } }

    private static void Init()
    {
        if (s_inctance == null)
        {
            GameObject go = GameObject.Find("@Managers");
            if (go == null)
            {
                go = new GameObject { name = "@Managers" };
                go.AddComponent<Managers>();
            }

            DontDestroyOnLoad(go);

            //√ ±‚»≠
            s_inctance = go.GetComponent<Managers>();
        }
    }
}
