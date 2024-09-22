using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ResourceManagement.AsyncOperations;
using System;
using Object = UnityEngine.Object;
using UnityEngine.AddressableAssets;

public class ResourceManager
{
    private Dictionary<string, Object> _resources = new Dictionary<string, Object>();
    private Dictionary<string, AsyncOperationHandle> _handles = new Dictionary<string, AsyncOperationHandle>();

    #region Load Resource

    public T Load<T>(string key) where T : Object
    {
        if (_resources.TryGetValue(key, out Object resource)) // 딕셔너리에 Key값에 해당하는 값이 존재하면 그 값 리턴
            return resource as T;

        return null;
    }

    public GameObject Instantiate(string key, Transform parent = null)
    {
        GameObject prefab = Load<GameObject>(key);
        if (prefab == null)
        {
            Debug.LogError($"Failed to load prefab : {key}");
            return null;
        }
        GameObject go = Object.Instantiate(prefab, parent);
        go.name = prefab.name;

        return go;
    }

    #endregion

    #region Addressable

    private void LoadAsync<T>(string key, Action<T> callback = null) where T : Object
    {
        if (_resources.TryGetValue(key, out Object resource))
        {
            callback?.Invoke(resource as T);
            return;
        }

        string loadKey = key;
        if (key.Contains(".sprite"))
            loadKey = $"{key}[{key.Replace(".sprite", "")}]";

        var asyncOperation = Addressables.LoadAssetAsync<T>(loadKey);
        asyncOperation.Completed += (op) =>
         {
             _resources.Add(key, op.Result);
             _handles.Add(key, asyncOperation);
             callback?.Invoke(op.Result);
         };

    }

    /// <summary>
    /// (count == total) is true = AllComplet 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    /// <param name="label">Defualt : PreLoad</param>
    /// <param name="callback"></param>
    public void LoadAllAsync<T>(string label, Action<string, int, int> callback) where T : Object
    {
        var onHandle = Addressables.LoadResourceLocationsAsync(label, typeof(T));
        onHandle.Completed += (op) =>
        {
            int loadCount = 0;
            int totalCount = op.Result.Count;

            foreach (var result in op.Result)
            {
                if (result.PrimaryKey.Contains(".sprite"))
                {
                    LoadAsync<Sprite>(result.PrimaryKey, (obj) =>
                    {
                        loadCount++;
                        callback?.Invoke(result.PrimaryKey, loadCount, totalCount);
                    });
                }
                else
                {
                    LoadAsync<T>(result.PrimaryKey, (obj) =>
                    {
                        loadCount++;
                        callback?.Invoke(result.PrimaryKey, loadCount, totalCount);
                    });
                }
            }
        };
    }

    #endregion
}
