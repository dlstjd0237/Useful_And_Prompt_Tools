using System;
using UnityEngine;
namespace UAPT.SerializableVariable
{
    [Serializable]
    public class SerializableDecimal : ISerializationCallbackReceiver
    {
        public decimal Value;
        [SerializeField]
        private int[] _data;
        public void OnAfterDeserialize()
        {
            _data = decimal.GetBits(Value);
        }

        public void OnBeforeSerialize()
        {
            if (_data != null && _data.Length == 4)
            {
                Value = new decimal(_data);
            }
        }
    }
}

