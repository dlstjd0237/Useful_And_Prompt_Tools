using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace UAPT.Utile
{
    public enum ScrollDirection
    {
        Horizontal,
        Vertical
    }
    public static class ToolKitUtile
    {
        #region SetButtonClikeEvent

        /// <summary>
        /// 클릭 이벤트를 넣어 주는 메서드입니다.
        /// </summary>
        /// <param name="_btn">이벤트를 넣어줄 버튼</param>
        /// <param name="_action">클릭 이벤트</param>
        public static void SetClikeEvent(Button _btn, UnityEngine.Events.UnityAction _action)
        {
            if (_btn == null)
                return;
            _btn.RegisterCallback<ClickEvent>(evt => _action?.Invoke());
        }

        public static void SetClikeEvent(Button[] _btns, UnityEngine.Events.UnityAction _action)
        {
            if (_btns == null)
                return;
            for (int i = 0; i < _btns.Length; ++i)
            {
                _btns[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(List<Button> _btnList, UnityEngine.Events.UnityAction _action)
        {
            if (_btnList == null)
                return;
            for (int i = 0; i < _btnList.Count; ++i)
            {
                _btnList[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(VisualElement _vE, UnityEngine.Events.UnityAction _action)
        {
            if (_vE == null)
                return;
            _vE.RegisterCallback<ClickEvent>(evt => _action?.Invoke());
        }

        public static void SetClikeEvent(VisualElement[] _vEs, UnityEngine.Events.UnityAction _action)
        {
            if (_vEs == null)
                return;
            for (int i = 0; i < _vEs.Length; ++i)
            {
                _vEs[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(List<VisualElement> _vEList, UnityEngine.Events.UnityAction _action)
        {
            if (_vEList == null)
                return;
            for (int i = 0; i < _vEList.Count; ++i)
            {
                _vEList[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(Label _label, UnityEngine.Events.UnityAction _action)
        {
            if (_label == null)
                return;
            _label.RegisterCallback<ClickEvent>(evt => _action?.Invoke());
        }

        public static void SetClikeEvent(Label[] _labels, UnityEngine.Events.UnityAction _action)
        {
            if (_labels == null)
                return;
            for (int i = 0; i < _labels.Length; ++i)
            {
                _labels[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(List<Label> _labelList, UnityEngine.Events.UnityAction _action)
        {
            if (_labelList == null)
                return;
            for (int i = 0; i < _labelList.Count; ++i)
            {
                _labelList[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(TextField _textField, UnityEngine.Events.UnityAction _action)
        {
            if (_textField == null)
                return;
            _textField.RegisterCallback<ClickEvent>(evt => _action?.Invoke());
        }

        public static void SetClikeEvent(TextField[] _textField, UnityEngine.Events.UnityAction _action)
        {
            if (_textField == null)
                return;
            for (int i = 0; i < _textField.Length; ++i)
            {
                _textField[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        public static void SetClikeEvent(List<TextField> _textFieldList, UnityEngine.Events.UnityAction _action)
        {
            if (_textFieldList == null)
                return;
            for (int i = 0; i < _textFieldList.Count; ++i)
            {
                _textFieldList[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }
        #endregion

        #region SetHoverEvent

        /// <summary>
        /// Hover 이벤트를 넣어 주는 메서드 입니다.
        /// </summary>
        /// <param name="_btn"></param>
        /// <param name="_action"></param>
        public static void SetHoverEvent(Button _btn, UnityEngine.Events.UnityAction _action)
        {
            if (_btn == null)
                return;
            _btn.RegisterCallback<MouseEnterEvent>(evt => _action?.Invoke());
        }

        public static void SetHoverEvent(VisualElement _vE, UnityEngine.Events.UnityAction _action)
        {
            if (_vE == null)
                return;
            _vE.RegisterCallback<MouseEnterEvent>(evt => _action?.Invoke());
        }

        public static void SetHoverEvent(Label _label, UnityEngine.Events.UnityAction _action)
        {
            if (_label == null)
                return;
            _label.RegisterCallback<MouseEnterEvent>(evt => _action?.Invoke());
        }

        public static void SetHoverEvent(TextField _textField, UnityEngine.Events.UnityAction _action)
        {
            if (_textField == null)
                return;
            _textField.RegisterCallback<MouseEnterEvent>(evt => _action?.Invoke());
        }

        #endregion

        #region SetScrollSpeed

        /// <summary>
        /// 스크롤 뷰의 마우스 스크롤 스피드를 설정해 주는 메서드입니다.
        /// </summary>
        /// <param name="_scroller"></param>
        /// <param name="_scrollFactor">Usually 500.0f</param>
        /// <param name="_scrollDir">어느 방향으로 움직이는 스크롤인가요?</param>
        public static void SetScrollSpeed(ScrollView _scroller, float _scrollFactor, ScrollDirection _scrollDir)
        {
            if (_scroller == null)
                return;

            if (_scrollDir == ScrollDirection.Vertical)
            {
                _scroller.RegisterCallback<WheelEvent>((evt) =>
                {
                    _scroller.scrollOffset = new Vector2(_scroller.scrollOffset.x + _scrollFactor * evt.delta.y, 0);
                    evt.StopPropagation();
                });
                return;
            }
            else if (_scrollDir == ScrollDirection.Horizontal)
            {
                _scroller.RegisterCallback<WheelEvent>((evt) =>
                {
                    _scroller.scrollOffset = new Vector2(0, _scroller.scrollOffset.x + _scrollFactor * evt.delta.y);
                    evt.StopPropagation();
                });
            }
        }

        #endregion

        #region SetStyleBackground

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_vE"></param>
        /// <param name="_sprite">바꿀 Sprite</param>
        public static void SetStyleBackground(VisualElement _vE, Sprite _sprite)
        {
            if (_vE == null)
                return;
            _vE.style.backgroundImage = _sprite.texture;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_vE"></param>
        /// <param name="_texture2D">바꿀 Textur2D</param>
        public static void SetStyleBackground(VisualElement _vE, Texture2D _texture2D)
        {
            if (_vE == null)
                return;
            _vE.style.backgroundImage = _texture2D;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_but"></param>
        /// <param name="_sprite">바꿀 Sprite</param>
        public static void SetStyleBackground(Button _but, Sprite _sprite)
        {
            if (_but == null)
                return;
            _but.style.backgroundImage = _sprite.texture;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_but"></param>
        /// <param name="_texture2D">바꿀 Textur2D</param>
        public static void SetStyleBackground(Button _but, Texture2D _texture2D)
        {
            if (_but == null)
                return;
            _but.style.backgroundImage = _texture2D;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_label"></param>
        /// <param name="_sprit">바꿀 Sprite</param>
        public static void SetStyleBackground(Label _label, Sprite _sprit)
        {
            if (_label == null)
                return;
            _label.style.backgroundImage = _sprit.texture;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_label"></param>
        /// <param name="_texture2D">바꿀 Textur2D</param>
        public static void SetStyleBackground(Label _label, Texture2D _texture2D)
        {
            if (_label == null)
                return;
            _label.style.backgroundImage = _texture2D;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_textField"></param>
        /// <param name="_sprite">바꿀 Sprite</param>
        public static void SetStyleBackground(TextField _textField, Sprite _sprite)
        {
            if (_textField == null)
                return;
            _textField.style.backgroundImage = _sprite.texture;
        }

        /// <summary>
        /// Style.BackgroundImage 를 바꿔주는 메서드입니다.
        /// </summary>
        /// <param name="_textField"></param>
        /// <param name="_texture2D">바꿀 Textur2D</param>
        public static void SetStyleBackground(TextField _textField, Texture2D _texture2D)
        {
            if (_textField == null)
                return;
            _textField.style.backgroundImage = _texture2D;
        }

        #endregion

        #region VisualTreeAdd

        public static void VisualTreeAdd(VisualTreeAsset _target, VisualElement _parent)
        {
            _parent.Add(_target.Instantiate().Q<VisualElement>());
        }

        #endregion

        public static void ElementToggle<T>(T element, string str) where T : VisualElement
        {
            element.ToggleInClassList(str);
        }
    }
}

