using System.Collections;
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
        /// 버튼의 클릭 이벤트를 넣어 주는 메서드입니다.
        /// </summary>
        /// <param name="_btn">이벤트를 넣어줄 버튼</param>
        /// <param name="_action">클릭 이벤트</param>
        public static void SetButtonClikeEvent(Button _btn, UnityEngine.Events.UnityAction _action)
        {
            if (_btn == null)
                return;
            _btn.RegisterCallback<ClickEvent>(evt => _action?.Invoke());
        }

        /// <summary>
        /// 버튼의 클릭 이벤트를 넣어 주는 메서드입니다.
        /// </summary>
        /// <param name="_btns">이벤트를 넣어줄 버튼 배열</param>
        /// <param name="_action">클릭 이벤트</param>
        public static void SetButtonClikeEvent(Button[] _btns, UnityEngine.Events.UnityAction _action)
        {
            if (_btns == null)
                return;
            for (int i = 0; i < _btns.Length; ++i)
            {
                _btns[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
        }

        /// <summary>
        /// 버튼의 클릭 이벤트를 넣어 주는 메서드입니다.
        /// </summary>
        /// <param name="_btnList">이벤트를 넣어줄 버튼 리스트</param>
        /// <param name="_action">클릭 이벤트</param>
        public static void SetButtonClikeEvent(List<Button> _btnList, UnityEngine.Events.UnityAction _action)
        {
            if (_btnList == null)
                return;
            for (int i = 0; i < _btnList.Count; ++i)
            {
                _btnList[i].RegisterCallback<ClickEvent>(evt => _action?.Invoke());
            }
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
    }
}

