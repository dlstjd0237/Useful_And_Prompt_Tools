using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SwipeDirection
{
    None,
    Up,
    Down,
    Left,
    Right
}

public class Swipe : MonoBehaviour
{
    private SwipeDirection _currentSwipeDirection = SwipeDirection.None;
    public SwipeDirection CurrentSwipeDirection => _currentSwipeDirection;
    private Vector2 _firstTouchPos;
    private Vector2 _secondTouchPos;
    private Vector2 _currentSwipe;

    private void Update()
    {
        OnSwipe();
    }

    private void OnSwipe()
    {
        if (Input.touches.Length > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began) // 화면을 눌렀을 때
            {
                TouchDown(touch);
            }
            if (touch.phase == TouchPhase.Ended) // 화면에 손가락을 땟을 때
            {
                TouchUp(touch);
            }
        }
    }

    private void TouchDown(Touch touch)
    {
        _firstTouchPos = new Vector2(touch.position.x, touch.position.y); //눌렀을 때 포지션 저장
    }

    private void TouchUp(Touch touch)
    {
        _secondTouchPos = new Vector2(touch.position.x, touch.position.y); // 땠을 때 포지션 저장

        _currentSwipe = new Vector3(_secondTouchPos.x - _firstTouchPos.x, _secondTouchPos.y - _firstTouchPos.y);

        _currentSwipe.Normalize(); //정규화

        if (_currentSwipe.y > 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
        {
            _currentSwipeDirection = SwipeDirection.Up;
            Debug.Log("Up");
        }
        if (_currentSwipe.y < 0 && _currentSwipe.x > -0.5f && _currentSwipe.x < 0.5f)
        {
            _currentSwipeDirection = SwipeDirection.Down;
            Debug.Log("Down");
        }
        if (_currentSwipe.x < 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
        {
            _currentSwipeDirection = SwipeDirection.Left;
            Debug.Log("Left");
        }
        if (_currentSwipe.x > 0 && _currentSwipe.y > -0.5f && _currentSwipe.y < 0.5f)
        {
            _currentSwipeDirection = SwipeDirection.Right;
            Debug.Log("Right");
        }
    }
}
