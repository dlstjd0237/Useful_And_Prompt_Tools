using System.Collections.Generic;
using UnityEngine;

namespace UAPT.SerializableVariable
{
    public class SerializableDictionary<TKey, TValue> : Dictionary<TKey, TValue>, ISerializationCallbackReceiver
    {
        [SerializeField] private List<TKey> _keys = new();
        [SerializeField] private List<TValue> _values = new();

        public void OnBeforeSerialize()
        {
            _keys.Clear();
            _values.Clear();

            foreach (var item in this)
            {
                _keys.Add(item.Key);
                _values.Add(item.Value);
            }
        }
        public void OnAfterDeserialize()
        {
            this.Clear();
            if (_keys.Count != _values.Count)
            {
                Debug.LogError($"Key count not equal to value count");
                return;
            }

            for (int i = 0; i < _keys.Count; ++i)
            {
                this.Add(_keys[i], _values[i]);
            }
        }
    }
}

