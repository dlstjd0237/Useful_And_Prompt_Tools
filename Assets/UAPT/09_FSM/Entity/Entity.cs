using BIS.Init;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace BIS.Entities
{
    public abstract class Entity : InitBase
    {
        protected Dictionary<Type, IEntityComponentInit> _components;


        public override bool Init()
        {
            if (base.Init() == false)
                return false;

            _components = new Dictionary<Type, IEntityComponentInit>();
            AddComponentToDictionary();
            ComponentInitialize();
            AfterInitalize();

            return true;
        }


        private void AddComponentToDictionary()
        {
            GetComponentsInChildren<IEntityComponentInit>(true).ToList().ForEach(component => _components.Add(component.GetType(), component));
        }
        private void ComponentInitialize()
        {
            foreach (var item in _components)
            {
                item.Value.Initalize(this);
            }
        }

        private void AfterInitalize()
        {
            _components.Values.OfType<IAfterInit>()
             .ToList().ForEach(afterInitCompo => afterInitCompo.AfterInit());
        }
        public T GetCompo<T>(bool isDerived = false) where T : IEntityComponentInit
        {
            if (_components.TryGetValue(typeof(T), out IEntityComponentInit component))
            {
                return (T)component;
            }

            if (isDerived == false) return default;

            Type findType = _components.Keys.FirstOrDefault(type => type.IsSubclassOf(typeof(T)));
            if (findType != null)
                return (T)_components[findType];

            return default;
        }
    }
}
