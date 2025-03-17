using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;
using static BIS.Utility.Util;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;
using BIS.Define;
using BIS.Init;
using BIS.Utility;

namespace BIS.UI
{
    public class UIBase : InitBase
    {
        protected Dictionary<Type, Object[]> _objects = new();


        #region Bind
        protected void Bind<T>(Type type) where T : UnityEngine.Object
        {
            string[] names = Enum.GetNames(type);

            UnityEngine.Object[] objects = new UnityEngine.Object[names.Length];
            _objects.Add(typeof(T), objects);

            for (int i = 0; i < names.Length; ++i)
            {
                if (typeof(T) == typeof(GameObject))
                    objects[i] = FindChild(gameObject, names[i], true);
                else
                    objects[i] = FindChild<T>(gameObject, names[i], true);

                if (objects[i] == null)
                    Debug.Log($"Failed to bind{name[i]}");

            }
        }

        protected void BindObjects(Type type) => Bind<GameObject>(type);
        protected void BindImages(Type type) => Bind<Image>(type);
        protected void BindTexts(Type type) => Bind<TMP_Text>(type);
        protected void BindButtons(Type type) => Bind<Button>(type);
        protected void BindSliders(Type type) => Bind<Slider>(type);

        #endregion


        #region Get

        protected T Get<T>(int idx) where T : UnityEngine.Object
        {
            UnityEngine.Object[] objects = null;
            if (_objects.TryGetValue(typeof(T), out objects) == false)
                return null;

            return objects[idx] as T;
        }

        protected GameObject GetObject(int idx) => Get<GameObject>(idx);
        protected Image GetImage(int idx) => Get<Image>(idx);
        protected TMP_Text GetText(int idx) => Get<TMP_Text>(idx);
        protected Button GetButton(int idx) => Get<Button>(idx);
        protected Slider GetSlider(int idx) => Get<Slider>(idx);

        #endregion


        public static void BindEvent(GameObject go, Action<PointerEventData> action, EUIEvent type = EUIEvent.Click)
        {
            UIEventHandler evt = Util.GetOrAddComponent<UIEventHandler>(go);

            if (evt.UIEventDictionary.ContainsKey(type) == true)
            {
                evt.UIEventDictionary[type] -= action;
                evt.UIEventDictionary[type] += action;
            }
            else if (evt.UIEventDictionary.ContainsKey(type) == false)
            {
                evt.UIEventDictionary[type] = action;
            }
        }

    }
}