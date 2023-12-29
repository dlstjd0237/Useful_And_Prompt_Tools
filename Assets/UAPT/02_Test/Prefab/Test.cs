using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{

    void Start()
    {
        Invoke(nameof(qwer), 2);
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void qwer() => gameObject.SetActive(false);
    private void OnDisable()
    {
        this.gameObject.SetActive(false);
        PoolManager.ReturnToPool(this.gameObject);
        CancelInvoke();
    }
    private void OnApplicationQuit()
    {
        this.gameObject.SetActive(false);
        PoolManager.ReturnToPool(this.gameObject);
    }

}
