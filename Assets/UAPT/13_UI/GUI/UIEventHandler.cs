using BIS.Define;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace BIS.UI
{
    public class UIEventHandler : MonoBehaviour, IPointerClickHandler, IPointerDownHandler, IPointerUpHandler, IDragHandler, IPointerEnterHandler, IPointerExitHandler
    {
        public Dictionary<EUIEvent, Action<PointerEventData>> UIEventDictionary { get; private set; }

        private void Awake()
        {
            UIEventDictionary = new Dictionary<EUIEvent, Action<PointerEventData>>();
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (UIEventDictionary.TryGetValue(EUIEvent.Drag, out var action))
                action?.Invoke(eventData);
        }
        public void OnPointerClick(PointerEventData eventData)
        {
            if (UIEventDictionary.TryGetValue(EUIEvent.Click, out var action))
                action?.Invoke(eventData);
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            if (UIEventDictionary.TryGetValue(EUIEvent.PointerDown, out var action))
                action?.Invoke(eventData);
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            if (UIEventDictionary.TryGetValue(EUIEvent.PointerEnter, out var action))
                action?.Invoke(eventData);
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            if (UIEventDictionary.TryGetValue(EUIEvent.PointerExit, out var action))
                action?.Invoke(eventData);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (UIEventDictionary.TryGetValue(EUIEvent.PointerUp, out var action))
                action?.Invoke(eventData);
        }
    }
}
