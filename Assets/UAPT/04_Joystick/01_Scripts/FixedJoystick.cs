using UnityEngine;
using UnityEngine.EventSystems;

#region 설명서 및 에디터
#if UNITY_EDITOR
using UnityEditor;

[CustomEditor(typeof(FixedJoystick))]
public class FixedJoystickEditor : Editor
{
    const string INFO = "joystickValue SO에 있는 벨류를 가져다 쓰면 됨\n" +
      "자동으로 노말라이즈 된 벡터값이 SO의 Value로 들어감\n";


    public override void OnInspectorGUI()
    {
        EditorGUILayout.HelpBox(INFO, MessageType.Info);
        base.OnInspectorGUI();
    }
}
#endif
#endregion

public class FixedJoystick : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IDragHandler
{
    private RectTransform _rect;
    private Vector2 _touch = Vector2.zero;
    [Header("움직일 동그라미")]
    [SerializeField] private RectTransform _handle;
    private float _widthHalf;
    [SerializeField] JoystickValue _value;
    void Start()
    {
        _rect = GetComponent<RectTransform>();
        _widthHalf = _rect.sizeDelta.x * 0.5f;
    }


    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _value.joyTouch = Vector2.zero;
        _handle.anchoredPosition = Vector2.zero;
    }

    public void OnDrag(PointerEventData eventData)
    {
        _touch = (eventData.position - _rect.anchoredPosition) / _widthHalf;
        if (_touch.magnitude > 1)
        {
            _touch = _touch.normalized;
        }
        _value.joyTouch = _touch;
        _handle.anchoredPosition = _touch * _widthHalf;
    }


}
