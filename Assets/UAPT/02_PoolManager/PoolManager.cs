using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(PoolManager))]
public class PoolManagerEditor : Editor
{
    const string INFO = "오브젝트 가져올때\n" +
        " void Start()\n{\n" +
        "   PoolManager.SpawnFromPool(태그 이름,위치, 각도);\n}\n" +
        "\n풀링한 오브젝트에 다음을 적으세요. \n void OnDisable()\n{\n" +
        "   PoolManager.ReturnToPool(gameObject);   //한 객체에 한번만 \n" +
        "   CancelInvoke();     //Monobehaviour에 Invoke가 있다면\n}";
    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox(INFO, MessageType.Info);
        base.OnInspectorGUI();
    }
}
#endif



public class PoolManager : MonoBehaviour
{
    public static PoolManager Instance;
    private void Awake() => Instance = this;

    [Serializable]
    public class Pool
    {
        public string Tag;
        public GameObject Prefab;
        public int Size;
    }

    [SerializeField] Pool[] _pools;
    List<GameObject> _spawnObjects;
    Dictionary<string, Queue<GameObject>> _poolDictionary;
    readonly string INFO = "풀링한 오브젝트에 다음을 적으세요 \n void OnDisable()\n{\n" +
        "   PoolManager.ReturnToPool(gameObject);   //한 객체에 한번만 \n" +
        "   CancelInvoke();     //Monobehaviour에 Invoke가 있다면\n}";

    public static GameObject SpawnFromPool(string tag, Vector3 position) =>
        Instance._SpawnFromPool(tag, position, Quaternion.identity);
    public static GameObject SpawnFromPool(string tag, Vector3 position, Quaternion rotation) =>
        Instance._SpawnFromPool(tag, position, rotation);
    public static T SpawnFromPool<T>(string tag, Vector3 position) where T : Component
    {
        GameObject obj = Instance._SpawnFromPool(tag, position, Quaternion.identity);
        if (obj.TryGetComponent(out T component))
            return component;
        else
        {
            obj.SetActive(false);
            throw new Exception($"컴포넌트 찾을수가 없음");
        }
    }

    public static T SpawnFromPool<T>(string tag, Vector3 position, Quaternion rotation) where T : Component
    {
        GameObject obj = Instance._SpawnFromPool(tag, position, rotation);
        if (obj.TryGetComponent(out T component))
            return component;
        else
        {
            obj.SetActive(false);
            throw new Exception($"컴포넌트 찾을수가 없음");
        }
    }
    public static List<GameObject> GetAllPools(string tag)
    {
        if (!Instance._poolDictionary.ContainsKey(tag))
            throw new Exception($"{ tag } 태그가 있는 풀이 존재하지 않음");
        return Instance._spawnObjects.FindAll(x => x.name == tag);
    }

    public static List<T> GetAllPools<T>(string tag) where T : Component
    {
        List<GameObject> objects = GetAllPools(tag);

        if (!objects[0].TryGetComponent(out T component))
            throw new Exception($"컴포넌트 찾을수가 없음");
        return objects.ConvertAll(x => x.GetComponent<T>());
    }

    public static void ReturnToPool(GameObject obj)
    {
        if (!Instance._poolDictionary.ContainsKey(obj.name))
            throw new Exception($"{obj.name} 태그가 있는 풀이 존재하지 않음.");

        Instance._poolDictionary[obj.name].Enqueue(obj);
    }

    [ContextMenu("GetSpawnObjectsInfo")]
    private void GetSpawnObjectsInFo()
    {
        foreach (var pool in _pools)
        {
            int count = _spawnObjects.FindAll(x => x.name == pool.Tag).Count;
            Debug.Log($"{pool.Tag} count : {count}");
        }
    }

    private GameObject _SpawnFromPool(string tag, Vector3 position, Quaternion rotation)
    {
        if (!_poolDictionary.ContainsKey(tag))
            throw new Exception($"{tag} 태그가 있는 풀이 존재하지 않음 "); // 태그가 없을경우

        //큐에 없으면 새로 추가
        Queue<GameObject> poolQueue = _poolDictionary[tag];
        if (poolQueue.Count <= 0)
        {
            Pool pool = Array.Find(_pools, x => x.Tag == tag);
            var obj = CreateNewObject(pool.Tag, pool.Prefab);
            ArrangePool(obj);
        }

        //큐에서 꺼내서 사용
        GameObject objectToSpawn = poolQueue.Dequeue(); //Dequeue는 큐에서 꺼낸다는 거임
        objectToSpawn.transform.position = position;
        objectToSpawn.transform.rotation = rotation;
        objectToSpawn.SetActive(true);

        return objectToSpawn;
    }

    private void Start()
    {
        _spawnObjects = new List<GameObject>();
        _poolDictionary = new Dictionary<string, Queue<GameObject>>();

        //미리 생성
        foreach (Pool pool in _pools)
        {
            _poolDictionary.Add(pool.Tag, new Queue<GameObject>());
            for (int i = 0; i < pool.Size; i++)
            {
                var obj = CreateNewObject(pool.Tag, pool.Prefab);
                ArrangePool(obj);
            }

            //OnDisable에 ReturnToPool 구현여부와 중복구현 검사
            if (_poolDictionary[pool.Tag].Count <= 0)
                Debug.LogError($"{pool.Tag}{INFO}");
            else if (_poolDictionary[pool.Tag].Count != pool.Size)
                Debug.LogError($"{pool.Tag}에 ReturnToPool이 중복되있음.");
        }
    }

    private GameObject CreateNewObject(string tag, GameObject prefab)
    {
        var obj = Instantiate(prefab, transform);
        obj.name = tag;
        obj.SetActive(false); // 비활성화시 ReturnToPool을 하므로 Enqueu가 됨
        return obj;
    }

    private void ArrangePool(GameObject obj)
    {
        //추가된 오브젝트 묶어서 정렬
        bool isFind = false;
        for (int i = 0; i < transform.childCount; i++)
        {
            if (i == transform.childCount - 1)
            {
                obj.transform.SetSiblingIndex(i);
                _spawnObjects.Insert(i, obj);
                break;
            }
            else if (transform.GetChild(i).name == obj.name) //현제 이름과 오브젝트 이름이 같으니 오브젝트를 잘 찾은거임
                isFind = true;
            else if (isFind)
            {
                obj.transform.SetSiblingIndex(i);
                _spawnObjects.Insert(i, obj);
                break;
            }
        }
    }
}
