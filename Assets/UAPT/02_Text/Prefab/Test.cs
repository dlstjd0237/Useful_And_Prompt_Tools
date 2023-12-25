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
        PoolManager.ReturnToPool(this.gameObject);
        CancelInvoke();
    }
}
