using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceTest : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Managers.Resource.LoadAllAsync<Object>("PreLoad", (key, count, totalCount) =>
         {
             if (totalCount == count)
             {
                 Debug.Log("Good");
                 Managers.Resource.Instantiate("Canvas");
             }
         });
    }

    // Update is called once per frame
    void Update()
    {

    }
}
