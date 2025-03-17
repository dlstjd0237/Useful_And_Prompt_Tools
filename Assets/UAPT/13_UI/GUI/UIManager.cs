using BIS.Extension;
using BIS.UI;
using BIS.Utility;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using static BIS.Utility.Util;
namespace BIS.Managers
{

    public class UIManager//UIPopup관리하는 매니저
    {
        private int _order = 10;

        private Stack<PopupUI> _popupStack = new Stack<PopupUI>();

        private SceneUI _sceneUI = null;
        public SceneUI SceneUI
        {
            get { return _sceneUI; }
            set { _sceneUI = value; }
        }


        public GameObject Root
        {
            get
            {
                GameObject root = GameObject.Find("@UI_Root");
                if (root == null)
                    root = new GameObject { name = @"UI_Root" };
                return root;
            }
        }

        public void SetCanvas(GameObject go, bool sort = true, int sortOrder = 0)
        {
            Canvas canvas = GetOrAddComponent<Canvas>(go);
            if (canvas == null)
            {
                canvas.renderMode = RenderMode.ScreenSpaceOverlay;
                canvas.overrideSorting = sort;
            }

            CanvasScaler cs = go.GetOrAddComponent<CanvasScaler>();
            if (cs != null)
            {
                cs.uiScaleMode = CanvasScaler.ScaleMode.ScaleWithScreenSize;
                cs.referenceResolution = new Vector2(1920, 1080);
            }

            go.GetOrAddComponent<GraphicRaycaster>();

            if (sort)
            {
                canvas.sortingOrder = _order;
                _order++;
            }
            else
            {
                canvas.sortingOrder = sortOrder;
            }
        }

        public T GetSceneUI<T>() where T : UIBase
        {
            return _sceneUI as T;
        }

        public T MakeSupItem<T>(Transform parent, string name = null, bool pooling = true) where T : UIBase
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate(name, parent, pooling);
            go.transform.SetParent(parent);

            return Util.GetOrAddComponent<T>(go);
        }

        public T MakeWorldSpaceUI<T>(Transform parent = null, string name = null) where T : UIBase
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate(name, parent);
            go.transform.SetParent(parent);
            if (parent != null)
                go.transform.SetParent(parent);

            Canvas canvas = go.GetOrAddComponent<Canvas>();
            canvas.renderMode = RenderMode.WorldSpace;
            canvas.worldCamera = Camera.main;

            return GetOrAddComponent<T>(go);
        }

        /// <summary>
        /// UI_GameScene
        /// Gold, Dia UI_Item
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="name"></param>
        /// <returns></returns>
        public T ShowBaseUI<T>(string name = null) where T : UIBase
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate(name);
            T baseUI = GetOrAddComponent<T>(go);

            go.transform.SetParent(Root.transform);

            return baseUI;
        }

        public T ShowSceneUI<T>(string name = null) where T : SceneUI
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate(name);
            T sceneUI = GetOrAddComponent<T>(go);
            _sceneUI = sceneUI;

            go.transform.SetParent(Root.transform);

            return sceneUI;
        }

        public T ShowPopup<T>(string name = null) where T : PopupUI
        {
            if (string.IsNullOrEmpty(name))
                name = typeof(T).Name;

            GameObject go = Manager.Resource.Instantiate(name);
            T popup = GetOrAddComponent<T>(go);
            _popupStack.Push(popup);

            go.transform.SetParent(Root.transform);

            return popup;
        }

        public void ClosePopupUI(PopupUI popup)
        {
            if (_popupStack.Count == 0)
                return;

            if (_popupStack.Peek() != popup)
            {
                Debug.Log("Close Popup Failed");
                return;
            }

        }

        public void ClosePopupUI()
        {
            if (_popupStack.Count == 0)
                return;

            PopupUI popup = _popupStack.Pop();
            Manager.Resource.Destroy(popup.gameObject);
            _order--;

        }

        public void CloseAllPopupUI()
        {
            while (_popupStack.Count > 0)
                ClosePopupUI();

        }
        public int GetPopupCount()
        {
            return _popupStack.Count;
        }

        public void Clear()
        {
            CloseAllPopupUI();
            _sceneUI = null;
        }
    }
}